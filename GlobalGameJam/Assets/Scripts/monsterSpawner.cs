using UnityEngine;
using System.Collections;

public class monsterSpawner : MonoBehaviour {

	int queueLength = 100;
	int[,] monsterTypeQueue;
	public GameObject monster;
	public int queueCounter;
	bool isRoundActive ;

	// Use this for initialization
	void Start () { 
		monsterTypeQueue = new int [,] { {0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,1,1,1,1,1,0,1,0,0,0,1,1,1,1,1},{0,2,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,1},{1,1,1,0,0,0,1,1,1,0,0,0,1,1,1,1,1,1,0,0} };
		queueCounter = 0;
		}
	


		

	
	// Update is called once per frame
	void Update () {


		
	}
}
