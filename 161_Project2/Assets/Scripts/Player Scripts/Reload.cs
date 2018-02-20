using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Reload : MonoBehaviour {

    
    public GameObject bulletCounter;
    public AudioClip reloadSound;

    private AudioSource source;
    private bool isEmpty, reloading;
	private int ammoCount = 6;

    // Use this for initialization
    void Awake () {
        isEmpty = false;
        reloading = false;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

		if (TestShooting.ShootCount >= ammoCount && !isEmpty)
        {
            isEmpty = true;
        }
        if (isEmpty && !reloading)
        {
            reloading = true;
            Invoke("Reloading", 1f);
        }
		
	}

    void Reloading()
    {
        
        TestShooting.ShootCount = 0;
		bulletCounter.gameObject.GetComponent<Text>().text = "Ammo: " + (int)(ammoCount - TestShooting.ShootCount);
        isEmpty = false;
        reloading = false;
        source.PlayOneShot(reloadSound, .5f);

    }
}
