using UnityEngine;

public enum HorseType
{
	Standard,
	Pedal,
	Rocket
}
public class Horse : ScriptableObject {
	public float horsePower;
	public HorseType horseType;
}
