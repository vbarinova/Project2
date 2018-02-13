using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour {

    public GameObject Main_Camera;

	private int playerVertSpeed = 8;
	private int playerHorSpeed = 35;
	private float moveY;
	private float moveX;

	public float yMax;
	public float yMin;


	private void Update() {
		Move ();
	}

	/*
	private void Move() {
		if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(Vector3.down * 50 * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(Vector3.up * 50 * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.UpArrow) && Main_Camera.transform.position.y <= 3)
		{
			Main_Camera.transform.Translate(Vector3.up * 0.05f);
		}
		else if (Input.GetKey(KeyCode.DownArrow) && Main_Camera.transform.position.y >= -3)
		{
			Main_Camera.transform.Translate(Vector3.down * 0.05f);
		}
	} */

	private void Move() 
	{
		moveY = Input.GetAxis("Vertical");
		moveX = Input.GetAxis ("Horizontal");

		//float x = Mathf.Clamp (moveX, yMin, yMax);
		//if (Input.GetAxis("Horizontal") > 0) { 
		//	transform.Rotate (Vector3.right * 30 * Time.deltaTime);
		//}
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, moveY * playerVertSpeed, 0);

		transform.Rotate (0, moveX * playerHorSpeed * Time.deltaTime, 0);
	}

}
