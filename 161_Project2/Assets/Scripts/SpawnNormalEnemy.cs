﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNormalEnemy : MonoBehaviour {

	public GameObject m_Prefab;
	public float m_SpawnDelay = 2.5f;
	public float m_range = 30;

	private float m_spawnTimer;

	private void Awake()
	{
		m_spawnTimer = m_SpawnDelay;
	}

	private void Update()
	{
		m_spawnTimer -= Time.deltaTime;
		if(m_spawnTimer <= 0)
		{

			// get random direction (360) in radians
			float angle = Random.Range(0.0f, Mathf.PI*2);

			// create a vecotr with length 1.0
			Vector3 Vec = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

			// Scale it to the desired length
			Vec *= m_range;

			/*
			// We want to spawn the clone at the edge of the screen.
			// Let's construct a spawn position using Viewport Space [(0,0),(1,1)]
			// and transform it to the clone's initial world position.

			// Determine which edge we want to spawn the Zombie against.
			bool useHorizontalEdge = (Random.Range(0, 2) == 0); // Horizontal or vertical edge?
			bool usePositiveEdge = (Random.Range(0, 2) == 0); // Positive or negative edge?
			float chosenEdgePosition = Random.Range(0f, 1f); // What position along that edge?

			// Construct our Viewport Coordinates from our edge values.
			float otherEdgePosition = usePositiveEdge ? 1f : 0f;
			float xVP = useHorizontalEdge ? chosenEdgePosition : otherEdgePosition;
			float yVP = useHorizontalEdge ? otherEdgePosition : chosenEdgePosition;


			// TODO factor in the renderer bounds of the clone
			// so we can start it completely offscreen instead
			// of right at edge of the screen.

			// Transform our Viewport Coordinates into World Space
			Vector3 posWS = Camera.main.ViewportToWorldPoint(new Vector3(xVP, yVP, 0f));
			posWS.z = 0;

			*/

			// Spawn our new clone!
			Instantiate(m_Prefab, Vec, Quaternion.identity);

			m_spawnTimer = m_SpawnDelay;
		}
	}
}
