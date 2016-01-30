using UnityEngine;
using System.Collections;

public class monsterSpawner : MonoBehaviour {

	int queueLength = 40;
	int[] monsterTypeQueue;
	public GameObject monster;
	public GameObject monster1;
	public GameObject monster2;
	public GameObject monster3;
	public GameObject monster4;
	public static int step; //Progress through monsterTypeQueue
	public int monsterType;

	// Use this for initialization
	void Start () { 
		monsterTypeQueue = new int [] {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		step = 0;
		}
	

	public void SpawnWaves(){
		Debug.Log("Test");
		InvokeRepeating ("SpawnMonster", queueLength, 1f);
		Debug.Log("Finished");

	}
		
	
	// Update is called once per frame
	void SpawnMonster () {
		monsterType = monsterTypeQueue [step];
		Debug.Log (monsterType);
		switch (monsterType) {
		case 0:
			step++;
			break;
		case 1:
			Instantiate (monster1, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			step++;
			break;
		case 2:
			Instantiate (monster2, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			step++;
			break;
		case 3: 
			Instantiate (monster3, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			step++;
			break;
		case 4:
			Instantiate (monster4, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			step++;
			break;
		default:
			break;
		}



	}
}
