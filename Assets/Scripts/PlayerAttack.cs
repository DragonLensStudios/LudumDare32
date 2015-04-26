using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour {
	public Transform target;
	Animator anim;

	public bool attacked;
	public GameObject isUser;
	public SlimeisHit Slime;
	public RockisHit Rock;
	public int slimeHealth;
	public int rockHealth;
	public int playerSwordDamage;
	public int damageDeal;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerSwordDamage = 1;
		rockHealth = 2;
 
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
		Rock = col.gameObject.GetComponent<RockisHit> ();

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
			Slime.GetComponent<SlimeisHit> ().health -= playerSwordDamage;

			Rock.GetComponent<RockisHit> ().attacked = true;
			Rock.GetComponent<RockisHit> ().anim.SetBool("isHit", attacked);
			Rock.GetComponent<RockisHit> ().health -= playerSwordDamage;

			Debug.Log ("IM GETTING HERE");


		} else {

			Slime.GetComponent<SlimeisHit>().attacked = false;
			Slime.GetComponent<SlimeisHit> ().anim.SetBool("isHit", attacked);

			Rock.GetComponent<RockisHit>().attacked = false;
			Rock.GetComponent<RockisHit> ().anim.SetBool("isHit", attacked);

		}
	}



}

