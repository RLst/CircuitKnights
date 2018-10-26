//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using UnityEditor;

namespace CircuitKnights.Objects
{

[CreateAssetMenu(fileName = "New Lance", menuName = "Lance", order = 53)]
public class LanceObject : ScriptableObject {

	// public string name;
	public float mass = 25f;
	public float length = 3.3f;
	[Tooltip("Increase control by decreasing lerp")] public float control = 1f;
}

}