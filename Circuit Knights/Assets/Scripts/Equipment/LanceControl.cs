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
	public XboxAxis vertical;		//for pitch
	public XboxAxis horizontal;		//for yaw

	[Header("Lance Properties")]
	public LerpMode lerpMode = LerpMode.slerp;
	public float weighting = 0.02f;
	public float pitchSpeed = 80f;
	public float yawSpeed = 100f;

	[Header("Lance Limits [WORKINPROGRESS]")]
	public float minPitchAngle = 60f;
	public float maxPitchAngle = 120f;
	public float minYawAngle = 85f;
	public float maxYawAngle = 140f;

	private Quaternion tarAng;


	void Start() {
		//Set the initial lance orientation
		tarAng = transform.rotation;
	}

	void Update()
	{
		//Get controller inputs
		var v = XCI.GetAxisRaw(vertical, controller);
		var h = XCI.GetAxisRaw(horizontal, controller);
		var deltaTime = Time.deltaTime;

		//Lance target rotation
		tarAng *= Quaternion.Euler(-h * yawSpeed * deltaTime, 0f, v * pitchSpeed * deltaTime);			////!!!! Need the artists to fix the lance's pivot rotation
		// tarAng *= Quaternion.Euler(v * pitchSpeed * deltaTime, -h * yawSpeed * deltaTime, 0f);
		 
		//Lerp the lance
		switch (lerpMode)
		{
			case LerpMode.lerp: transform.rotation = Quaternion.Lerp(transform.rotation, tarAng, weighting); break;
			case LerpMode.slerp: transform.rotation = Quaternion.Slerp(transform.rotation, tarAng, weighting); break;
		}

		//Limit the lance [WORK IN PROGRESS]
		// var yawAngClamp = Mathf.Clamp(transform.rotation., Quaternion.)
		// var pitchAngClamp
		//  = Mathf.Clamp(transform.eulerAngles.z, minPitchAngle, maxPitchAngle); 
		//  = Mathf.Clamp(transform.eulerAngles.x, minYawAngle, maxYawAngle);
		// transform.rotation.eulerAngles.Set(yawAngClamp, 0f, pitchAngClamp);

	}

}

}
