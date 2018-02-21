using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalEnemy_Movement : MonoBehaviour {

	public int m_Health = 3;
	public float m_Speed = 2.5f;
	public AudioClip deathSound;
	public AudioClip suicideSound;

	public Renderer rend;
	public Color normalColor = new Color (1f,0.168f,0.427f);
	public Color hitColor = new Color (1f, 0.529f, 0.674f);

	private GameObject m_player;
	private Rigidbody m_rigidbody;

	private NumCurrentEnemies enemyCount;
	private GameObject thing2;

	// Use this for initialization
	void Awake () {
		m_player = GameObject.FindGameObjectWithTag("Player");  // But where the camera is? nurr, just the level it is on
		m_rigidbody = GetComponent<Rigidbody> ();
        transform.position = new Vector3(transform.position.x, Random.Range(-3f, 3f), transform.position.y);
	
		// So can access public enemy counter
		thing2 = GameObject.Find ("Base");
		enemyCount = thing2.GetComponent<NumCurrentEnemies> ();

		// find renderer and set the og color
		rend = GetComponent<Renderer>();
		rend.material.color = normalColor;

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
			//suicideSource.PlayOneShot (suicideSound, .5f);
			enemyCount.decrementEnemies ();
			EnemySounds.enemySounds.playSuicide();
			Destroy (this.gameObject);
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);  // only one index, so defautl
		} 
		else if (other.gameObject.tag == "Bullet") 
		{
			Destroy (other.gameObject);
			//rend.material.shader = hitShader;
			StartCoroutine(getHit());
			if (--m_Health <= 0) {
				//deathSource.PlayOneShot (deathSound, .5f);
				enemyCount.decrementEnemies ();
				EnemySounds.enemySounds.playDeath();
				Destroy (this.gameObject);
			}
		}
	}

	IEnumerator getHit() {
		Debug.Log ("Oh gosh hit");
		rend.material.color = hitColor;
		yield return new WaitForSeconds (0.1f);
		rend.material.color = normalColor;
		Debug.Log ("lol done being hit");
	}

}
