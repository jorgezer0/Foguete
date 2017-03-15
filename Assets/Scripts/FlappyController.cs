using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour {

	public Vector3 startPosVP;
	[Header("Velocity")]
	public float flappyVelocity;

	public bool isDead = false;

	private Animator anim;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
		 
		Vector3 startPos = Camera.main.ViewportToWorldPoint(startPosVP);
		startPos.z = 0;
		transform.position = startPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			FlappyWings ();
		}

		Vector3 angles = transform.eulerAngles;
		angles.z = Mathf.Clamp (body.velocity.y * 1.09f, -90f, 45f);
		transform.eulerAngles = angles;
	}

	void FlappyWings(){
		anim.SetTrigger ("Flappy");
		body.velocity = (Vector2.up * flappyVelocity);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.collider.CompareTag("Pipe")){
			isDead = true;
		}
	}
}
