//Tony Le
//3 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights {

public class LanceControl : MonoBehaviour {

	public ControllerAxis axis;

	public float lanceHorizontalSpeed = 1f;
	public float lanceVerticalSpeed = 1f;

	public float[] yLimits = {60f, 120f};
	public float[] zLimits = {85f, 140f};

	// Update is called once per frame
	void FixedUpdate () {
		var rb = GetComponent<Rigidbody>();

		////Left Thumb Stick
		if (axis == ControllerAxis.LeftThumbStick)
		{
			//Vertical
			var vertical = Input.GetAxis("Vertical Left") * lanceVerticalSpeed;
			transform.Rotate(0, 0, -vertical);
			
			//Horizontal
			var horizontal = Input.GetAxis("Horizontal Left") * lanceHorizontalSpeed;
			transform.Rotate(-horizontal, 0, 0);
		}
		////Right Thumb Stick
		else if (axis == ControllerAxis.RightThumbStick)
		{
			//Vertical
			var vertical = Input.GetAxis("Vertical Right") * lanceVerticalSpeed;
			transform.Rotate(0, 0, -vertical);
			
			//Horizontal
			var horizontal = Input.GetAxis("Horizontal Right") * lanceHorizontalSpeed;
			transform.Rotate(-horizontal, 0, 0);
		}
		
		//Limit the lance angle
		Mathf.Clamp(transform.rotation.y, yLimits[0], yLimits[1]);
		Mathf.Clamp(transform.rotation.z, zLimits[0], zLimits[1]);

	}
}

}