using UnityEngine;
using System.Collections;


public class EnemyisHit : MonoBehaviour {

	public Animator anim;
	public GameObject Enemy;
	public bool attacked;
	public int health;
	public int maxHealth;
	public PlayerAttack player;

	void Start(){

		anim = GetComponent<Animator> ();
		Enemy = gameObject;

	}


	void OnLateUpdate()
	{

		anim.SetBool ("isHit", attacked);

	}
	void Update()
	{

		if (health <= 0) {
			Debug.Log ("Dead");
			GameObject.Destroy(gameObject);
		}
	}


}

