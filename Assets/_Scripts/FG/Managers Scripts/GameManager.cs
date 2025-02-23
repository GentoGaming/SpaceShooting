﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.FG.Managers_Scripts
{
    [RequireComponent(typeof(AudioSource))]

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;
        [NonSerialized] public AudioSource MusicAudioSource;
        public int Score { set; get; }

        void Start()
        {
            if (Instance != null) return;
            Instance = this;
            Score = 0;
            MusicAudioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(this.gameObject);
            ChangeToNextScene();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    
 


        public void SetFinalScore()
    
        {
            if (GetHighestScore() < Score)
            {
                PlayerPrefs.SetInt("HighestScore", Score);
            }
        }
    
        public int GetHighestScore()
        {
            return  PlayerPrefs.GetInt("HighestScore", 0);
        }
    
        public void ChangeToNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
