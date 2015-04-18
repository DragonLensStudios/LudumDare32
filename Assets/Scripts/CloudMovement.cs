using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public Transform target;
	bool top, right, left, bottom;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey ("w")) {
			top = true;
		} else {
			top = false;
		}


		if (Input.GetKey ("a")) {
			left = true;
		} else {
			left = false;
		}


		if (Input.GetKey ("d")) {
			right = true;
		} else {
			right = false;
		}


		if (Input.GetKey ("s")) {
			bottom = true;
		} else {
			bottom = false;
		}
		





	}
	void LateUpdate()
	{
		if(top == true){
			transform.position = target.transform.position + Vector3.down / 3;
		}
		if(left == true){
			transform.position = target.transform.position + Vector3.right / 3;
		}
		if(right == true){
			transform.position = target.transform.position + Vector3.left / 3;
		}
		if(bottom == true){
			transform.position = target.transform.position + Vector3.up / 3;
		}
	}

}
