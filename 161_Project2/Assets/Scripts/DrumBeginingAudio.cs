using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumBeginingAudio : MonoBehaviour {

	public AudioSource source;
	//public AudioClip intro, loop;

	private float waitSeconds = 5f;

	void Awake()
	{
	}


	void Update()
	{
		waitSeconds -= Time.deltaTime;
		if (waitSeconds <= 0 && !source.isPlaying)
		{
			source.Play();
		}
	}
}
