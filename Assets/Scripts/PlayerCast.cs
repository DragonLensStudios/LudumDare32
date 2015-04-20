using UnityEngine;
using System.Collections;

public class PlayerCast : MonoBehaviour {

	private Animator anim;
	public bool isCasting;
	bool isAttacking;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("1") || Input.GetKeyDown ("2")|| Input.GetKeyDown ("3")|| Input.GetKeyDown ("4")) {
			isCasting = true;
		} else {
			isCasting = false;
		}
		if (Input.GetKeyDown ("0")) {
			anim.SetTrigger("Death");
			Debug.Log ("Set trigger");
		}

		if (Input.GetButton ("Fire1")) {
			isAttacking = true;
		} else {
			isAttacking = false;
		}
			
		anim.SetBool ("isAttacking", isAttacking);
		anim.SetBool ("isCasting", isCasting);
	}
}
