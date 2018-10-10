//Tony Le
//5 Oct 2018

using System;
using UnityEngine;
using UnityEngine.UI;

namespace CircuitKnights
{

public class PlayerLeanAndDodge : MonoBehaviour 
{
	///To be placed on the player's object

	public ControllerAxis axis;
	// public float leanForce;

	//Dodging is just the player shifting
	public bool canDodge = true;
	public float dodgeMultiplier = 0.25f;		//Metres

	//Leaning is the player rotating
	public bool canLean = true;
	public float leanMultiplier = 30f;			//Degrees
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

		if (axis == ControllerAxis.LeftThumbStick)
		{
			if (canDodge) {
				//Get the lean offset from horizontal and verticals
				dodgeOffset.x = Input.GetAxis("Horizontal") * dodgeMultiplier;
				dodgeOffset.z = -Input.GetAxis("Vertical") * dodgeMultiplier;
				dodgeOffset.y = transform.localPosition.y;

				// Debug.Log("Lean offset: " + leanOffset);
				transform.localPosition = dodgeOffset;
			}
            
            if (canLean)
			{
				///Apply torque on the rigidbodies
				//Horizontal (Z axis)
				leanTorque.x = -Input.GetAxis("Horizontal") * leanMultiplier;
				//Vertical (X axis)
				leanTorque.z = Input.GetAxis("Vertical") * leanMultiplier;
				leanTorque.y = 0;

                Debug.Log("LeanTorque: " + leanTorque);
				playerRB.AddTorque(leanTorque);
			}
		}
		else if (axis == ControllerAxis.RightThumbStick)
		{
			if (canDodge)
			{
				//Get the lean offset from horizontal and verticals
				dodgeOffset.x = Input.GetAxis("Right TS Horizontal") * dodgeMultiplier;
				dodgeOffset.z = -Input.GetAxis("Right TS Vertical") * dodgeMultiplier;
				dodgeOffset.y = transform.localPosition.y;

				transform.localPosition = dodgeOffset;
			}

			if (canLean)
			{
				///Apply torque on the rigidbodies
				//Horizontal (Z axis)
				leanTorque.x = -Input.GetAxis("Right TS Horizontal") * leanMultiplier;
				//Vertical (X axis)
				leanTorque.z = Input.GetAxis("Right TS Vertical") * leanMultiplier;
				leanTorque.y = 0;

                Debug.Log("LeanTorque: " + leanTorque);
				playerRB.AddRelativeTorque(leanTorque);
			}
		}
		
	}
	

}

}