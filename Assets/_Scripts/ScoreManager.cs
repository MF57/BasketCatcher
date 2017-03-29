using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private int totalScore;
	public event System.Action<int> scoreUpdatedEvent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPoints(int points) {
		totalScore = totalScore + points;
		if (scoreUpdatedEvent != null) {
			scoreUpdatedEvent (totalScore);
		}
	}

	public int GetPoints() {
		return totalScore;
	}
}
