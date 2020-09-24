using _Scripts.FG.Managers_Scripts;
using UnityEngine;

namespace _Scripts.FG.Others
{
    public class ControlMenuUI : MonoBehaviour
    {
        private GameManager _gameManager;
        public GameObject musicOn;
        public GameObject musicOff;

        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameManager.Instance;
            int musicState = PlayerPrefs.GetInt("Music", 1);
            if (musicState == 1)
            {
                musicOn.SetActive(true);
                musicOff.SetActive(false);
                TurnMusic(true);
            }
            else
            {
                musicOn.SetActive(false);
                musicOff.SetActive(true);
                TurnMusic(false);
            }
        }


        public void TurnMusic(bool state)
        {
            if (_gameManager.MusicAudioSource == null) return;
            if (state is true) 
                _gameManager.MusicAudioSource.Play();
            else _gameManager.MusicAudioSource.Pause();
            PlayerPrefs.SetInt("Music",state?1:0);
        }

        public void NextScene()
        {
            _gameManager.ChangeToNextScene();
        }
    
    }
}
