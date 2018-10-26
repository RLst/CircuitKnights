//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using UnityEditor;

namespace CircuitKnights.Events
{

[CustomEditor(typeof(GameEvent))]
public class EventEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GUI.enabled = Application.isPlaying;

		GameEvent e = target as GameEvent;
		if (GUILayout.Button("Raise"))
			e.Raise();
	}
}

}