//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Objects
{

internal enum HorseType
{
	Standard,
	Pedal,
	Rocket
}

[CreateAssetMenu(fileName = "New Horse", menuName = "Horse", order = 52)]
public class HorseObject : ScriptableObject {
	[Multiline][SerializeField] string description = "";
	[SerializeField] float horsePower;
	[SerializeField] HorseType horseType = HorseType.Standard;
	[SerializeField] float speed;
}

}