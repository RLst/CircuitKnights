//Tony Le
//3 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {

public class LanceControl : MonoBehaviour {

	private Rigidbody rb;

	[Header("Controls")]
	public XboxController controller;
	public XboxAxis vertical;		//Up/Down
	public XboxAxis horizontal;		//Left/Right

	// public ControllerAxis axis;

	[Header("Lance Properties")]
	public float lerpSmoothing = 0.01f;
	public float verticalSpeed = 0.75f;
	public float horizontalSpeed = 1f;


	private Transform tarAng;

	// [Header("Y Axis Limits")]
	// // public float yMin = 60f;
	// // public float yMax = 120f;

	// [Header("Z Axis Limits")]
	// // public float zMin = 85f;
	// // public float zMax = 140f;

	void Start() {
		//Set the initial lance orientation
		tarAng = transform;

		//Get the rigidbody
		// rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//Get controller inputs
		var v = XCI.GetAxis(vertical, controller);
		var h = XCI.GetAxis(horizontal, controller);

		// //Aim the lance asdfasdfasdfasdfs
		// var xAxis = 

		// tarAng.rotation.eulerAngles = Quaternion.EulerAngles.

		//Do the rotation
		transform.rotation = Quaternion.Lerp(transform.rotation, tarAng.rotation, lerpSmoothing);

	}

	void FixedUpdate () {

		//Get the controller axis input values
		var v = XCI.GetAxis(vertical, controller);		//X axis
		var h = XCI.GetAxis(horizontal, controller);	//Y axis

		//Move the lance using physics
		rb.AddRelativeTorque(v * verticalSpeed, h * horizontalSpeed, 0f);

		// ////Left Thumb Stick
		// if (axis == ControllerAxis.LeftThumbStick)
		// {
		// 	//Vertical
		// 	var vertical = Input.GetAxis("Vertical") * lanceVerticalSpeed;
		// 	transform.Rotate(0, 0, -vertical);
			
		// 	//Horizontal
		// 	var horizontal = Input.GetAxis("Horizontal") * lanceHorizontalSpeed;
		// 	transform.Rotate(-horizontal, 0, 0);
		// }
		
		// //Limit the lance angle
		// transform.position Mathf.Clamp(transform.rotation.y, yMin, yMax);
		// Mathf.Clamp(transform.rotation.z, zMin, zMax);

	}
}

}