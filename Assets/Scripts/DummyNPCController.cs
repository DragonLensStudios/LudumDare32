using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DummyNPCController : MonoBehaviour {
	public List<NPCController> DummyNPCs;
	public InteractionNPC dialog;
	public bool istalking = false; //Needs to be private.
	public bool isconversationdone; //Needs to be private.
	public int count = 0; //Needs to be private.
	public bool has_started = true;
	// Use this for initialization
	public void Finish (){
		istalking = false;
	}
	void OnTriggerStay2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player")
		{

			dialog = col.gameObject.GetComponent<InteractionNPC>();
			Debug.Log("ONTrigger with " + col.name);
			step ();
		}

	}
	private void step(){

		if ((istalking != true) && has_started)
		{
			if (DummyNPCs.Count > count)
			{
				istalking = true;
				dialog.startdummy(DummyNPCs[count],this);
				count++;
			}
			else
			{
				GameObject.Destroy(gameObject);
			}
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		istalking = false;
		count = 0;
		dialog.dialogPanel.SetActive (false);
		dialog.dummyset = false;
		dialog.clickCount = 0;
	}

	void Start () {
		DummyNPCs.AddRange(gameObject.GetComponents<NPCController>());
	}

	void Update (){
		Debug.Log(gameObject.transform.root.name);
		if (gameObject.transform.root.tag == "Player"){
			gameObject.transform.root.GetComponent<InteractionNPC>();
			step ();
		}
	}
	
	// Update is called once per frame
}
