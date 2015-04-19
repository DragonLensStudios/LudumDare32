using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InteractionNPC : MonoBehaviour {
	
	public NPCController NPCC;
	public GameObject MainCharacter;
	public GameObject[] hasDialogBox;
	public List<string> message_dialog;
	
	
	public Text dialogText;
	string charName;
	public string dialogString;
	public GameObject dialogPanel;
	
	
	int clickCount;
	
	// Use this for initialization
	void Start () {
		MainCharacter = gameObject;
		dialogPanel = GameObject.FindGameObjectWithTag ("DialogPanel");
		hasDialogBox = GameObject.FindGameObjectsWithTag ("HasDialog");
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();
		charName = PlayerPrefs.GetString ("charName");

		dialogPanel.SetActive (false);
		clickCount = 0;
		
	}
	
	// Update is called once per frame
	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.tag == "HasDialog")
		{
			Debug.Log ("Collided");
			NPCC = col.gameObject.GetComponent<NPCController>();
			col.gameObject.GetComponent<NPCController> ().MainCharacter = MainCharacter;
			if (Input.GetButton("Jump"))
			{
				dialogPanel.SetActive (true);
			}
		}


//		
		//if (col.gameObject == NPC) {
//			NPCZONE = true;
//		} else {
//			NPCZONE = false;
//		}
	}

	void OnCollisionExit2D (Collision2D col) 
	{
		dialogPanel.SetActive (false);
		dialogText.text = "";
		NPCC = null;

	}
	
	public void OnClick(){
		clickCount++;
		Debug.Log ("Clicked");
	}
	
	void Update()
	{

//		if (NPCC.gameObject.tag == "HasDialog")
//		{
//			Debug.Log("NPC FOUND WITH DIALOG BOX");
			if (clickCount < NPCC.message_dialog.Count)
			{
				dialogText.text = NPCC.message_dialog[clickCount];
				if (clickCount == NPCC.message_dialog.Count - 1)
				{
					dialogPanel.SetActive(false);
					clickCount = 0;
				}		
			}
			
//			if(NPC.name == "Lumi")
//		}	{

	}
}










