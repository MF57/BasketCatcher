using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

	public float speed;
	public Vector2 movementRange;
	private ScoreManager scoreManager;
	public ParticleSystem particleSystem;


	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
			
	}

	// Update is called once per frame
	void Update () {
		float ix = Input.GetAxis("Horizontal");
		float iz = Input.GetAxis("Vertical");
		float dt = Time.deltaTime;
		var pos = transform.position;
		Vector3 v = new Vector3 (ix * dt * speed, 0, iz * dt * speed);
		transform.position = pos+v;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -movementRange.x, movementRange.x), 0,
			Mathf.Clamp(transform.position.z, -movementRange.y, movementRange.y));

	}

	void OnTriggerEnter(Collider other) {
		Primitive primitive = other.GetComponent<Primitive> ();
		if (primitive == null) {
			Debug.Log("Could not find primitive");
			return;
		}
		scoreManager.AddPoints (primitive.GetPoints ());
		Debug.Log ("Dodano punktow: " + primitive.GetPoints ());
		var fx = Instantiate (particleSystem, other.gameObject.transform.position, Quaternion.Euler(-90,0,0));
		Destroy (other);
		Destroy (fx.gameObject, 3);
		Debug.Log ("OBIEKT SIE POWINIEN USUNAC");
			

	}
}
