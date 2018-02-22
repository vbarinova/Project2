using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlowerEnemy : MonoBehaviour {

	public GameObject m_SlowerEnemy;
	public float increaseDiffTimer = 30.0f;

	private GameObject thing;
	private WaveManager waves;

	private int currentwave;
	private float m_spawnTimer = 0;
	private float m_range = 20;

	private NumCurrentEnemies enemyCount;
	private GameObject thing2;

	private void Awake()
	{
		// in case of restart
		m_range = 20;

		//currentwave = WaveManager.wavemanager.currentWave ();
		thing = GameObject.Find ("Base");
		//waves = thing.GetComponent<WaveManager> ();
		currentwave = WaveManager.waveNumber;

		thing2 = GameObject.Find ("Base");
		enemyCount = thing2.GetComponent<NumCurrentEnemies> ();
	}

	private void Update()
	{
		if (WaveManager.waveNumber > 1 && !PlayerHealth.GameOver) {

			m_spawnTimer -= Time.deltaTime;
			increaseDiffTimer -= Time.deltaTime;
			if(m_spawnTimer <= 0 && enemyCount.keepSpawning())
			{
				
				float lineX = Random.Range (-15.0f, 15.0f);
				float lineY = Random.Range (-7.0f, 7.0f);

				Vector3 Vec = new Vector3 (lineX, m_range, lineY);

				Instantiate (m_SlowerEnemy, Vec, Quaternion.identity);

				m_spawnTimer = Random.Range (10.0f, 20.0f);

				enemyCount.hasSpawned ();
			}
			enemyCount = thing2.GetComponent<NumCurrentEnemies> ();

		}
		//currentwave = WaveManager.wavemanager.currentWave ();
		//waves = thing.GetComponent<WaveManager> ();
		//currentwave = WaveManager.waveNumber;

		if (increaseDiffTimer <= 0) {
			increaseDifficulty ();
			increaseDiffTimer = 30.0f;
		}

	}

	private void increaseDifficulty() {
		if (m_range > 15) m_range -= 1;
		Debug.Log ("increaseing Slow difficulty" + m_range);

	}

}
