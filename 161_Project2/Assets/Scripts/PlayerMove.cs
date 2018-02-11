using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject Main_Camera;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
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

    }

}
