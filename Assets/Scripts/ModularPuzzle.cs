using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class ModularPuzzle : MonoBehaviour {

	public GameObject player_object;
	public GameObject puzzle_object;

	public ChoosePuzzleType puzzle_type;
	//Variable Type List Toggles.
	public bool puzzle_variable_int_type;
	public bool puzzle_variable_float_type;
	public bool puzzle_variable_string_type;
	public bool puzzle_variable_bool_type;
	public bool puzzle_variable_gameobject_type;


	//Variable Type List Toggles.

	//Variable Lists Hidden Until Togggled
	public List<GameObject> puzzle_gameobject_variables;
	public List<string> puzzle_string_variables;
	public List<int> puzzle_int_variables;
	public List<float> puzzle_float_variables;
	public List<bool> puzzle_bool_variables;
	//public int[] puzzle_variable;
 

	public enum ChoosePuzzleType
	{
		None,
		Box,
		Switch,
		Slider,
		Warp,
		Elemental,
		Directional,
		Custom

	}

	public enum ChoosePuzzleElement
	{
		None,
		Fire,
		Water,
		Ice,
		Lightning,
		Wind
		
	}


	public void InspectorChange()
	{
		//BoxPuzzle();
		//Debug.Log("Inspector Changed!");
	}
	// Use this for initialization
	void Start () {
		player_object = GameObject.FindGameObjectWithTag("Player");
		puzzle_object = gameObject;
		switch (puzzle_type){
		case ChoosePuzzleType.Box:
			BoxPuzzle();
			break;
		case ChoosePuzzleType.Custom:
			CustomPuzzle();
			break;
		default:
			Debug.Log("No Puzzle Configured.");
			break;
		}

	}
	public void BoxPuzzle()
	{
		if (puzzle_object.GetComponent<Rigidbody2D>() == null)
		{
			Rigidbody2D rb_temp =  puzzle_object.AddComponent<Rigidbody2D>();
			rb_temp.gravityScale = 0;
			rb_temp.fixedAngle = true;
		}
		if (puzzle_object.GetComponent<BoxCollider2D>().isTrigger == false)
		{
			BoxCollider2D bctemp = puzzle_object.AddComponent<BoxCollider2D>();
			bctemp.isTrigger = true;
			bctemp.size.Set (.5f, .5f);
		}

		}

	public void OnTriggerEnter2D (Collider2D col)
	{
		Debug.Log("Push!");
	}
//		if (puzzle_object.GetComponent<BoxCollider2D>() != null )
//		{
//			if (puzzle_object.GetComponent<BoxCollider2D>().isTrigger)
//			{
//				Debug.Log ("Found Box Collider 2D");
//			}
//
//		}

	public void CustomPuzzle(){
		Debug.Log ("Custom Puzzle");
	}
	// Update is called once per frame
	void Update () {

	}
}
