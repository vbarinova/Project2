using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public static WaveManager wavemanager;
	public GameObject WaveDisplay;
	public int waveNumber = 0;

	private float waveLength = 30.0f;
	private float waveTimer;

	private void Awake()
	{
		waveNumber = 0;
		waveTimer = waveLength;
		DisableWave (); // initially do not display
	}
	
	private void Update()
	{
		waveTimer -= Time.deltaTime;
		if(waveTimer <= 0)
		{
			updateWave ();
			displayWave ();
			waveTimer = waveLength;
		}
			
	}

	private void updateWave() {
		++waveNumber;
		Debug.Log ("Next wave: " + waveNumber);
	}

	private void displayWave() {
		WaveDisplay.gameObject.GetComponent<Text> ().text = "W A V E  " + waveNumber;
		WaveDisplay.SetActive (true);
		Invoke ("DisableWave", 3.0f);
	}

	private void DisableWave()
	{
		WaveDisplay.SetActive (false);
	}

	public int currentWave() {
		Debug.Log ("Current WaveNumber:" + waveNumber);
		return waveNumber;
	}


}
