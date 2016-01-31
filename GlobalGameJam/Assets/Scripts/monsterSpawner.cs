using UnityEngine;
using System.Collections;

public class monsterSpawner : MonoBehaviour {

	int queueLength = 40;
	int[] monsterTypeQueue;
	public monsterController monster;
	public monsterController monster1;
	public monsterController monster2;
	public monsterController monster3;
	public monsterController monster4;
	public static int step; //Progress through monsterTypeQueue
	public int monsterType;
	static float timer = 40f;

	// Use this for initialization
	void Start () { 
		monsterTypeQueue = new int [] {0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4};
		step = 0;
		}
	

	public void SpawnWaves(){
		Debug.Log ("I'm working!");
		InvokeRepeating ("SpawnMonster", 0.1f, 1f);
	}
		
	// Update is called once per frame
	void SpawnMonster () {
		monsterType = monsterTypeQueue [step];
		switch (monsterType) {
		case 0:
			step++;
			break;
		case 1:
			//Generic Monster
			monsterController NewMonster;
			NewMonster = Instantiate (monster1, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as monsterController;
			step++;
			Debug.Log (NewMonster);
			NewMonster.monsterSpeed = 1f;
			NewMonster.health = 10f;
			NewMonster.monsterRandX = Random.Range(-2f, 0f);
			NewMonster.monsterRandY = Random.Range(-1f, 0f);
			break;
		case 2:
			//Fast
			monsterController NewMonster1;
			NewMonster1 = Instantiate (monster2, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as monsterController;
			step++;
			NewMonster1.monsterSpeed = 2f;
			NewMonster1.health = 10f;
			NewMonster1.monsterRandX = Random.Range(-1f, 0f);
			NewMonster1.monsterRandY = Random.Range(1f, 0f);
			break;
		case 3: 
			//Slow
			monsterController NewMonster2;
			NewMonster2 = Instantiate (monster3, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as monsterController;
			step++;
			NewMonster2.monsterSpeed = 0.5f;
			NewMonster2.health = 10f;
			NewMonster2.monsterRandX = Random.Range(-1f, 0f);
			NewMonster2.monsterRandY = Random.Range(1f, 0f);
			break;
		case 4:
			//Good
			monsterController NewMonster3;
			NewMonster3 = Instantiate (monster4, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as monsterController;
			step++;
			NewMonster3.monsterSpeed = 1f;
			NewMonster3.health = 10f;
			NewMonster3.monsterRandX = Random.Range(-1f, 0f);
			NewMonster3.monsterRandY = Random.Range(1f, 0f);
			break;
		default:
			break;
		}

	}


	void Update(){
		if (step == queueLength) {
			CancelInvoke ("SpawnMonster");
		}

	}
		
}
