using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNormalEnemy : MonoBehaviour {

	public GameObject m_NormalEnemy;

	public float increaseDiffTimer = 20.0f;

	private float m_SpawnDelay = 5.5f;
	private float m_spawnTimer;

	private float m_range = 20;

	private NumCurrentEnemies enemyCount;
	private GameObject thing2;

	private void Awake()
	{
		// in case of restart
		m_range = 20;
		m_SpawnDelay = 5.5f;

		m_spawnTimer = m_SpawnDelay;

		thing2 = GameObject.Find ("Base");
		enemyCount = thing2.GetComponent<NumCurrentEnemies> ();
	}

	private void Update()
	{
		m_spawnTimer -= Time.deltaTime;
		increaseDiffTimer -= Time.deltaTime;
		if(m_spawnTimer <= 0 && enemyCount.keepSpawning())
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

			Instantiate (m_NormalEnemy, Vec, Quaternion.identity);

			m_spawnTimer = m_SpawnDelay;

			enemyCount.hasSpawned ();
		}

		enemyCount = thing2.GetComponent<NumCurrentEnemies> ();

		if (increaseDiffTimer <= 0) {
			increaseDifficulty ();
			increaseDiffTimer = 20.0f;
		}
	}

	private void increaseDifficulty() {
		// Doesn't start lowering spwan rate untill distance is lowered
		if (m_SpawnDelay > 4.0f ) m_SpawnDelay -= 0.1f;
		//if (m_range <= 10 && m_SpawnDelay > 4.0f ) m_SpawnDelay -= 0.1f;
		//if (m_range > 10) m_range -= 2;
		Debug.Log ("increaseing difficulty" + m_SpawnDelay + " " + m_range);

	}
		
}
