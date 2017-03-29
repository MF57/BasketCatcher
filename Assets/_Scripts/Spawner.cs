using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Primitive[] primitivePrefabs;
	public int spawnInterval;
	public int nowePole;
	public Vector2 spawnRange;


	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnRandomObject(spawnInterval));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnRandomObject(float delay) {
		while (true) {
			int randomPrefab = Random.RandomRange (0, primitivePrefabs.Length);
			Primitive prefab = primitivePrefabs [randomPrefab];

			int randomX = Random.RandomRange (0, 5);
			int randomZ  = Random.RandomRange (0, 5);

			Vector3 basePosition = new Vector3 (0, 10, 0);
			Vector3 randomOffsetVector = new Vector3 (Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ));
			Instantiate (prefab, basePosition + randomOffsetVector, Random.rotation);
				
			yield return new WaitForSeconds(delay);
		}
	}
}
