using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float maxMovement;
	const int maxFrames = 120;
	public int currentWait;
	public int waitTrack;

	// Use this for initialization
	void Start () {
		maxMovement = 1.0f;
		currentWait = 100;
		waitTrack = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//Controls random movement timer of enemy
		if(waitTrack==currentWait){
			MoveEnemy();
			waitTrack = 0;
			currentWait = Random.Range(0,maxFrames);
		}
		else{
			waitTrack++;
		}
	}

	//Move the enemy in a random direction if possible
	void MoveEnemy () {

	}
}
