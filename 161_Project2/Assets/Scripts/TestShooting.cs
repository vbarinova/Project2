using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooting : MonoBehaviour {

	public GameObject m_BulletPrefab;

	private void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
		{
            Instantiate(m_BulletPrefab, transform.position, transform.rotation);
            
		}
	}
}
