using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour {
	public Transform target;
	Animator anim;

	public bool attacked;
	public GameObject isUser;
	public SlimeisHit Slime;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
 
	}
	


	void OnTriggerStay2D(Collider2D col)
	{

		if (Input.GetButton ("Fire1") && col.gameObject.tag == "monster") {

			attacked = true;


		} else {
			attacked = false;

		}


	}


	void OnTriggerEnter2D(Collider2D col)
	{


		Slime = col.gameObject.GetComponent<SlimeisHit> ();

	//	if(col.gameObject.tag == ("monster"))
	//	{
		//	Slime.anim.SetBool("isHit", attacked);
		//}

	}

	void OnTakeDamage(Collider2D col)
	{
		if (attacked == true) {
			Debug.Log ("You hit!");
			Slime.GetComponent<SlimeisHit> ().attacked = true;
			Slime.GetComponent<SlimeisHit> ().anim.SetBool("isHit", attacked);


		} else {

			Slime.GetComponent<SlimeisHit>().attacked = false;
			Slime.GetComponent<SlimeisHit> ().anim.SetBool("isHit", attacked);
		}
	}



}

