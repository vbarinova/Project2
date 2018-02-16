using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooting : MonoBehaviour {

	public GameObject m_BulletPrefab;
	public AudioClip shootSound;

	private AudioSource source;

	private void Awake() {
		// Get sounds
		source = GetComponent<AudioSource> ();
	}

	private void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
		{
			source.PlayOneShot (shootSound, .5f);
            Instantiate(m_BulletPrefab, transform.position, transform.rotation);
            
		}
	}
}
