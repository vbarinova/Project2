using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFasterEnemy : MonoBehaviour {

	public GameObject m_FasterEnemy;
	public float increaseDiffTimer = 30.0f;

	//private WaveManager waves;
	private GameObject thing;
	private WaveManager waves;

	private int currentwave;
	private float m_spawnTimer = 0;
	private float m_range = 30;

	private void Awake()
	{
		thing = GameObject.Find ("Base");
		waves = thing.GetComponent<WaveManager> ();
		currentwave = waves.waveNumber;
	}

	private void Update()
	{
		if (currentwave > 3) {
			
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

				Instantiate (m_FasterEnemy, Vec, Quaternion.identity);

				m_spawnTimer = Random.Range (8.0f, 30.0f);
			}
				
		}
		waves = thing.GetComponent<WaveManager> ();
		currentwave = waves.waveNumber;

		if (increaseDiffTimer <= 0) {
			increaseDifficulty ();
			increaseDiffTimer = 30.0f;
		}

	}

	private void increaseDifficulty() {
		if (m_range > 20) m_range -= 1;
		Debug.Log ("increaseing Fast difficulty" + m_range);

	}

}
