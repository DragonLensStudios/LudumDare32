using UnityEngine;
using System.Collections;


public class RockisHit : MonoBehaviour {

	public Animator anim;
	public GameObject Rock;
	public bool attacked;
	public int health;
	public PlayerAttack player;

	void Start(){

		anim = GetComponent<Animator> ();
		Rock = gameObject;

	}


	void OnLateUpdate()
	{

			anim.SetBool("isHit", attacked);


	}

	void Update()
	{

		if (health <= 0) {
			Debug.Log ("Dead");
			GameObject.Destroy(gameObject);
		}
	}
	
}

