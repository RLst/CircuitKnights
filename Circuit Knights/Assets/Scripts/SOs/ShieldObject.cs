using UnityEngine;

namespace CircuitKnights
{

[CreateAssetMenu(fileName = "New Shield", menuName = "Equipment/Shield", order = 50)]
public class ShieldObject : ScriptableObject {
	[SerializeField] float mass = 10f;
	[SerializeField] float size;
	[SerializeField] int durability = 100;

}

}