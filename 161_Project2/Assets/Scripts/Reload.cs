using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Reload : MonoBehaviour {

    
    public Slider bulletCounter;
    public AudioClip reloadSound;

    private AudioSource source;
    private bool isEmpty, reloading;

    // Use this for initialization
    void Awake () {
        isEmpty = false;
        reloading = false;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        bulletCounter.value = 1 - TestShooting.ShootCount*0.2f;
        if (TestShooting.ShootCount >= 5 && !isEmpty)
        {
            isEmpty = true;
        }
        if (isEmpty && !reloading)
        {
            reloading = true;
            Invoke("Reloading", 2f);
        }
		
	}

    void Reloading()
    {

        bulletCounter.value = 1f;
        TestShooting.ShootCount = 0;
        isEmpty = false;
        reloading = false;
        source.PlayOneShot(reloadSound, .5f);

    }
}
