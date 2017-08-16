using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour {

	private Rigidbody rb;
	private int health;

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject crystal;
	public float tumble;

	// Use this for initialization
	void Start () {
		health = 3;
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "bolt") {
			Destroy (other.gameObject);
			health--;
			if (health <= 0) {
				Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);
				Instantiate (crystal, gameObject.transform.position, Random.rotation); 
				Destroy (gameObject);
			}
		}

		if (other.gameObject.tag == "Player") {
			Instantiate(playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
			Destroy (other.gameObject);
		}
	}
}
