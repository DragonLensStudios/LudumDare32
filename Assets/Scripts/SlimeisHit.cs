using UnityEngine;
using System.Collections;


public class SlimeisHit : MonoBehaviour {

	public Animator anim;
	public GameObject Slime;
	public bool attacked;

	void Start(){

		anim = GetComponent<Animator> ();
		Slime = this.gameObject;

	}


	void OnLateUpdate()
	{

			anim.SetBool("isHit", attacked);
	}
	
}

