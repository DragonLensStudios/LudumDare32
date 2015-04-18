using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	Animator anim;
	bool isWalking;

	public int speed = 20;
	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");
		
		
		
		if (input_x != 0 || input_y != 0) {
			isWalking = true;
		} else {
			isWalking = false;
		}




		anim.SetBool ("isWalking", isWalking);


		
		if (isWalking == true) {
			anim.SetFloat("x", input_x);
			anim.SetFloat("y", input_y);
			
			transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * speed;
		}
		
	}

	void LateUpdate()
	{
		if (Input.GetButton ("Fire1")) {
			
			speed = 0;
		} else {

			speed = 3;
		
		}
	}

}
