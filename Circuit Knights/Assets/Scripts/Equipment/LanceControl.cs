//Tony Le
//3 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {


public class LanceControl : MonoBehaviour {

	[Header("Controls")]
	public XboxController controller;
	public XboxAxis vertical = XboxAxis.RightStickY;		//for pitch
	public XboxAxis horizontal = XboxAxis.RightStickX;		//for yaw

	[Header("Lance Physics")]
	//Some of these should be split up into a separate Lance.cs scriptable objects
	public float mass = 20f;		//kg			
	public float length = 3.3f;		//metres
	float momentOfInertia;		//kg.m2
	public float pitchTorque = 40000;
	public float yawTorque = 40000;
	Vector3 angAccel;
	Vector3 angVel;
	Vector3 angPos;
	public float angDrag = 1.065f;		//2 = half

	[Header("Lance Limits")]
	public float minPitchAngle = -10f;
	public float maxPitchAngle = 50f;
	public float minYawAngle = 120f;
	public float maxYawAngle = 190f;


	void Start() {
		//Set the initial lance orientation
		angPos = transform.localRotation.eulerAngles;

		//Calculate the lance's moment of inertia
		momentOfInertia = 1f / 3f * mass * length * length;
	}

	void Update()
	{
		var deltaTime = Time.deltaTime;

		//Get controller inputs
		var v = XCI.GetAxisRaw(vertical, controller);
		var h = XCI.GetAxisRaw(horizontal, controller);
		Debug.Log("vertical: "+v + " horizonal: "+h);

		//Calc angular accel
		angAccel.x += v * pitchTorque / momentOfInertia * deltaTime;
		angAccel.y += h * yawTorque / momentOfInertia * deltaTime;
		Debug.Log("MOI: "+momentOfInertia);
		Debug.Log("angAccel: " + angAccel);

		//Calc angular vel
		angVel.x += angAccel.x * deltaTime;
		angVel.y += angAccel.y * deltaTime;
		Debug.Log("angVel: " + angVel);

		//Calc angular pos
		angPos.x += angVel.x * deltaTime;
		angPos.y += angVel.y * deltaTime;
		Debug.Log("angPos: " + angPos);

		//Apply drag by reducing the accel and vel
		angDrag = Mathf.Clamp(angDrag, 1f, 10f);
		angAccel = angAccel / angDrag;
		angVel /= angDrag;

		//Clamp
		angPos.x = Mathf.Clamp(angPos.x, minPitchAngle, maxPitchAngle);
		angPos.y = Mathf.Clamp(angPos.y, minYawAngle, maxYawAngle);
		angPos.z = 0f;

		//Apply rotation
		transform.localRotation = Quaternion.Euler(angPos);
	}

}

}
