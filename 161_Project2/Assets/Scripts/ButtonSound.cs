using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

	public static ButtonSound instance = null;
	//public static ButtonSound buttonSound;
	public AudioClip buttonClick;

	private AudioSource source;

	// Use this for initialization
	void Awake () {
		if (instance != null)
		{ Destroy(gameObject); return; }
		else
		{
			source = GetComponent<AudioSource> ();
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	

	public void Play() {
		source.PlayOneShot (buttonClick, 1f);
	}
}
