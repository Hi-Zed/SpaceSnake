using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	private Rigidbody playerRigidbody;
	private Vector3 direction;
	private Quaternion orientation;
	private float nextFire;
	private List<GameObject> bodyParts;

	public ParticleSystem[] engines;
	public float speed;
	public GameObject shot;
	public GameObject bodyPart;
	public Transform spawnShots;
	public Transform spawnBody;
	public float fireRate;

	// Use this for initialization
	void Start () {
		bodyParts = new List<GameObject> ();
		playerRigidbody = gameObject.GetComponent<Rigidbody> ();
		direction = new Vector3 ();
		orientation = new Quaternion ();
		playerRigidbody.velocity = direction * speed;
		nextFire = 0.0f;
	}

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject bolt = Instantiate (shot, spawnShots.position, spawnShots.rotation) as GameObject;
			bolt.GetComponent<Transform> ().rotation = orientation;
		}
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
		foreach (ParticleSystem e in engines) {
			var main = e.main;
			main.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "pickUp") {
			bodyParts.Add(Instantiate(bodyPart, spawnBody) as GameObject);
		}
	}
}
