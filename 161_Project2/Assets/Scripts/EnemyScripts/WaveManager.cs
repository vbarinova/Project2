using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public static WaveManager wavemanager;
	public GameObject WaveDisplay;
	public GameObject SurviveWaves;
	public int waveNumber = 0;

	private float waveLength = 30.0f;
	private float waveTimer;

	private void Awake()
	{
		waveNumber = 0;
		waveTimer = waveLength;
		InitialWaveDisplay ();
		//DisableWave (); // initially do not display
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

	private void InitialWaveDisplay() {
		// Display Survive 10 waves
		SurviveWaves.SetActive (true);
		WaveDisplay.SetActive (false);
		//Invoke ("InitialDisableWaves", 3.0f);
		StartCoroutine(pauseStart());
		// Update waves display and show it
		//WaveDisplay.gameObject.GetComponent<Text> ().text = "W A V E  " + (waveNumber+1);
		//WaveDisplay.SetActive (true);
		//Invoke ("DisableWave", 3.0f);
		//Invoke ("InitialDisableWaves", 3.0f);

	}

	IEnumerator pauseStart() {
		Debug.Log ("Display Start stuff, pausing for 3 sec");

		yield return new WaitForSeconds (3f);
		SurviveWaves.SetActive (false);
		WaveDisplay.gameObject.GetComponent<Text> ().text = "W A V E  " + (waveNumber+1);
		WaveDisplay.SetActive (true);
		//Invoke ("DisableWave", 3.0f);
		Invoke ("DisableWave", 2.3f);
	}

	private void InitialDisableWaves() {
		SurviveWaves.SetActive (false);
	}

	private void displayWave() {
		WaveDisplay.gameObject.GetComponent<Text> ().text = "W A V E  " + (waveNumber+1);
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
