using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prize : MonoBehaviour {
	[SerializeField]
	private int objValue;
	[SerializeField]
	private bool objGrabbed;
	[SerializeField]
	List<Sprite> prizeSprites;

	public int itemRarity;

	private Vector3 pos;

	// GET SET FUNCTIONS //

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

	public bool prizeGet{
		get{ return objGrabbed; }
		set{ objGrabbed = value; }
	}

	public int prizeValue {
		get{ return objValue; }
		set{ objValue = value; }
	}

	public void setPosition(){
		transform.position = pos;
	}

	public void moveLeft(){
		float change = .5f;

		positionX -= change;
		StartCoroutine (move());

	}

	public void moveRight(){
		float change = .5f;

		positionX += change;
		StartCoroutine (move());
	}

	public void moveUp(){
		float change = .5f;

		positionY += change;
		StartCoroutine (move ());
	}

	IEnumerator move(){
		yield return new WaitForSeconds (0.01f);
		setPosition();

	}

	void Awake(){

		objValue = Random.Range (1, 50);

		if (objValue< 40)
			itemRarity = 0;
		else if (objValue < 47) 
			itemRarity = 1;
		else
			itemRarity = 2;


		GetComponent<Image> ().sprite = prizeSprites [itemRarity];
	}

	// Use this for initialization
	void Start () {
		pos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void grabFailed(){
	}

	public IEnumerator autoMove(Vector3 start, Vector3 dest){
		//Use LERP to move until reach destination.
		float pos = 0.0f;
		while (pos <= 1.0f) {
			pos += 0.005f;
			transform.position = Vector3.Lerp (start, dest, pos);
			yield return null;
		}
		yield return null;
	}

}
