using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class HUD : MonoBehaviour {

	public Text scoreLabel;
	private ScoreManager scoreManager;
	public string menuSceneName;
	public Button backToMenuButton;
	public PunchTweener tweener; // refka na klasę bazową


	// Use this for initialization
	void Start () {
		DOTween.Init ();
		backToMenuButton.onClick.AddListener(BackToMenuButtonHandler);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UpdateScore(int score) {
		scoreLabel.text = "Score: " + score.ToString ();
		if (tweener)
			tweener.Tween(scoreLabel.transform);
	}

	void Awake() {
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}

	void OnEnable() {
		scoreManager.scoreUpdatedEvent += UpdateScore;
	
		UpdateScore(scoreManager.GetPoints());
	}

	void onDisable() {
		scoreManager.scoreUpdatedEvent -= UpdateScore;
	}

	void BackToMenuButtonHandler() {
		SceneManager.LoadScene(menuSceneName);
	}
}
