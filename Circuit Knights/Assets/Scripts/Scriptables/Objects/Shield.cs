//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Objects
{

[CreateAssetMenu(fileName = "New Shield", menuName = "Shield", order = 54)]
public class Shield : ScriptableObject {
	[SerializeField] float mass = 10f;
	[SerializeField] float size;
	[SerializeField] int durability = 100;

}

}