using UnityEngine;
using System.Collections;


public class WarpPlain : MonoBehaviour {
	
	public Transform target;

	void OnTriggerEnter2D(Collider2D col){

		col.gameObject.transform.position = target.position;

	}
}
