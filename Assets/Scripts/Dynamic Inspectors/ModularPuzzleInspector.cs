using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(ModularPuzzle))]
public class ModularPuzzleInspector :Editor {

	private ModularPuzzle puzzle;
	void OnEnable () {
		puzzle = target as ModularPuzzle;
//		Undo.undoRedoPerformed += RefreshCreator;
	}
	
	void OnDisable () {
//	Undo.undoRedoPerformed -= RefreshCreator;
	}
	public override void OnInspectorGUI (){
		EditorGUI.BeginChangeCheck();
		DrawDefaultInspector();
		if (EditorGUI.EndChangeCheck() && Application.isPlaying){
			(target as ModularPuzzle).InspectorChange();
		}
	}
}
