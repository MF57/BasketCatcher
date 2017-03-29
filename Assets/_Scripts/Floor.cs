using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Floor : MonoBehaviour {

	public ParticleSystem particleSystem;
	private int destroyed;
	public string mainMenuScene;

	// Use this for initialization
	void Start () {
		destroyed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		var fx = Instantiate (particleSystem, col.gameObject.transform.position, Quaternion.Euler(-90,0,0));
		Destroy (col.gameObject);
		Destroy (fx.gameObject, 3);
		destroyed += 1;
		if (destroyed >= 10) {
			SceneManager.LoadScene(mainMenuScene);
		}
			
	}
}
