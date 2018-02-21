using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestShooting : MonoBehaviour {

	public GameObject m_BulletPrefab;
    public GameObject bulletCounter;
    public AudioClip shootSound;
    public static int ShootCount;

	private AudioSource source;
	private int ammoCount = 6;

	private void Awake() {
		// Get sounds
		source = GetComponent<AudioSource> ();
        ShootCount = 0;
		bulletCounter.gameObject.GetComponent<Text>().text = "Ammo: " + (int)(ammoCount - ShootCount);
    }

	private void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
		if (!PauseMenu.isPaused && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && ShootCount <= ammoCount-1)
		{
            ++ShootCount;
			bulletCounter.gameObject.GetComponent<Text>().text = "Ammo: " + (int)(ammoCount - ShootCount);
            source.PlayOneShot (shootSound, .3f);
            Instantiate(m_BulletPrefab, transform.position, transform.rotation);

            
            
		}
	}
}
