//Duckbike
//Tony Le
//4 Oct 2018

using UnityEngine;

namespace CircuitKnights.Objects
{

[CreateAssetMenu(fileName = "New Knight", menuName = "Knight", order = 51)]
public class KnightObject : ScriptableObject
{
	////To be placed on each player object, maybe in the root object

	///Player stats
	[SerializeField] float health = 100;      //Float because it is more flexible (can handle division more cleanly)
	[SerializeField] float torsoHealth = 100;
	[SerializeField] float leftArmHealth = 100;
	[SerializeField] float rightArmHealth = 100;
	[SerializeField] float headHealth = 100;
	[SerializeField] float TotalHealth
	{
		get
		{
			return torsoHealth + leftArmHealth + rightArmHealth + headHealth;
		}
	}

	//bunch of example player stats
	[SerializeField] float strength;
	[SerializeField] float defence;
	[SerializeField] float power;
	[SerializeField] float speed;
	[SerializeField] float electricalResistance;
	[SerializeField] float electricalPower;

	public void TakeDamage(float damageTaken)
	{
		health -= damageTaken;

		//Kill the player automatically if 0 health
		if (health <= 0)
			Kill();
	}

	public void Kill()
	//Kills the player instantly
	{
		///Turn player to ragdoll?

		///Run death animations?

		///Trigger slow motion and cinematic cameras?
	}
}
}

