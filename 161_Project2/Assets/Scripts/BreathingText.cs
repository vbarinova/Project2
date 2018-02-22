using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingText : MonoBehaviour {

	public float maxSize;
	public float growFactor;
	public float waitTime;

	private void Start() {
		StartCoroutine (Scale ());
	}

	IEnumerator Scale() {
		float timer = 0;
		while (true) {
			// Scale  to max value
			while (maxSize > transform.localScale.x) {
				timer += Time.deltaTime;
				transform.localScale += new Vector3 (0.02579f, 0.02579f, 0) * Time.deltaTime * growFactor;
				yield return null;
			}
			// reset timer

			yield return new WaitForSeconds (waitTime);

			timer = 0;
			while (0.02579 < transform.localScale.x) {
				timer += Time.deltaTime;
				transform.localScale -= new Vector3 (0.02579f, 0.02579f, 0) * Time.deltaTime * growFactor;
				yield return null;
			}

			timer = 0;
			yield return new WaitForSeconds (waitTime);
		}
	}
		
}
