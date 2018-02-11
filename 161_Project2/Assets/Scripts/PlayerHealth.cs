using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int m_Health = 20;

	private void OnTriggerEnter (Collider other)  // Trigger function, the collider is the bullet
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy (other.gameObject);
			if (--m_Health <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
