using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	private Sprite cardFace;
	private Sprite cardBack;

	// Displays warning, but assigned in Inspector (with SerializeField)
	[SerializeField]
	GameManager Manager;

	private bool init = true;

	[SerializeField]
	private int cardVal;

	[SerializeField]
	//False --> back
	//True --> face
	private bool cState = false;

	[SerializeField]
	private bool hasFace = false;

	[SerializeField]
	private bool matched = false;

	// GET SET FUNCTIONS //
	public int cardValue{
		get { return cardVal; }
		set { cardVal = value; }
	}

	public bool cardState {
		get{ return cState; }
		set{ cState = value; }
	}

	public bool faceValue{
		get{ return hasFace; }
		set{ hasFace = value; }
	}

	public bool cardMatch {
		get{ return matched; }
		set{ matched = value; }
	}

	// GRAPHICS //
	public void setGraphics(){
		cardBack = Manager.GetComponent<GameManager>().getCardBack();
		cardFace = Manager.GetComponent<GameManager>().getCardFace(cardValue);
	}

	public void initSet(){
		GetComponent<Image>().sprite = cardBack;
	}

	public void flipCard(){
		if (!matched && Manager.curr == true) {
			Debug.Log ("Flip forward!");
			if (cardState == false) {
				//StartCoroutine (flip ());
				GetComponent<Image> ().sprite = cardFace;
				cardState = true;

			} 
		}
	}

	public void flipCardBack(){
		if (!matched) {
			if (cardState == true) {
				GetComponent<Image> ().sprite = cardBack;
				cardState = false;
			}
		}
	}

	public void checkCard(){
		StartCoroutine (pause ());
	}

	public IEnumerator pause(){
		yield return new WaitForSeconds (0.5f);
		if (cardState == false) {
			GetComponent<Image> ().sprite = cardBack;
		} else if (cardState == true) {
			GetComponent<Image> ().sprite = cardFace;
		}

		Manager.curr = true;
	}

	/*public IEnumerator flip(){
		float targetY;

		if (cardState == false) {
			targetY = 0.0f;
		} else {
			targetY = 180.0f;
		}

		                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     

		float currY = transform.localEulerAngles.y;
		float timer = 0.0f;
		float durationTime = 1.0f;

		while (timer <= durationTime) {
			timer += Time.deltaTime;
			float incr = timer/durationTime;

			if (incr > 0.5) {
				if (cardState == false) {
					GetComponent<Image> ().sprite = cardFace;
				} else if(cardState == true){
					GetComponent<Image> ().sprite = cardBack;
				}

			}

			currY = Mathf.Lerp (currY, targetY, incr);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, currY, transform.localEulerAngles.z);

			yield return null;
		}
		Debug.Break ();
		yield return null;
	}*/

	void Awake() {

	}

	void Update () {

	}
	
	void Start(){
		/*while(init == true) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180.0f, transform.localEulerAngles.z);
			init = false;
		}*/
		
	}
	

	}
		
