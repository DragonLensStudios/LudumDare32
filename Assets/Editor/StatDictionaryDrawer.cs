using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(GameIntegersDictionary))]
public class IntDictionaryDrawer : SerializableDictionaryDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		base.OnGUI (position, property, label);
	}
}

[CustomPropertyDrawer(typeof(GameBoolsDictionary))]
public class BoolDictionaryDrawer : SerializableDictionaryDrawer {
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		base.OnGUI (position, property, label);
	}
}

[CustomPropertyDrawer(typeof(GameStringsDictionary))]
public class StringDictionaryDrawer : SerializableDictionaryDrawer {
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		base.OnGUI (position, property, label);
	}
}
