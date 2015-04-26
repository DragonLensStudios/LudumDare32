using UnityEngine;
using System.Collections;


public class MusicSwitcher : MonoBehaviour {
	
	public Transform target;
	public int audiosourcestop;
	public int audiosourceplay;
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.transform == target)
		{
		GetComponents<AudioSource>()[audiosourcestop].Stop();
		GetComponents<AudioSource>()[audiosourceplay].Play();
		}
	}
}

