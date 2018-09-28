using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int lives = 2;
	private int jumps = 2;
	private bool jumpAbility = true;

	[SerializeField]
	private float upForce = 1000f;

	[SerializeField]
	private Rigidbody2D rgBody;
	[SerializeField]
	private GameManager _manager;

	public int lifeCount{
		get{ return lives; }
		set{ lives = value; }
	}

	public int jumpCount{
		get{ return jumps; }
		set{ jumps = value; }
	}

	public void playerJump(){
		if (jumpAbility == true) {
			rgBody.velocity = Vector2.zero;
			rgBody.AddForce (Vector2.up * (upForce / Time.fixedDeltaTime));
			jumps--;
			if (jumps == 0)
				jumpAbility = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.GetComponent<Ground>() != null){
			jumpReset ();
		}
	}

	public void jumpReset(){
		jumps = 2;
		jumpAbility = true;
	}

	public void loseLife(){
		lives--;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
