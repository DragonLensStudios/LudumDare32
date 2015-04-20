using UnityEngine;
using System.Collections;


public class SlimeisHit : MonoBehaviour {

	public Animator anim;
	public GameObject Slime;
	public bool attacked;
	public int health;
	public PlayerAttack player;

	void Start(){

		anim = GetComponent<Animator> ();
		Slime = gameObject;

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

