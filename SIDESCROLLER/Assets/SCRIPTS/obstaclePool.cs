using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePool : MonoBehaviour {

	[SerializeField]
	private GameManager _manager;
	[SerializeField]
	private Canvas canvas;

	//using prefabs
	public GameObject lowObstacle;
	public GameObject tallObstacle;
	public GameObject doubleLowObstacle;

	public int poolSize;

	[SerializeField]
	private GameObject[] obstacles;
	private int currObstacle = 0;

	private Vector2 objectPoolPos = new Vector2(5000, -700); //determine spawn point later.
	private float spawnXPos = 1250f; //determine later as well.

	private float spawnTimer;
	private float spawnRate;
	private float minTime = 2.5f;
	private float maxTime = 4.5f;


	// Use this for initialization
	void Start () {
		spawnTimer = 0f;

		obstacles = new GameObject [poolSize];
		for (int i = 0; i < poolSize; i++) {
			if (i % 3 == 0) {
				obstacles [i] = (GameObject)Instantiate (lowObstacle, objectPoolPos, Quaternion.identity);
				obstacles [i].transform.SetParent (canvas.transform, false);
			} else if (i % 3 == 1) {
				obstacles [i] = (GameObject)Instantiate (tallObstacle, objectPoolPos, Quaternion.identity);
				obstacles [i].transform.SetParent (canvas.transform, false);
			} else if (i % 3 == 2) {
				obstacles [i] = (GameObject)Instantiate (doubleLowObstacle, objectPoolPos, Quaternion.identity);
				obstacles [i].transform.SetParent (canvas.transform, false);
			}

		}

		spawnRate = Random.Range (minTime, maxTime);
			

	}

	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;

		if (_manager.gameState == true && spawnTimer >= spawnRate) {
			spawnTimer = 0f;
			float spawnYPos = 0;

			if(currObstacle%3==0 || currObstacle%3==1) 
				spawnYPos = -175; //low obs y pos
			else if(currObstacle%3==2)
				spawnYPos = -175; //tall obs y pos.
			
			obstacles [currObstacle].transform.localPosition = new Vector2(spawnXPos, spawnYPos);
			obstacles [currObstacle].GetComponent<Obstacles>().reSpawn = true;

			currObstacle++;
			spawnRate = Random.Range (minTime, maxTime);

			if (currObstacle >= poolSize) {
				currObstacle = 0;
			}
		}
	}
}
