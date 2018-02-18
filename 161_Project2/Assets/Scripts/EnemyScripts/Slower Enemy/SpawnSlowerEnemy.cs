using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlowerEnemy : MonoBehaviour {

	public GameObject m_SlowerEnemy;
	public float increaseDiffTimer = 20.0f;

	private GameObject thing;
	private WaveManager waves;

	private int currentwave;
	private float m_spawnTimer;
	private float m_range = 15;

	private void Awake()
	{
		//currentwave = WaveManager.wavemanager.currentWave ();
		thing = GameObject.Find ("Base");
		waves = thing.GetComponent<WaveManager> ();
		currentwave = waves.waveNumber;
	}

	private void Update()
	{
		if (currentwave > 2) {

			m_spawnTimer -= Time.deltaTime;
			if(m_spawnTimer <= 0)
			{
				/*
				// get random direction (360) in radians
				float angle = Random.Range(0.0f, Mathf.PI*2);

				// create a vecotr with length 1.0
				Vector3 Vec = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

				// Scale it to the desired length
				Vec *= m_range;

				// Spawn our new clone!
				Instantiate(m_Prefab, Vec, Quaternion.identity);

				m_spawnTimer = m_SpawnDelay;
				*/

				float lineX = Random.Range (-15.0f, 15.0f);
				float lineY = Random.Range (-7.0f, 7.0f);

				Vector3 Vec = new Vector3 (lineX, m_range, lineY);

				Instantiate (m_SlowerEnemy, Vec, Quaternion.identity);

				m_spawnTimer = Random.Range (2.0f, 10.0f);
			}

		}
		//currentwave = WaveManager.wavemanager.currentWave ();
		waves = thing.GetComponent<WaveManager> ();
		currentwave = waves.waveNumber;

	}

}
