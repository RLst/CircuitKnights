//Tony Le
//3 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {

public enum LerpMode {
	lerp,
	slerp
}

public class LanceControl : MonoBehaviour {

	[Header("Controls")]
	public XboxController controller;
	public XboxAxis vertical = XboxAxis.RightStickY;		//for pitch
	public XboxAxis horizontal = XboxAxis.RightStickX;		//for yaw

	[Header("Lance Physics")]
	public float momentOfInertia = 2f;		//kg.m2
	public float pitchTorque = 10000;
	public float yawTorque = 10000;
	Vector3 angAccel;
	Vector3 angVel;
	Vector3 angPos;
	public float angDrag = 1.1f;		//2 = half
	public float angDragThreshold = 0.01f;

	[Header("Lance Properties [PHASING OUT]")]
	public LerpMode lerpMode = LerpMode.slerp;
	public float weighting = 0.02f;
	public float pitchSpeed = 80f;
	public float yawSpeed = 100f;

	[Header("Lance Limits [WORKINPROGRESS]")]
	public float minPitchAngle = -10f;
	public float maxPitchAngle = 50f;
	public float minYawAngle = 120f;
	public float maxYawAngle = 190f;


	void Start() {
		//Set the initial lance orientation
		angPos = transform.eulerAngles;
	}

	void Update()
	{
		var deltaTime = Time.deltaTime;

		//Get controller inputs
		var v = XCI.GetAxisRaw(vertical, controller);
		var h = XCI.GetAxisRaw(horizontal, controller);
		Debug.Log("v: "+v + " h: "+h);

		//Calc angular accel
		angAccel.x += v * pitchTorque / momentOfInertia * deltaTime;
		angAccel.y += h * yawTorque / momentOfInertia * deltaTime;
		Debug.Log("angAccel: " + angAccel);

		//Calc angular vel
		angVel.x += angAccel.x * deltaTime;
		angVel.y += angAccel.y * deltaTime;
		Debug.Log("angVel: " + angVel);

		//Calc angular pos
		angPos.x += angVel.x * deltaTime;
		angPos.y += angVel.y * deltaTime;
		Debug.Log("angPos: " + angPos);
	
		transform.localRotation = Quaternion.Euler(angPos);

		//Apply drag by reducing the accel and vel
		angAccel = angAccel / angDrag;
		angVel /= angDrag;

		//Clamp
		angPos.x = Mathf.Clamp(angPos.x, minPitchAngle, maxPitchAngle);
		angPos.y = Mathf.Clamp(angPos.y, minYawAngle, maxYawAngle);
		angPos.z = 0f;


		//Richard's suggestion
		//Add velocity to rotation
		//drag
		//clamp


		//Add delta roation (based on input) to velocity
		// Vector3 rot = transform.eulerAngles;
		// rot.x += v * deltaTime * yawSpeed;
		// rot.y += h * deltaTime * pitchSpeed;
		

		// transform.rotation = Quaternion.Euler(rot);

		//Lance target rotation
		// tarAng *= Quaternion.Euler(-h * yawSpeed * deltaTime, 0f, v * pitchSpeed * deltaTime);			////!!!! Need the artists to fix the lance's pivot rotation
		//tarAng *= Quaternion.Euler(v * pitchSpeed * deltaTime, h * yawSpeed * deltaTime, 0f);

		////Temp - Revision
		/*
		//Linear motion
		force = mass * accel;
		accel = force / mass;
		vel = vel + accel * dt;
		pos = pos + vel * dt;

		//Rotational motion
		torque = momentOfInertia  * angAccel <=> 
		angAccel = torque / momentOfInertia;
		angVel = angVel + angAccel * dt;
		angPos = angPos + angVel * dt;

		 */

		// angDrag = Mathf.Clamp(angDrag, 0.01f, 1000f);
		// if (angAccel.x != 0f)
		// {
		// 	angAccel.x /= angDrag;
		// 	if (angAccel.x < angDragThreshold)
		// 		angAccel.x = 0f;
		// }
		// if (angAccel.y != 0f) {
		// 	angAccel.y /= angDrag;
		// 	if (angAccel.y < angDragThreshold)
		// 		angAccel.y = 0f;
		// }
		// if (angVel.x != 0f) {
		// 	angVel.x = angVel.x / angDrag;
		// 	if (angVel.x < angDragThreshold)
		// 		angVel.x = 0f;
		// }
		// if (angVel.y != 0f) {
		// 	angVel.y /= angDrag;
		// 	if (angVel.y < angDragThreshold)
		// 		angVel.y = 0f;
		// }
		// Debug.Log("angDrag: "+angDrag);

		//Lerp the lance
		//switch (lerpMode) 
		//{
		//	case LerpMode.lerp: transform.rotation = Quaternion.Lerp(transform.rotation, tarAng, weighting); break;
		//	case LerpMode.slerp: transform.rotation = Quaternion.Slerp(transform.rotation, tarAng, weighting); break;
		//}

		//Limit the lance [WORK IN PROGRESS]
		// var yawAngClamp = Mathf.Clamp(transform.rotation., Quaternion.)
		// var pitchAngClamp
		//  = Mathf.Clamp(transform.eulerAngles.z, minPitchAngle, maxPitchAngle); 
		//  = Mathf.Clamp(transform.eulerAngles.x, minYawAngle, maxYawAngle);
		// transform.rotation.eulerAngles.Set(yawAngClamp, 0f, pitchAngClamp);

	}

}

}
