//Tony Le
//4 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{
public class Player : ScriptableObject
{

	////To be placed on each player object, maybe in the root object

	///Player stats
	public float health = 100;      //Float because it is more flexible (can handle division more cleanly)
	public float torsoHealth = 100;
	public float leftArmHealth = 100;
	public float rightArmHealth = 100;
	public float headHealth = 100;
	public float TotalHealth
	{
		get
		{
			return torsoHealth + leftArmHealth + rightArmHealth + headHealth;
		}
	}

	//bunch of example player stats
	public float strength;
	public float defence;
	public float power;
	public float speed;
	public float electricalResistance;
	public float electricalPower;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

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

