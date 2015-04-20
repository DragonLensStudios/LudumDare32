using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {
	
	public string npc_name;
	public GameObject NPC;
	public GameObject MainCharacter;
	public List<string> message_dialog;
	public InteractionNPC talking_player;
	
	
	
	// Use this for initialization
	void Start () {
		NPC = gameObject;
	}
	
	
}
