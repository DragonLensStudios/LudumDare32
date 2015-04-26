using UnityEngine;
using System.Collections;

public class DestroyCollideronTalk : MonoBehaviour {
	public Transform NPC;
	public Transform target;

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.transform.name == NPC.name) {
			if (Input.GetKeyDown ("Jump")) {
				GameObject.Destroy (gameObject);
			}
		}
	}
}
