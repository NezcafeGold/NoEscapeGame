using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public GameObject pauseUI;
    private bool onPause = false;
    

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (onPause)
                {
                    Resume();
                } else if (!onPause)
                {
                    Pause();
                }
            }
        }
    }

     void StartGameScene()
    {
        SceneManager.LoadScene("Game");
    }

     void Pause()
     {
         onPause = true;
         pauseUI.SetActive(true);
         Time.timeScale = 0f;
     }

        public void Resume()
     {
         onPause = false;
         pauseUI.SetActive(false);
         Time.timeScale = 1f;
     }
}
