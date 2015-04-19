using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionNPC : MonoBehaviour {
	
	public GameObject NPC;
	public GameObject MainCharacter;
	public bool NPCZONE;
	
	
	public Text dialogText;
	string charName;
	public string dialogString;
	public GameObject dialogPanel;
	
	
	int clickCount;
	
	// Use this for initialization
	void Start () {
		MainCharacter = this.gameObject;
		dialogPanel = GameObject.FindGameObjectWithTag ("DialogPanel");
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();
		charName = PlayerPrefs.GetString ("charName");
		dialogPanel.SetActive (false);
		clickCount = 0;
		
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
	
	public void OnClick(){
		clickCount++;
		Debug.Log ("Clicked");
	}
	
	void Update()
	{
		
		
		
		
		
		if (NPCZONE == true) {
			
			if (Input.GetButton("Jump")) {
				dialogPanel.SetActive (true);
			}
			
			if(NPC.name == "Lumi")
			{
				
				
				
				
				dialogText.text = dialogString;
				
				
				if(clickCount == 0)
					dialogString = ("Suni!!! What are you doing here? Is that a cloud following you? I can't Believe it! you have really been given this opportunity!\n\nNO FAIR !?!? Why Don't I ever get this Opportunity!");
				if(clickCount == 1)	
					dialogString = ("Anyways, you should go to town because some people there wanted to see you.");
				if(clickCount == 2)
					dialogString = ("They were wandering and asking questions for some strange reason.");
				if(clickCount == 3)
					dialogString = ("Is everything okay, Suni?");
				if (clickCount == 4) {
					dialogString = ("Press Enter To Continue....");
					clickCount = 0;
					dialogPanel.SetActive(false);
				}
				
			}
			
			
			
		}
	}
}








