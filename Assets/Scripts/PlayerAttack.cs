using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour {
	public Transform target;
	Animator anim;

	public bool attacked;
	public GameObject isUser;
	public EnemyisHit Enemy;
	public int enemyHealth;
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

		Enemy = col.gameObject.GetComponent<EnemyisHit> ();

	//	if(col.gameObject.tag == ("monster"))
	//	{
		//	Slime.anim.SetBool("isHit", attacked);
		//}

	}

	void OnTakeDamage(Collider2D col)
	{
		if (attacked == true) {
		
			Debug.Log ("You hit!");
			Enemy.GetComponent<EnemyisHit> ().attacked = true;
			Enemy.GetComponent<EnemyisHit> ().anim.SetBool("isHit", attacked);
			Enemy.GetComponent<EnemyisHit> ().health -= playerSwordDamage;

			Debug.Log ("IM GETTING HERE");


		} else {

			Enemy.GetComponent<EnemyisHit>().attacked = false;
			Enemy.GetComponent<EnemyisHit> ().anim.SetBool("isHit", attacked);


		}
	}



}

