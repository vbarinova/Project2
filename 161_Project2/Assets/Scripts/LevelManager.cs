using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void MoveScene(int level)
    {
        Time.timeScale = 1f;
		ButtonSound.instance.Play ();
        SceneManager.LoadScene(level);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
            //Restart();
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
		ButtonSound.instance.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void GameOver()
    {
            PlayerHealth.GameOver = false;
            SceneManager.LoadScene(0);
    }

    public void ExitLevel()
    {
        LoadingScreen.GameStart = false; 
    }
}
