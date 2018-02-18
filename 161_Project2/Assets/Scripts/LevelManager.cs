using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void MoveScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void GameOver()
    {
        if (PlayerHealth.GameOver)
        {
            PlayerHealth.GameOver = false;
            SceneManager.LoadScene(0);
        }
            
    }
}
