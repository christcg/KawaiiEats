using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rgBody;


	// Use this for initialization
	void Start () {
		//rgBody = GetComponent<Rigidbody2D> ();
		rgBody.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);

	}

	// Update is called once per frame
	void Update () {
		if (GameManager.instance.crashState == true) {
			rgBody.velocity = new Vector2 (GameManager.instance.crashSpeed, 0);
		}
		else if(GameManager.instance.crashState == false) {
			rgBody.velocity = new Vector2 (GameManager.instance.scrollSpeed, 0);
		}
		if (GameManager.instance.gameState == false) {
			rgBody.velocity = Vector2.zero;
		}
		
	}
}
