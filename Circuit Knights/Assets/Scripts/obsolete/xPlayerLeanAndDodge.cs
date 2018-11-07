//Tony Le
//5 Oct 2018

using System;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

namespace CircuitKnights
{
public class PlayerLeanAndDodge : MonoBehaviour 
{
	///To be placed on the player's object
	[SerializeField] XboxController controller;
	[SerializeField] XboxAxis xAxis;
	[SerializeField] XboxAxis yAxis;
	// public float leanForce;

	//Dodging is just the player shifting
	[SerializeField] bool canDodge = true;
	[SerializeField] float dodgeMultiplier = 0.25f;		//Metres

	//Leaning is the player rotating
	[SerializeField] bool canLean = true;
	[SerializeField] float leanMultiplier = 30f;			//Degrees
	// public float leanSmoothness = 0.5f;			//Lower is more smooth, Higher is less

	private Rigidbody playerRB;

	void Start()
	{
		//Auto grab any necessary components
		playerRB = GetComponent<Rigidbody>();
	}


	void FixedUpdate()
	{
		Lean();
	}


    private void Lean()
	{
		Vector3 dodgeOffset;
		
		Vector3 leanTorque;
		// Vector3 leanOffsetActual;

		if (canDodge) {
			//Get the lean offset from horizontal and verticals
			// dodgeOffset.x = XCI.GetAxis() todo
			dodgeOffset.x = Input.GetAxis("Horizontal Left") * dodgeMultiplier;
			dodgeOffset.z = -Input.GetAxis("Vertical Left") * dodgeMultiplier;
			dodgeOffset.y = transform.localPosition.y;

			// Debug.Log("Lean offset: " + leanOffset);
			transform.localPosition = dodgeOffset;
		}
		
		if (canLean)
		{
			///Apply torque on the rigidbodies
			//Horizontal (Z axis)
			leanTorque.x = -Input.GetAxis("Horizontal Left") * leanMultiplier;
			//Vertical (X axis)
			leanTorque.z = Input.GetAxis("Vertical Left") * leanMultiplier;
			leanTorque.y = 0;

			Debug.Log("LeanTorque: " + leanTorque);
			playerRB.AddTorque(leanTorque);
		}
		
	}
	

}

}