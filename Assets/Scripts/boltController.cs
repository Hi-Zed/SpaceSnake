using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltController : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 direction;

	public float speed;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		float angle;
		Vector3 axis;
		transform.rotation.ToAngleAxis (out angle, out axis);
		angle = angle * axis.y;
		if (angle >= 89.0f && angle <= 91.0f)
			direction.Set (1.0f, 0.0f, 0.0f);
		if (angle <= -89.0f && angle >= -91.0f)
			direction.Set (-1.0f, 0.0f, 0.0f);
		if (angle == 0.0f)
			direction.Set (0.0f, 0.0f, 1.0f);
		if (angle == 180.0f)
			direction.Set (0.0f, 0.0f, -1.0f);
	}

	void FixedUpdate () {
		rb.velocity = direction * speed * 2;
	}
}
