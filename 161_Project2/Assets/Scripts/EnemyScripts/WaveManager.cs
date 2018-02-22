using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public static WaveManager wavemanager;
	public GameObject WaveDisplay;
	public GameObject SurviveWaves;
	public static int waveNumber = 0;

	private float waveLength = 30.0f;
	private float waveTimer;

	private int numEnemies;
	private NumCurrentEnemies enemyCount;
	private GameObject thing;


	private void Awake()
	{
		waveNumber = 0;
		waveTimer = waveLength;
		InitialWaveDisplay ();
		//DisableWave (); // initially do not display

		thing = GameObject.Find ("Base");
		enemyCount = thing.GetComponent<NumCurrentEnemies> ();
		//numEnemies = enemyCount.currentNum();
	}
	
	private void Update()
	{
		waveTimer -= Time.deltaTime;
        //if (numEnemies <= 0) enemyCount.resetCounter();


		if(waveTimer <= 0 && enemyCount.nextWave())
		{
			updateWave ();
			displayWave ();
			waveTimer = waveLength;
			//Invoke("enemyCount.resetCounter", 3f);
			StartCoroutine(pauseBeforeNextWave());
		}

		enemyCount = thing.GetComponent<NumCurrentEnemies> ();
		//numEnemies = enemyCount.currentNum();
			
	}

	private void updateWave() {
		++waveNumber;
		Debug.Log ("Next wave: " + waveNumber);
	}

	private void InitialWaveDisplay() {
		// Display Survive 10 waves
		SurviveWaves.SetActive (true);
		WaveDisplay.SetActive (false);
		StartCoroutine(pauseStart());

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

	IEnumerator pauseBeforeNextWave() {
		Debug.Log ("Pausing before next wave");

		yield return new WaitForSeconds (3f);
		enemyCount.resetCounter ();
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
