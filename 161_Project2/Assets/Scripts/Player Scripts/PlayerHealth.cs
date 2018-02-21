using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int m_Health = 20;
    public static bool GameOver = false;
	public Slider HealthSlider;

	private void Update() {
        if (GameOver)
            LevelManager.GameOver();
	}

	private void OnTriggerEnter (Collider other)  // Trigger function, the collider is the bullet
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy (other.gameObject);
			if (--m_Health <= 0) {
                //Destroy (this.gameObject);
                Debug.Log("Player is dead");
                GameOver = true;
                LoadingScreen.GameStart = false;
			}
            HealthSlider.value = 1f * (m_Health/20f);
		}
	}
}
