using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{

    public GameObject gameOverUI, gameWinUI;
    public Text scoretxt;

    private int lvl;

    private void Awake()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    void Update()
    {
        CheckGame();
    }

    void CheckGame()
    {
        if (PlayerHealth.GameOver)
        {
            Time.timeScale = 0f;
            GameOverScreen();
            Debug.Log("Game Over");
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1f;
                LoadingScreen.GameStart = false;
                GoBackToStart();
            }
        }
        else if (WaveManager.waveNumber >= 12)  // 12
        {
            Time.timeScale = 0f;
            gameWinUI.SetActive(true);
            Debug.Log("Game Win");
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1f;
                LoadingScreen.GameStart = false;
                GoBackToStart();
                
            }
        }
    }



    void GameOverScreen()
    {
        scoretxt.text = "On Wave " +  WaveManager.waveNumber.ToString() + ", the final frontier \nhas been destroyed.";
        gameOverUI.SetActive(true);
    }

    void GoBackToStart()
    {
        PlayerHealth.GameOver = false;
        LevelManager.GameOver();
    }

}