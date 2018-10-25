using UnityEngine;
using UnityEditor;

namespace CircuitKnights
{

[CreateAssetMenu(fileName = "New Lance", menuName = "Equipment/Lance", order = 50)]
public class LanceObject : ScriptableObject {

	// public string name;
	[SerializeField] float mass = 25f;
	[SerializeField] float length = 3.3f;
	[Tooltip("Decreases the lance controller's lerp effect")][SerializeField] float control = 1f;


}

}