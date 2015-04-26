using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InteractionNPC : MonoBehaviour {
	
	public NPCController NPCC;
	public GameObject MainCharacter;
	public List<GameObject> hasDialogBox;
	public List<string> message_dialog;
	
	
	public Text dialogText;
	string charName;
	public string dialogString;
	public GameObject dialogPanel;
	public Text nametagPanel;
	public bool dummyset = false;
	public DummyNPCController Dummy;
	
	
	int clickCount;
	
	// Use this for initialization
	void Start () {
		MainCharacter = gameObject;
		dialogPanel = GameObject.FindGameObjectWithTag ("DialogPanel");
		hasDialogBox.AddRange(GameObject.FindGameObjectsWithTag ("HasDialog")) ;
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();
		charName = PlayerPrefs.GetString ("charName");
		nametagPanel = GameObject.Find("NameTagText").GetComponent<Text>();
		
		dialogPanel.SetActive (false);
		clickCount = 0;
		
	}
	
	// Update is called once per frame
	void OnCollisionStay2D (Collision2D col) {
		if (!dummyset) {
			if (col.gameObject.tag == "HasDialog") {
				Debug.Log ("Collided");
				NPCC = col.gameObject.GetComponent<NPCController> ();
				col.gameObject.GetComponent<NPCController> ().MainCharacter = MainCharacter;
				if (Input.GetButton ("Jump")) {
					dialogPanel.SetActive (true);
				}
			}
		} else {
			dialogPanel.SetActive (false);
			dialogText.text = "";
			NPCC = null;
			clickCount = 0;

		}
		
		//		
		//if (col.gameObject == NPC) {
		//			NPCZONE = true;
		//		} else {
		//			NPCZONE = false;
		//		}
	}

//	
//	void OnCollisionExit2D (Collision2D col) 
//	{
//		dialogPanel.SetActive (false);
//		dialogText.text = "";
//		NPCC = null;
//		clickCount = 0;
//		
//	}
//	
	public void OnClick(){
		clickCount++;
		Debug.Log ("Clicked");
	}
	public void startdummy(NPCController dummynpc, DummyNPCController dummy){
		dummyset = true;
		NPCC = dummynpc;
		Dummy = dummy;
		dialogPanel.SetActive (true);
	}
	void Update()
	{
		
		if (NPCC != null)
		{
			//			Debug.Log("NPC FOUND WITH DIALOG BOX");
			if (clickCount < NPCC.message_dialog.Count)
			{
				
				dialogText.text = NPCC.message_dialog[clickCount];
				nametagPanel.GetComponent<Text>().text = NPCC.npc_name;
			}
			else if (clickCount == NPCC.message_dialog.Count)
			{

				nametagPanel.GetComponent<Text>().text = null;
				dialogPanel.SetActive(false);
				clickCount = 0;

				if(dummyset){
					dummyset = false;
					NPCC = null;
					Dummy.Finish();
					Dummy = null;
				}
			}	
			//			if(NPC.name == "Lumi")
		}	
		
	}
}










