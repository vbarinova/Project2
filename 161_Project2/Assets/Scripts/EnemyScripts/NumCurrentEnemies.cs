using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumCurrentEnemies : MonoBehaviour {

	public static NumCurrentEnemies numcurrentEnemies;
	public GameObject enemyDisplay;

	private int numEnemiesSpawned = 5;
	private int numEnemiesDefeated = 5;
	private int plusEnemies = 0;
	//private bool spawn = true;

	// Use this for initialization
	void Start () {
		enemyDisplay.gameObject.GetComponent<Text>().text = "[ " + numEnemiesDefeated + " ]";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	public void incrementEnemies() {
		++numEnemies;
		Debug.Log ("Increasing enemies on screen " + numEnemies);
	} */

	public void decrementEnemies() {
		--numEnemiesDefeated;
		enemyDisplay.gameObject.GetComponent<Text>().text = "[ " + numEnemiesDefeated + " ]";
		//Debug.Log ("Enemies left to defeat " + numEnemiesDefeated);
	}

	public void hasSpawned() {
		--numEnemiesSpawned;
		Debug.Log (numEnemiesSpawned + " enemies left to spawn");
	}

	public void resetCounter() {
		plusEnemies += 2;
		numEnemiesDefeated = 5 + plusEnemies;
		numEnemiesSpawned = 5 + plusEnemies;
		enemyDisplay.gameObject.GetComponent<Text>().text = "[ " + numEnemiesDefeated + " ]";
	}
	/*
	public int currentNum() {
		return numEnemies;
	} */

	public bool keepSpawning() {
		if (numEnemiesSpawned <= 0)
			return false;
		else
			return true;
		// return spawn;
	}

	public bool nextWave() {
		if (numEnemiesSpawned <= 0 && numEnemiesSpawned == numEnemiesDefeated)
			return true;
		else
			return false;
	}
}
