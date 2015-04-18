using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	void Awake()
	{

	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
	public void LoadScene(string loadName)
	{
		Application.LoadLevel(loadName);
	}

	public void MenuQuit()
	{
		Application.Quit();
	}

	// Update is called once per frame
	void Update () {
	
	}
}