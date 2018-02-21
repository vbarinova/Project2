using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {


    public GameObject m_PauseMenu;
    public AudioSource m_AudioControl;

    public static bool isPaused;
	// Use this for initialization
	void Start () {
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
	}

    void Resume()
    {
        m_PauseMenu.SetActive(false);
        m_AudioControl.GetComponent<AudioHighPassFilter>().enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        m_PauseMenu.SetActive(true);
        m_AudioControl.GetComponent<AudioHighPassFilter>().enabled = true;
        Time.timeScale = 0f;
        isPaused = true;
    }
}
