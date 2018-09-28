using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	private bool canHit = true;
	public bool reSpawn = false;

	private void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<Player>() != null && canHit == true){
			GameManager.instance.playerHit();
			canHit = false;
		}
	}

	void Update(){
		if (reSpawn == true) {
			canHit = true;
			reSpawn = false;
		}
	}
}
	
