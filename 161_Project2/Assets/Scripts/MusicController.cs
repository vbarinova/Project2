using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController instance = null;
    public AudioSource music;

    void Awake()
    {
        if (instance != null)
            { Destroy(gameObject); return; }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    void Update()
    {
        if (LoadingScreen.GameStart)
            music.Stop();
        else
            if (!music.isPlaying) music.Play();
    }

}