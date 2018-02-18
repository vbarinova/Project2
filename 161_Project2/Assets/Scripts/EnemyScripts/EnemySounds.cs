using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour {

	public AudioClip deathSound;
	public AudioClip suicideSound;
	public static EnemySounds enemySounds;

	private AudioSource deathSource;
	private AudioSource suicideSource;
	private AudioSource[] aSources;

	// Use this for initialization
	void Awake () {
		enemySounds = this;

		// Get sounds
		aSources = GetComponents<AudioSource>();
		deathSource = aSources[0];
		suicideSource = aSources[1];
		
	}

	public void playDeath() {
		deathSource.PlayOneShot (deathSound, .3f);
	}

	public void playSuicide() {
		suicideSource.PlayOneShot (suicideSound, .3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
