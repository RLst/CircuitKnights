//Duckbike
//Tony Le
//4 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights.Objects
{

[CreateAssetMenu(fileName = "New Knight", menuName = "Knight", order = 51)]
public class KnightObject : ScriptableObject
{
	[Multiline][SerializeField] string description = "";
	
	[Header("Controls")]
	public XboxController controller;
	public XboxAxis lanceAxisX, lanceAxisY;
	public XboxAxis leanAxisX, leanAxisY;
	public XboxAxis accelAxis;
	public XboxAxis shieldAxis;
	public XboxButton reverseButton;


	[Header("Starting Stats")]
	//These WILL NOT GET MODIFIED DURING RUNTIME
	[SerializeField] float startingHeadHealth;
	[SerializeField] float startingTorsoHealth;
	[SerializeField] float startingLeftArmHealth;
	[SerializeField] float startingRightArmHealth;

	//The stats that externals will actually reference from
	//These are reset at the start of 
	public float HeadHealth { get; set; }
	public float TorsoHealth { get; set; }
	public float LeftArmHealth { get; set; }
	public float RightArmHealth { get; set; }
	float TotalHealth
	{
		get
		{
			return HeadHealth + TorsoHealth + LeftArmHealth + RightArmHealth;
		}
	}


	void OnEnable()
	{
		ResetStats();
	}

	public void ResetStats()
	{
		HeadHealth = startingHeadHealth;
		TorsoHealth = startingTorsoHealth;
		LeftArmHealth = startingLeftArmHealth;
		RightArmHealth = startingRightArmHealth;
	}

    // public void TakeDamage(float damageTaken)
	// {
	// 	health -= damageTaken;

	// 	//Kill the player automatically if 0 health
	// 	if (health <= 0)
	// 		Kill();
	// }

	// public void Kill()
	// //Kills the player instantly
	// {
	// 	///Turn player to ragdoll?

	// 	///Run death animations?

	// 	///Trigger slow motion and cinematic cameras?
	// }
}
}


/*
//bunch of example player stats
[SerializeField] float strength;
[SerializeField] float defence;
[SerializeField] float power;
[SerializeField] float speed;
[SerializeField] float electricalResistance;
[SerializeField] float electricalPower;
*/