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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
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
