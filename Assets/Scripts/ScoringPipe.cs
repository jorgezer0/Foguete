using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPipe : MonoBehaviour {

	private ScoreManager scoreManager;

	void Start(){
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Player")){
			scoreManager.AddScore(1);
		}
	}
}
