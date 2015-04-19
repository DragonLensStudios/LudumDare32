using UnityEngine;
using System.Collections;

public class AIBase : MonoBehaviour {
	public Vector2 destination;
	public float speed = 1f;
	public float range = 1f;
	private Vector2 move;
	private bool destReached;
		

	void Start(){
		genDestination ();
	}

	// Update is called once per frame
	void Update () {
		if (Random.Range (-1f, 1f) > 0)
			return;
		if (destReached)
			genDestination ();
		Vector3 loc = transform.position; 
		Vector2 location = new Vector2(loc.x, loc.y);
		move = (destination - location).normalized * speed * Time.deltaTime;


		if (move == Vector2.zero)
			destReached = true;
		else
		transform.position += new Vector3 (move.x, move.y, 0);
	}
	void onCollisionEntered2D(Collision2D col){
		transform.position -= new Vector3 (move.x, move.y, 0);
		destReached = true;
	}
	void genDestination(){
		destReached = false;
		Vector3 loc = transform.position; 
		Vector2 location = new Vector2(loc.x, loc.y);
		destination = location + new Vector2 (Random.Range (-range,range),Random.Range (-range,range));
	}
}
