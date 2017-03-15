using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	Rigidbody2D ship;
	Animator anim;

	public float speed;
	bool isUp = false;

	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		ship = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		Time.timeScale = 1;

	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.Space)) || (Input.GetMouseButtonDown(0))){
			ChangeDirection ();
		}
		anim.SetFloat ("speed", ship.velocity.y);

		Vector3 angles = transform.eulerAngles;
		angles.z = Mathf.Clamp (ship.velocity.y * 3f, -15f, 15f);
		transform.eulerAngles = angles;
	}

	public void ChangeDirection (){
		if (isUp) {
			ship.velocity = new Vector2 (0,0);
			ship.AddForce (Vector2.down * (speed));
			isUp = false;
		} else if (!isUp) {
			ship.velocity = new Vector2 (0,0);
			ship.AddForce (Vector2.up * (speed));
			isUp = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Obstacle") {
			print ("die");
			Time.timeScale = 0;
			gameOver.SetActive (true);
		}
	}
}
