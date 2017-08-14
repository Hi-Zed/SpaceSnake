using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	private Rigidbody playerRigidbody;
	private Vector3 direction;
	private Quaternion orientation;

	public float speed;

	// Use this for initialization
	void Start () {
		playerRigidbody = gameObject.GetComponent<Rigidbody> ();
		direction = new Vector3 ();
		orientation = new Quaternion ();
		playerRigidbody.velocity = direction * speed;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		if (moveHorizontal > 0.0f) {
			direction.Set (1.0f, 0.0f, 0.0f);
			orientation.eulerAngles = new Vector3 (0.0f, 90.0f, 0.0f);
		}
		if (moveHorizontal < 0.0f) {
			direction.Set (-1.0f, 0.0f, 0.0f);
			orientation.eulerAngles = new Vector3 (0.0f, -90.0f, 0.0f);
		}
		if (moveVertical > 0.0f) {
			direction.Set (0.0f, 0.0f, 1.0f);
			orientation.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
		}
		if (moveVertical < 0.0f) {
			direction.Set (0.0f, 0.0f, -1.0f);
			orientation.eulerAngles = new Vector3 (0.0f, 180.0f, 0.0f);
		}

		playerRigidbody.velocity = direction * speed;
		gameObject.transform.rotation = orientation;
//
//		for (int i = 1; i < transform.childCount; i++) {
//			Rigidbody bodyRigidbody = transform.GetChild (i).gameObject.GetComponent<Rigidbody> ();
//			Vector3 follow = transform.GetChild (i - 1).position - transform.GetChild (i).position;
//			if (follow.magnitude > 1.1f)
//				bodyRigidbody.velocity = follow * speed * 0.75f;
//		}
	}
}
