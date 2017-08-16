using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalController : MonoBehaviour {

	private Rigidbody rb;

	public GameObject glow;
	public float tumble;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "bolt")
			Destroy (other.gameObject);

		if (other.gameObject.tag == "Player") {
			Instantiate (glow, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
