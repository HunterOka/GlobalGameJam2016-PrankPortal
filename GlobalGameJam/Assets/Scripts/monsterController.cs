using UnityEngine;
using System.Collections;

public class monsterController : MonoBehaviour {
	public float monsterSpeed;
	public float monsterPosX;
	public float monsterPosY;
	public float health;
	public float monsterRandY;
	public float monsterRandX;
	public float trajectory;
	public float directSpeed;
	public float targetx;
	public float targety;

	// Use this for initialization
	void Start () {
		monsterPosX = this.transform.position.x;
		monsterPosY = this.transform.position.y;
		trajectory = Random.Range (0f, Mathf.PI * 2);
		targetx = Mathf.Sin (trajectory);
		targety = Mathf.Cos (trajectory);

	}



	// Update is called once per frame
	void Update () {
		
			

		monsterPosX = monsterPosX + (monsterSpeed * targetx + monsterRandX) * Time.deltaTime;
		monsterPosY = monsterPosY + (monsterSpeed * targety + monsterRandY) * Time.deltaTime;

		transform.position = new Vector2(monsterPosX,monsterPosY);
	}









}
