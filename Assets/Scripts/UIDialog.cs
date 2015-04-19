using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIDialog : MonoBehaviour {

	public Text dialogText;
	string charName;
	string dialogString;
	// Use this for initialization
	void Start () {
	
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();

		charName = PlayerPrefs.GetString ("charName");
	}
	
	// Update is called once per frame
	void Update () {
		dialogText.text = dialogString;

		dialogString = ("Welcome " + charName + ", How are you doing on this great Sunday Apri 2015?");
	}
}
