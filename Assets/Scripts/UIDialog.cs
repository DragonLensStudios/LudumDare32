using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIDialog : MonoBehaviour {

	public Text dialogText;
	string charName;
	public string dialogString;

	// Use this for initialization
	int clickCount;


	void Start () {

		dialogText = GameObject.Find("DialogText").GetComponent<Text>();

		charName = PlayerPrefs.GetString ("charName");
	}
	
	// Update is called once per frame
	void Update () {
		dialogText.text = dialogString;

		if(clickCount == 0)
			dialogString = ("Suni!!! What are you doing here? Is that a cloud following you? I can't Believe it! you have really been given this opportunity!\n\nNO FAIR !?!? Why Don't I ever get this Opportunity!");
		if(clickCount == 1)	
			dialogString = ("Anyways, you should go to town because some people there wanted to see you.");
		if(clickCount == 2)
			dialogString = ("They were wandering and asking questions for some strange reason.");
		if(clickCount == 3)
			dialogString = ("Is everything okay, Suni?");
		if(clickCount == 4)


	
	}

	public void OnClick(){
		clickCount++;
	}
}
