//Tony Le
//14 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {

public class HorseController : MonoBehaviour {
	////Attach to the horse

	// [Header("Move Mode")]
	// public bool usingLerp = true;

	public string EndOfTrackTag = "TrackEnd";

	[Header("Gamepad Controls")]
	public XboxController controller;
	public XboxAxis inputAccel = XboxAxis.RightTrigger;
	public XboxAxis forward;
	public XboxAxis backward;


	[Header("Lerp")]
	public float speed = 50;
	public float tValue = 0.025f;
	private Vector3 tarPos;

	void Start () {
		//Get the current position of the object
		tarPos = transform.position;
	}

	void Update()
	{
		//Move
		LerpMove();

		//Check 
	}

	void LerpMove()
	{		
		//Controller
		var accel = XCI.GetAxis(inputAccel, controller);

		//Keyboard
		if (Input.GetKey(KeyCode.Space)) {
			accel = speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.B)) {
			accel = -speed * Time.deltaTime;
		}

		//Adjust the target position
		tarPos += transform.forward * speed * accel * Time.deltaTime;
		
		//Clamp lerp
		tValue = Mathf.Clamp01(tValue);

		//Lerp towards it
		transform.position = Vector3.Lerp(transform.position, tarPos, tValue);

		// Debug.Log("cur: "+transform.position + "tar: "+tarPos);
	}


}

}


// 	void Update() {
// 		//Move forward
// 		var forward = XCI.GetAxis(XboxAxis.RightTrigger, controller);
// 		var backward = XCI.GetAxis(XboxAxis.LeftTrigger, controller);
// 		AddForce(transform.forward * linearForce * forward * Time.deltaTime);
// 		AddForce(-transform.forward * linearForce * backward * Time.deltaTime);
// 	}

// 	// Update is called once per frame
// 	void FixedUpdate () {
		
// 		//Do physics
// 		DoPhysics();

// 		Debug.Log("force: "+force + ", accel: "+accel + ", vel: "+vel);
// 	}

//     private void DoPhysics()
//     {
// 		accel = force / mass;
// 		vel = vel + accel * Time.fixedDeltaTime;
// 		ApplyDrag();
// 		transform.localPosition += vel * Time.fixedDeltaTime;
//     }

//     void AddForce(Vector3 newForce) {
// 		force = newForce;
// 	}

// 	void ApplyDrag() {
// 		AddForce(-force * drag);
// 	}
// }
