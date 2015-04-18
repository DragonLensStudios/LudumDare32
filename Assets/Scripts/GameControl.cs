using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {
	
	public static GameControl control;

	
	// Progress Integers Dictionary all integers related to player progress, waypoints, gold, progress int, etc
	public GameIntegersDictionary gameIntegers = new GameIntegersDictionary();

	// Inventory bools
	public GameBoolsDictionary gameBools = new GameBoolsDictionary();
	/* *** Game Progress, to track where player is for events, etc ***
	0: At Game Menu
	1: Game has started

	*/

	// holds strings 

	public GameStringsDictionary gameStrings = new GameStringsDictionary();


	//Autumnos: 6 methods to simplify read/write with the dictionaries
	public static bool readBool(string key){
		bool test;
		if (control.gameBools.TryGetValue(key, out test)){
			return test;
		}
		Debug.Log ("bool var" + key + "was not set in the dictionary upon read.");//Do Not Remove
		return false;
	}
	public static int readInt(string key){
		int test;
		if (control.gameIntegers.TryGetValue(key, out test)){
			return test;
		}
		Debug.Log ("int var" + key + "was not set in the dictionary upon read.");//Do Not Remove
		return 0;
	}
	public static string readString(string key){
		string test;
		if (control.gameStrings.TryGetValue(key, out test)){
			return test;
		}
		Debug.Log ("string var" + key + "was not set in the dictionary upon read.");//Do Not Remove
		return "";
	}
	public static void write(string key, bool data){
		control.gameBools [key] = data;
	}
	public static void write(string key, int data){
		control.gameIntegers [key] = data;
	}
	public static void write(string key, string data){
		control.gameStrings [key] = data;
	}


	void Awake(){
		// If control is null, set to this gameobject
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
			// Check if control exists and delete this one if so
		} else if (control != this) {
			Destroy(gameObject);
		}
		// Try to load
		Load();
	}
	
	public void Save(){
		// Save all data in binary format serialized
		BinaryFormatter bf = new BinaryFormatter ();
		
		// This is the InventoryBoolsDictionary
		FileStream fileInventoryBools = File.Create (Application.persistentDataPath
		                                             + "/saveb.dat");
		bf.Serialize (fileInventoryBools, gameBools);
		fileInventoryBools.Close();
		
		// This is the ContainerStatusDictionary
		FileStream fileContainerStatus = File.Create
			(Application.persistentDataPath + "/saves.dat");
		bf.Serialize (fileContainerStatus, gameStrings);
		fileContainerStatus.Close();
		
		// This is the ProgressIntegersDictionary
		FileStream fileProgressIntegers = File.Create
			(Application.persistentDataPath + "/savei.dat");
		bf.Serialize (fileProgressIntegers, gameIntegers);
		fileProgressIntegers.Close();
	}
	
	public void Load(){
		// Check to see if the file exists (has a save file been created)
		if (File.Exists(Application.persistentDataPath + "/saveb.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath +
			                            "/saveb.dat", FileMode.Open);
			gameBools = (GameBoolsDictionary) bf.Deserialize(file);
			file.Close();
			
		}
		// This is the ContainerStatusDictionary
		if (File.Exists (Application.persistentDataPath + "/saves.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath +
			                             "/saves.dat", FileMode.Open);
			gameStrings = (GameStringsDictionary) bf.Deserialize (file);
			file.Close ();
			
		}
		// This is the ProgressIntegersDictionary
		if (File.Exists (Application.persistentDataPath + "/savei.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath +
			                             "/savei.dat", FileMode.Open);
			gameIntegers = (GameIntegersDictionary) bf.Deserialize (file);
			file.Close ();
		}
	}
	
	// Delete all Save Game files and reset the game
	public void DeleteLocalFiles(){
		
		// Reset all local vars
		ResetAllData ();
		
		if (File.Exists (Application.persistentDataPath + "/saveb.dat")) {
			File.Delete(Application.persistentDataPath + "/saveb.dat");
		}
		if (File.Exists (Application.persistentDataPath + "/saves.dat")) {
			File.Delete(Application.persistentDataPath + "/saves.dat");
		}
		if (File.Exists (Application.persistentDataPath + "/savei.dat")) {
			File.Delete(Application.persistentDataPath + "/savei.dat");
		}
		// Reload the scene
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	// RESET ALL INGAME DATA BACK TO 0
	public void ResetAllData(){
		// Reset all Containers to empty
		foreach (string key in gameStrings) {
			gameStrings[key] = "";
		}
		// Reset all bools
		foreach (string key in gameBools) {
			gameBools[key] = false;
		}
		// Reset all integers
		foreach (string key in gameIntegers) {
			gameIntegers[key] = 0;
		}
	}
}

// The dictionary that saves all bool related to game progress- inventory, grapple hook, sword, shield, etc
	[Serializable]
public class GameBoolsDictionary:SerializableDictionary<string,bool>{}

// The dictionary that saves all integers related to game progress- Waypoints, gold, progress int, etc
	[Serializable]
public class GameIntegersDictionary:SerializableDictionary<string,int>{}

// The dictionary that saves strings like the characters name
	[Serializable]
public class GameStringsDictionary:SerializableDictionary<string,string>{}
