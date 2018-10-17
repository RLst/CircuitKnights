//Tony Le
//14 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {

public class HorseController : MonoBehaviour {
	////(Should be) attached to the horse (or parent of the horse with correct transform)
	//Controls the movement of the horse
	//Manual physics

	private Rigidbody rb;

	[Header("Move Mode")]
	public bool usingLerp = true;


	[Header("Gamepad Controls")]
	public XboxController controller;
	public XboxAxis inputAccel = XboxAxis.RightTrigger;
	public XboxAxis forward;
	public XboxAxis backward;


	[Header("Lerp")]
	public float speed = 100f;
	public float lerpSmoothness = 0.1f;

	[Header("Physics")]		//Relevant if usingLerp = false;
	public float mass = 800f;	 	//kg
	public float linearForce = 25000f;	//Newtons
	public float drag = 4f;			//Newtons (probably)
	// [HideInInspector] public Vector3 force;
	// [HideInInspector] public Vector3 accel;
	// [HideInInspector] public Vector3 vel;


	// private Vector3 pos;
	private Vector3 tarPos;

	void Start () {
		//Get the current position of the object
		tarPos = transform.position;
		// tarPos = pos;

		//Setup rigidbody
		rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.drag = this.drag;
			rb.mass = this.mass;
		}
	}

	void FixedUpdate() {
		if (!usingLerp) {
			DoUnityPhysics();
		}
	}

	void Update()
	{
		if (usingLerp) {
			DoLerp();
		}
	}

	void DoUnityPhysics()
	{
		//Get controller inputs
		var fwd = XCI.GetAxis(forward, controller);
		var back = -XCI.GetAxis(backward, controller);

		var combined = fwd + back;

		//Add forward force
		rb.AddForce(transform.forward * linearForce * combined);
	}

	void DoLerp()
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
		lerpSmoothness = Mathf.Clamp01(lerpSmoothness);

		//lerp towards it
		Debug.Log("cur: "+transform.position + "tar: "+tarPos);
		transform.position = Vector3.Lerp(transform.position, tarPos, lerpSmoothness);
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
