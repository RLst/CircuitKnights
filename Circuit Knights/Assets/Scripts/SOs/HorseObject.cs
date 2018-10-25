using UnityEngine;

namespace CircuitKnights
{

internal enum HorseType
{
	Standard,
	Pedal,
	Rocket
}

[CreateAssetMenu(fileName = "New Horse", menuName = "Horse", order = 49)]
public class HorseObject : ScriptableObject {
	[SerializeField] float horsePower;
	[SerializeField] HorseType horseType = HorseType.Standard;
}

}