using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalEnemy_Movement : MonoBehaviour {

	public int m_Health = 3;
	public float m_Speed = 4.5f;

	private GameObject m_player;
	private Rigidbody m_rigidbody;

	// Use this for initialization
	void Awake () {
		m_player = GameObject.FindGameObjectWithTag("Player");  // But where the camera is? nurr, just the level it is on
		m_rigidbody = GetComponent<Rigidbody> ();
        transform.position = new Vector3(transform.position.x, Random.Range(-3f, 3f), transform.position.y);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 delta = m_player.transform.position - transform.position;
		Vector3 movement = delta.normalized * m_Speed * Time.deltaTime;
		m_rigidbody.MovePosition (m_rigidbody.position + movement);

		
	}

	private void OnTriggerEnter (Collider other)  // Trigger function, the collider is the bullet
	{
		// To tell the difference between the different objects that can collied use tags
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Hit Player, health should go down");
			// Kamakazi style
			Destroy (this.gameObject);
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);  // only one index, so defautl
		} 
		else if (other.gameObject.tag == "Bullet") 
		{
			Destroy (other.gameObject);
			if (--m_Health <= 0) {
				Destroy (this.gameObject);
			}
		}
	}

}
