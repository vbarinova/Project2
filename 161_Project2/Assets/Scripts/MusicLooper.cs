using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{

    public AudioSource source;


    public AudioClip intro, loop;

    private bool isIntroPlaying;
    // Use this for initialization
    void Awake()
    {
        isIntroPlaying = true;
        source.loop = false;
        source.clip = intro;
        source.Play();
    }


    void Update()
    {
        if (isIntroPlaying && !source.isPlaying)
        {
            isIntroPlaying = false;
            source.loop = true;
            source.clip = loop;
            source.Play();
        }
    }
}