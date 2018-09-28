using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

	private Sprite objectImage;

	private bool start = true;
	private Vector3 pos;

	public Vector2 originalPos;

	[SerializeField]
	private Vector3 startPos;


	[SerializeField]
	private clawGameManager Manager;

	[SerializeField]
	// True --> Open
	// Flase --> Closed
	private bool clawPosition;

	// GET SET FUNCTIONS //

	public Vector3 startPosition {
		get{ return startPos; }
	}

	public bool clawPos{
		get{ return clawPosition; }
		set{ clawPosition = value; }
	}

	public float positionX{
		get{ return pos.x; }
		set{ pos.x = value;}
	}

	public float positionY{
		get{ return pos.y; }
		set{ pos.y = value;}
	}

	public float positionZ{
		get{ return pos.z; }
		set{ pos.z = value; }
	}

	public Vector3 position {
		get{ return transform.position; }
	}

	void Awake(){
		Vector2 originalPos = transform.position;
	}
		
	// Use this for initialization
	void Start () {
		pos = transform.position;
		clawPosition = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (start) {
			startPos = pos;
			start = false;
		}
		
	}	

	public void setPosition(){
		transform.position = pos;
	}


	public void moveLeft(){
		float change = 1.0f;

		positionX -= change;
		StartCoroutine (moveButtons());

	}

	public void moveRight(){
		float change = 1.0f;

		positionX += change;
		StartCoroutine (moveButtons());
	}

	IEnumerator moveButtons(){
		yield return new WaitForSeconds (.01f);
		setPosition();
	}

	public IEnumerator autoMove(Vector2 start, Vector2 dest){
		//Use LERP to move until reach destination.
		float pos = 0.0f;
		while (pos <= 1.0f) {
			pos += 0.0065f;
			transform.position = Vector2.Lerp (start, dest, pos);
			yield return null;
		}
		yield return null;
	}



}
