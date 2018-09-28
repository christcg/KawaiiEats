using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clawGameManager : MonoBehaviour {

	public List<GameObject> prizeList;
	public List<int> prizeGrabbed;
	public int prizeCnt;

	public GameObject prizePrefab;

	public GameObject rightClaw;
	public GameObject leftClaw;

	public Claw gameClaw;
	public Transform sightEnd;
	public float CANVAS_SIZE = 1000;
	public Canvas UICanvas;

	public Button leftButton;
	public Button rightButton;
	public Button grabButton;
	public bool buttonFunction = false;

	public void initPrize(){
	}
		

	public void grabPrize(){
		buttonFunction = false;
		
		/*Ray cast; see if hits any prize Gameobjects
		  If yes, check position of RayCast and check center of Prize object. IF the margin of
		  error is small enough, count as successful grab and deploy claw as such.
		*/
		gameClaw.clawPos = false;

		RaycastHit2D rch;

		rch = Physics2D.Raycast (gameClaw.position, Vector2.up*CANVAS_SIZE);

		float targetPos = rch.distance;
		//Debug.Log("got Object: " + isObject);
		Debug.Log("distance from: " + targetPos);
		Vector2 dest = new Vector2 (gameClaw.positionX, gameClaw.positionY- (targetPos + 15));

		StartCoroutine (grabMotion (dest));
	}

	IEnumerator grabMotion(Vector2 dest){
		yield return StartCoroutine (gameClaw.autoMove (gameClaw.transform.position, dest));
		yield return new WaitForSeconds (0.5f);


		float openPos = 0;
		float closePos = 21;

		yield return StartCoroutine (turnClaw (openPos, closePos));

		dest = new Vector3(gameClaw.transform.position.x, gameClaw.transform.position.y - CANVAS_SIZE/2);
		yield return new WaitForSeconds (0.5f);
		yield return StartCoroutine (gameClaw.autoMove (gameClaw.transform.position, dest));

		yield return new WaitForSeconds (1.5f);

		checkPrizes ();

		yield return StartCoroutine (turnClaw (closePos, openPos));

		Vector2 returnPos = new Vector2 (gameClaw.transform.position.x, gameClaw.startPosition.y);
		yield return StartCoroutine (gameClaw.autoMove (gameClaw.transform.position, returnPos));

		buttonFunction = true;

	}



	public IEnumerator turnClaw(float initPos, float endPos){

		float pos = 0.0f;

		while (pos <= 1.0f) {
			pos += 0.045f;
			leftClaw.transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle (initPos, endPos, pos) );
			rightClaw.transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle  (-initPos, -endPos, pos));
			yield return null;
		}


		yield return null;

	}

	public void checkPrizes(){
		foreach (GameObject prize in prizeList) {
			if(prize.transform.localPosition.y > 1500){
				Debug.Log ("cycling throuhg object!");
				prizeGrabbed.Add (prize.GetComponent<Prize> ().itemRarity);
				Destroy (prize, 0.0f);
				prizeList.Remove (prize);
				Debug.Log ("destroyed");

			}
		}
	}


	IEnumerator waitForInit(){
		yield return new WaitForSeconds (2.5f);
		buttonFunction = true;
		leftButton.GetComponent<Graphic>().raycastTarget = true;
		rightButton.GetComponent<Graphic>().raycastTarget  = true;
		grabButton.GetComponent<Graphic>().raycastTarget  = true;
	}

	void Awake(){
		leftButton.GetComponent<Graphic>().raycastTarget = false;
		rightButton.GetComponent<Graphic>().raycastTarget  = false;
		grabButton.GetComponent<Graphic>().raycastTarget = false;

		prizeCnt = 25;
		prizeList = new List<GameObject> ();
		int xpos, ypos; 
		for (int x = 0; x < prizeCnt; x++) {
			xpos = Random.Range(-100, 100);
			//ypos = Random.Range (50, -50);
			prizeList.Add((GameObject)Instantiate (prizePrefab, new Vector2(xpos,25), Quaternion.identity));
			prizeList [x].transform.SetParent (UICanvas.transform, false);
		}

		StartCoroutine (waitForInit ());
	}

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		float timePassed = Time.deltaTime;
		if (timePassed >= 90.0)
			buttonFunction = false;
		
		if (buttonFunction == false) {
			leftButton.GetComponent<Graphic> ().raycastTarget = false;
			rightButton.GetComponent<Graphic> ().raycastTarget = false;
			grabButton.GetComponent<Graphic> ().raycastTarget = false;
		} else if (buttonFunction == true) {
			leftButton.GetComponent<Graphic> ().raycastTarget = true;
			rightButton.GetComponent<Graphic> ().raycastTarget = true;
			grabButton.GetComponent<Graphic> ().raycastTarget = true;
		}
			
		Debug.DrawRay(gameClaw.position, Vector3.up*CANVAS_SIZE, Color.green);

		
	}
}
