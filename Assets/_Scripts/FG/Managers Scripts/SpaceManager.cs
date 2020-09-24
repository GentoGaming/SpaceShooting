

using System;
using System.Collections.Generic;
using _Scripts.FG.NPC;
using _Scripts.FG.Player;
using TMPro;
using UnityEngine;

namespace _Scripts.FG.Managers_Scripts
{
    // Main class to initialize References  and use it inside many different Classes
    public class SpaceManager : MonoBehaviour
    {
        public enum Edges
        {
            Left = -140,
            Right = 43,
            Top = 34,
            Bottom = -34
        }

        public bool isGameActive;
        public static SpaceManager Instance;
        private EnemySpawner _enemySpawner;
        public GameObject spaceBackground;
        public float gameBackgroundSpeed = 1.0f;
        
        public GameObject spaceShipGameObject;
        public GameObject playerShield;
        
        private GameObject _onePickupReadyGameObject;
        private GameObject _pickUpGameObject;
        
        [NonSerialized] public Bounds BlackGroundBound;
        [NonSerialized] public SpaceShip SpaceShip;
        private Coroutine _coroutine;

        public int startGameTimeWait = 2;
        public List<Animator> animators;

        private static readonly int FadeOut = Animator.StringToHash("FadeOut");

        public List <TMP_Text> scoreAndWavText;
        private static readonly int AnimateSize = Animator.StringToHash("AnimateSize");

        [NonSerialized]public int WaveNumber;
        private int _waveCountDownStart;
        public int waveCountDown; 
     
        private GameManager _gameManager;
        void Start()
        {
            _waveCountDownStart = waveCountDown;
            _enemySpawner = EnemySpawner.Instance;
            
            WaveNumber = 2;
            isGameActive = false;
            _gameManager = GameManager.Instance;
            BlackGroundBound = spaceBackground.GetComponent<Renderer>().bounds;
            SpaceShip = spaceShipGameObject.GetComponent<SpaceShip>();
            
            _pickUpGameObject = transform.GetChild(0).gameObject;
            if (Instance != null) return;
            Instance = this;

            Invoke(nameof(StartGame), startGameTimeWait);
            Invoke(nameof(FinishTransition),startGameTimeWait);

            RepeatUntilGameEnds();
            
        }

        private void RepeatUntilGameEnds()
        {
            //Throw Shields and Upgrades all game
            InvokeRepeating(nameof(GivePowerUps), 10, 20);
            // Increase Difficulty of Waves
            InvokeRepeating(nameof(ChangeWaves), 4, 1);
            // Stop enemies from spawning last 3 seconds of everyBatch
        }
        
        private void ChangeWaves()
        {
            if (waveCountDown >= 0)
            {
                scoreAndWavText[2].SetText(""+waveCountDown);
                waveCountDown -= 1;
            }
            else
            {
                waveCountDown = _waveCountDownStart;
                scoreAndWavText[2].SetText(""+waveCountDown);
                scoreAndWavText[1].SetText(""+WaveNumber++);
                gameBackgroundSpeed = gameBackgroundSpeed + 3;
                if (_enemySpawner.maxSpawnRateInSeconds >= 0.4f)
                {
                    _enemySpawner.minSpawnRateInSeconds = _enemySpawner.minSpawnRateInSeconds - 0.3f;
                    _enemySpawner.maxSpawnRateInSeconds = _enemySpawner.maxSpawnRateInSeconds - 0.3f;
                }
                else
                {
                    _enemySpawner.minSpawnRateInSeconds = 0.1f;
                    _enemySpawner.maxSpawnRateInSeconds = 0.1f;
                }
            }

        }

        private void FinishTransition()
        {
            animators[1].SetTrigger(AnimateSize);
            isGameActive = true;
        }
        
        private void GivePowerUps()
        {
            _onePickupReadyGameObject = _pickUpGameObject.GetComponentsInChildren<Transform>(true)[1].gameObject;
            _onePickupReadyGameObject.SetActive(true);
            Invoke($"SetInactive", 10);
        }

        private void SetInactive()
        {
            if(_onePickupReadyGameObject!=null)_onePickupReadyGameObject.SetActive(false);
        }
        
        public void StartGame()
        {
            _enemySpawner.InitEnemySpawner();
        }

        public void UpdateScoreUI(int points)
        {
            _gameManager.Score += points;
            scoreAndWavText[0].SetText(""+_gameManager.Score);
        }

        public void GameIsOver()
        {
            if (isGameActive)
            {
                isGameActive = !isGameActive;
                _gameManager.SetFinalScore();
                transform.Find("GameOverVFX").gameObject.SetActive(true);
                Invoke(nameof(FadeTheScreen), 0.5f);
                Invoke(nameof(ToScoreScene), 5f);
            }

        }


        private void FadeTheScreen()
        {
            animators[0].SetTrigger(FadeOut);
        }
        private void ToScoreScene()
        {
            _gameManager.ChangeToNextScene();
        }
    }
}