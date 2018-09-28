using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float scrollSpeed = -750f;
	public float crashSpeed = -250f;

	public GameObject[] groundObjects;

	public static GameManager instance;


	private int score = 0;
	private float time = 0f;
	//Gamestate determines whether game is still ongoing (scrolling)
	public bool gameState = true;
	//Can hit obstacles up to 2 times.

	public bool crashState = false;

	public Player playerObj;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0) && gameState == true) {
			playerObj.playerJump ();
		}

		time += Time.deltaTime;
		if (time >= 30f)
			gameEnd ();
		if (gameState == true)
			score = (int)time / 5;
		
	}
		
	public void playerHit (){
		playerObj.loseLife ();

		print ("HIT");

		if (playerObj.lifeCount == 0) {
			gameOver ();
		}

		StartCoroutine (moveDelay ());

	}

	IEnumerator moveDelay(){
		crashState = true;
		yield return new WaitForSeconds (.5f);
		crashState = false;

	}

	public void gameEnd(){
		gameState = false;
	}

		
	public void gameOver(){
		gameState = false;
		//sprite fall animation/sit down
	}
}
