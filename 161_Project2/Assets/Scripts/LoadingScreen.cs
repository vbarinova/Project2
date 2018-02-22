using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public static bool GameStart;
    public GameObject Observer;

    // Use this for initialization
    void Awake()
    {
        GameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameStart = true;
            Observer.GetComponent<LevelManager>().MoveScene(1);
        }
    }
}
