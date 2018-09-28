using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	[SerializeField]
	private BoxCollider2D groundCollider;
	private float groundHlength;
	private Vector2 initPos;
	private bool init = true;


	// Use this for initialization
	void Start () {
		groundHlength = groundCollider.size.x;
		if (init == true) {
			initPos = (Vector2)transform.localPosition;
			init = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.localPosition.x-initPos.x) < (-groundHlength)) {
			reposGround ();
			initPos = (Vector2)transform.localPosition;
		}
		
	}

	private void reposGround(){
		Vector2 groundOffset = new Vector2 (groundHlength, 0);
		transform.localPosition = (Vector2)transform.localPosition + groundOffset;
	}
}
