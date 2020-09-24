using _Scripts.FG.Managers_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.FG.Others
{
    public class ShowingScore : MonoBehaviour
    {
        public TMP_Text scoreText;
        public TMP_Text countdown;
        private int _timeCounter = 7;
        private GameManager _gameManager;
        // Start is called before the first frame update
        void Awake()
        {
            _gameManager = GameManager.Instance;
            scoreText.SetText("Your Score is " + _gameManager.Score + "\n Highest Score is " +_gameManager.GetHighestScore());
            InvokeRepeating(nameof(GOToMenu), 0,1f);
        }

        public void GOToMenu()
        {
            _timeCounter -= 1;
            countdown.SetText(""+_timeCounter);

            if (_timeCounter == 0)
            {
                // Change (0) .. To MainMenu Scene
                SceneManager.LoadScene(0);
            }
        }
    
    
    }
}
