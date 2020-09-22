using System;
using _Scripts.FG.NPC;
using _Scripts.FG.NPC.HealthBar;
using _Scripts.FG.Player;
using UnityEngine;

namespace _Scripts.FG.Managers_Scripts
{
    public class SpaceManager : MonoBehaviour
    {
        public enum Edges
        {
            Left = -140,
            Right = 43,
            Top = 34,
            Bottom = -34
        }

        public static SpaceManager Instance = null;
        public UnityEngine.Camera mainCamera = null;
        public GameObject spaceBackground = null;
        public float gameBackgroundSpeed = 1.0f;
        public GameObject healthBarGameObject;
        public GameObject spaceShipGameObject;
        public GameObject playerShield;
        private GameObject _onePickupReadyGameObject;
        private GameObject _pickUpGameObject;
        [NonSerialized] public Bounds blackGroundBound;
        [NonSerialized] public HealthBar healthBar;
        [NonSerialized] public SpaceShip spaceShip;


        void Start()
        {
            healthBar = healthBarGameObject.GetComponent<HealthBar>();
            blackGroundBound = spaceBackground.GetComponent<Renderer>().bounds;
            spaceShip = spaceShipGameObject.GetComponent<SpaceShip>();
            _pickUpGameObject = transform.GetChild(0).gameObject;
            if (Instance != null) return;
            Instance = this;
            Invoke(nameof(StartGame), 1f);
            InvokeRepeating(nameof(GivePowerUps), 3, 20);
        }

        private void GivePowerUps()
        {
            _onePickupReadyGameObject = _pickUpGameObject.GetComponentsInChildren<Transform>(true)[1].gameObject;
            _onePickupReadyGameObject.SetActive(true);
            Invoke($"SetInactive", 10);
        }

        private void SetInactive()
        {
            if (_onePickupReadyGameObject != null) _onePickupReadyGameObject.SetActive(false);
        }

        public void StartGame()
        {
            EnemySpawner.Instance.InitEnemySpawner();
        }
    }
}