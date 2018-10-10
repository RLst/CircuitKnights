﻿//Tony Le
//3 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights {

public class LanceControl : MonoBehaviour {

	public ControllerAxis axis;

	public float lanceHorizontalSpeed = 1f;
	public float lanceVerticalSpeed = 1f;

	// Update is called once per frame
	void FixedUpdate () {
		var rb = GetComponent<Rigidbody>();

		////Left Thumb Stick
		if (axis == ControllerAxis.LeftThumbStick)
		{
			//Vertical
			var vertical = Input.GetAxis("Vertical") * lanceVerticalSpeed;
			transform.Rotate(0, 0, -vertical);
			
			//Horizontal
			var horizontal = Input.GetAxis("Horizontal") * lanceHorizontalSpeed;
			transform.Rotate(-horizontal, 0, 0);
		}
		////Right Thumb Stick
		else if (axis == ControllerAxis.RightThumbStick)
		{
			//Vertical
			var vertical = Input.GetAxis("Right TS Vertical") * lanceVerticalSpeed;
			transform.Rotate(0, 0, -vertical);
			
			//Horizontal
			var horizontal = Input.GetAxis("Right TS Horizontal") * lanceHorizontalSpeed;
			transform.Rotate(-horizontal, 0, 0);
		}
		
	}
}

}