using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Card[] cards;
	public Card[] c = new Card [2];

	public List<Sprite> cardFace;
	public Sprite cardBack;
	public int matchSize;

	private bool init = false;
	public bool curr = true;

	public GameObject tutorialCanvas;


	public void matchCards(Card[] c){
		bool match = false;
		if (c[0].cardValue == c[1].cardValue) {
			match = true;
			matchSize--;
		} 

		for (int x = 0; x < 2; x++) {
			c [x].cardState = match;
			c [x].cardMatch = match;
			c [x].checkCard();
		}
			
	}

	public void getMatch(){
		int count = 0;
		for(int i = 0; i < cards.Length; i++){
			if(cards[i].cardState == true && cards[i].cardMatch == false){
				c[count] = cards[i];
				count++;
			}
		}

		if (count == 2) {
			curr = false;
			matchCards (c);
		}
	}

	public bool isComplete(){
		if (matchSize == 0)
			return true;
		else
			return false;
	}

	public void initCards(){
		for (int x = 0; x < 2; x++) {
			for (int y = 0; y < matchSize; y++) {
				bool cardSet = false;
				int choice = 0;
				while (!cardSet) {
					choice = Random.Range (0, cards.Length);
					cardSet = !(cards [choice].faceValue);
				}
				cards [choice].cardValue = y;
				cards [choice].faceValue = true;
			}
		}

		foreach (Card c in cards) {
			c.setGraphics ();
			c.initSet ();
		}

		init = true;
				
	}

	public Sprite getCardBack(){
		return cardBack;
	}

	public void shuffleFace(List<Sprite> face){
		for (int x = face.Count; x > 1; x--) {
			int j = Random.Range (0, x);
			Sprite temp = face[x-1];
			face[x-1] = face[j];
			face [j] = temp;
		}
	}

	public Sprite getCardFace(int val){
		return cardFace[val];
	}

	public void activateTutorial(){
		tutorialCanvas.SetActive (true);
	}

	void Awake (){
		
		//Forces game to initialize card faces before start.
		while (!init) {
			shuffleFace (cardFace);
			initCards ();
			tutorialCanvas.SetActive (false);
		}

	}
		
	// Update is called once per frame
	void Update () {



		//if (Input.GetTouch (0).phase == TouchPhase.Ended)
		if (Input.GetMouseButtonUp (0)) {
			getMatch ();
		}
	}


}
