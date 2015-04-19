using UnityEngine;
using System.Collections;

public class InteractionNPC : MonoBehaviour {

	public GameObject NPC;
	public GameObject MainCharacter;
	public bool NPCZONE;

	// Use this for initialization
	void Start () {
		MainCharacter = this.gameObject;
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("Collided");
		NPC = col.gameObject.GetComponent<NPCController>().NPC;
		col.gameObject.GetComponent<NPCController> ().MainCharacter = MainCharacter;
		if (col.gameObject == NPC) {
			NPCZONE = true;
		} else {
			NPCZONE = false;
		}
	}

	void Update()
	{
		if (NPCZONE == true) {

			if (Input.GetKeyDown ("Space")) {
			}
		}
	}

		

		

	
}
