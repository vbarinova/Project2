using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

	public float m_Speed = 15f;

	private Rigidbody m_Rigidbody;

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();

		Invoke ("DestorySelf", 4.0f); // Invoke calls a function after an alotted time
	}

	private void FixedUpdate()
	{
		m_Rigidbody.MovePosition(m_Rigidbody.position + transform.up * m_Speed * Time.deltaTime); // Need to mult by Time.deltaTime so that the update is not dependednt
		// on the frame rate of the computer, but rather dependednt on time
	}

	private void DestorySelf()
	{
		Destroy (gameObject);
	}
	/*
	private void OnTriggerEnter (Collider other)  // Trigger function, the collider is the bullet
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy (this.gameObject);
		}
	}*/
}
