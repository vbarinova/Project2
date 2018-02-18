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

	private void Awake() {
		// Get sounds
		source = GetComponent<AudioSource> ();
        ShootCount = 0;
        bulletCounter.gameObject.GetComponent<Text>().text = "Ammo: " + (int)(5 - ShootCount);
    }

	private void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
        if (!PauseMenu.isPaused && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && ShootCount <= 4)
		{
            ++ShootCount;
            bulletCounter.gameObject.GetComponent<Text>().text = "Ammo: " + (int)(5 - ShootCount);
            source.PlayOneShot (shootSound, .5f);
            Instantiate(m_BulletPrefab, transform.position, transform.rotation);

            
            
		}
	}
}
