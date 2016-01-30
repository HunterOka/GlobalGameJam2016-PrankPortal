using UnityEngine;
using System.Collections;

public class monsterController : MonoBehaviour {
	
	float monsterSpeed;
	Vector2 monsterMovement;
	Vector2 monsterRandX; //This vector 2 represents the range of randmness for movement in the x direction each time step
	Vector2 monsterRandY; //This vector 2 represents the range of randomness for movement in the y direction each time step
	float monsterPosX;
	float monsterPosY;
	float health;


	// Use this for initialization
	void Start () {
		
		float monsterSpeed = 1f;
		health = 10f;	
	}




	// Update is called once per frame
	void Update () {
		
		monsterPosX = monsterPosX + (monsterSpeed + Random.Range (monsterRandX.x,monsterRandX.y)) * Time.deltaTime;
		monsterPosY = monsterPosY + (monsterSpeed + Random.Range (monsterRandY.x,monsterRandY.y)) * Time.deltaTime;

		transform.position = new Vector2(monsterPosX,monsterPosY);
	}
}
