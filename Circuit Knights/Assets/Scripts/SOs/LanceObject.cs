using UnityEngine;
using UnityEditor;

namespace CircuitKnights
{

[CreateAssetMenu(fileName = "New Lance", menuName = "Equipment/Lance", order = 50)]
public class LanceObject : ScriptableObject {

	// public string name;
	public float mass = 25f;
	public float length = 3.3f;
	[Tooltip("Increase control by decreasing lerp")] public float control = 1f;
}

}