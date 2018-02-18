using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public static WaveManager wavemanager;

	private float waveLength = 30.0f;
	public int waveNumber = 0;
	private float waveTimer;

	private void Awake()
	{
		waveNumber = 0;
		waveTimer = waveLength;
	}
	
	private void Update()
	{
		waveTimer -= Time.deltaTime;
		if(waveTimer <= 0)
		{
			updateWave ();
			waveTimer = waveLength;
		}
			
	}

	private void updateWave() {
		++waveNumber;
		Debug.Log ("Next wave: " + waveNumber);
	}

	public int currentWave() {
		Debug.Log ("Current WaveNumber:" + waveNumber);
		return waveNumber;
	}

	/*
	public static WaveManager Instance() {
		if (!wavemanager) {
			wavemanager = FindObjectOfType (typeof(WaveManager)) as WaveManager;
			if (!wavemanager) {
				Debug.Log ("ISSUES HERE");
			}
		}

		return wavemanager;
	} */


}
