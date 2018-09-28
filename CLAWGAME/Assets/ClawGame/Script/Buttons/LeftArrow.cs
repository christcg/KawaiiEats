using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LeftArrow : MonoBehaviour {

	[SerializeField]
	private bool isPressed = false;

	[SerializeField]
	private Claw claw;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//Whether or not the button is pressed.
		//If it is, move the claw.
		if (isPressed) {
			claw.moveLeft ();
		}

	}

	public void onPointerDownLeft(){
		isPressed = true;
	}

	public void onPointerUpLeft(){
		isPressed = false;
	}
}
