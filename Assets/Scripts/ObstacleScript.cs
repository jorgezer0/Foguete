using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

	public float obsVelocity;
	public float resetPosPoint;

	public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		SetObsPos ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * obsVelocity * Time.deltaTime;

		if (Camera.main.WorldToViewportPoint (transform.position).x < -0.5f) {
			transform.position = Camera.main.ViewportToWorldPoint (new Vector3(3f, 0.5f, 0f));
			SetObsPos ();
		}
	}

	void SetObsPos(){
		transform.position = new Vector3 (transform.position.x, Random.Range (-1f, 1f), 1);
		float orient = Random.Range (-2f, 2f);
		if (orient <= 0) {
			orient = -1;
		} else if (orient > 0) {
			orient = 1;
		} 
		transform.localScale = new Vector3 (1, orient, 1);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			print ("score");
			scoreManager.score++;
		}
	}
}
