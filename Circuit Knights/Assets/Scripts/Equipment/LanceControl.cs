//Tony Le
//3 Oct 2018

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {

[RequireComponent(typeof(Rigidbody))]
public class LanceControl : MonoBehaviour 
{
	////Handle lance aim and lunge?

	[SerializeField] LanceObject lance;

	[Header("Controls")]
	[SerializeField] XboxController controller;
	[SerializeField] XboxAxis vertical = XboxAxis.RightStickY;		//for pitch
	[SerializeField] XboxAxis horizontal = XboxAxis.RightStickX;		//for yaw

	[Header("Lance Physics")]
	//Some of these should be split up into a separate Lance.cs scriptable objects
	[Tooltip("[kg] Does not update during play")][SerializeField] float mass = 20f;			
	[Tooltip("[metres] Does not update during play")][SerializeField] float length = 3.3f;
	float momentOfInertia;		//kg.m2
	[SerializeField] float yawTorque = 50000;
	[SerializeField] float pitchTorque = 50000;
	[SerializeField] float gravityFactor = 300f;	
	Vector3 angAccel;
	Vector3 angVel;
	Vector3 angPos;
	[SerializeField] float angDrag = 1.05f;

	[Header("Lance Limits")]
	[SerializeField] float minPitchAngle = -15f;
	[SerializeField] float maxPitchAngle = 80f;
	[SerializeField] float minYawAngle = 120f;
	[SerializeField] float maxYawAngle = 190f;


	void Start() {
		//Set the initial lance orientation
		angPos = transform.localRotation.eulerAngles;

		//Calculate the lance's moment of inertia
		momentOfInertia = 1f / 3f * mass * length * length;

		//Also sets the lance rigidbody weight too
		GetComponent<Rigidbody>().mass = mass;
	}

	void Update()
	{
		HandleLanceAim();
		ClampLanceMovement();
		ApplyTransform();

		// //Debugs
		// Debug.Log("vertical: " + v + " horizonal: " + h);
		// Debug.Log("MOI: " + momentOfInertia);
		// Debug.Log("angAccel: " + angAccel);
		// Debug.Log("angVel: " + angVel);
		// Debug.Log("angPos: " + angPos);
	}

    private void HandleLanceAim()
	{
		//Get controller inputs
		var v = XCI.GetAxisRaw(vertical, controller);
		var h = XCI.GetAxisRaw(horizontal, controller);

		//Todo - might conflict with xbox controller
		//DEBUG - Keyboard controls
		v += Input.GetAxis("Vertical");
		h += Input.GetAxis("Horizontal");
		////////////////////////////////

		//Calc angular accel
		angAccel.x += v * pitchTorque / momentOfInertia * Time.deltaTime;
		angAccel.y += h * yawTorque / momentOfInertia * Time.deltaTime;

		//Apply "gravity"
		angAccel.x -= gravityFactor * Time.deltaTime;

		//Calc angular vel
		angVel.x += angAccel.x * Time.deltaTime;
		angVel.y += angAccel.y * Time.deltaTime;

		//Calc angular pos
		angPos.x += angVel.x * Time.deltaTime;
		angPos.y += angVel.y * Time.deltaTime;

		//Apply drag by reducing the accel and vel
		angDrag = Mathf.Clamp(angDrag, 1f, 10f);
		angAccel = angAccel / angDrag;
		angVel /= angDrag;
	}

	private void ClampLanceMovement()
	{
		angPos.x = Mathf.Clamp(angPos.x, minPitchAngle, maxPitchAngle);
		angPos.y = Mathf.Clamp(angPos.y, minYawAngle, maxYawAngle);
		angPos.z = 0f;
	}

	private void ApplyTransform()
	{
		transform.localRotation = Quaternion.Euler(angPos);
	}


}

}