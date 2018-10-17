//Tony Le
//14 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

public class HorseController : MonoBehaviour {
	////(Should be) attached to the horse (or parent of the horse with correct transform)
	//Controls the movement of the horse
	//Manual physics

	private Rigidbody rb;

	[Header("A")]

	public float mass = 800f;	 	//kg
	public float linearForce = 25000f;	//Newtons
	public float drag = 4f;			//Newtons (probably)


	[Header("Gamepad Controls")]
	public XboxController controller;
	public XboxAxis forward;
	public XboxAxis backward;

	[HideInInspector] public Vector3 force;
	[HideInInspector] public Vector3 accel;
	[HideInInspector] public Vector3 vel;
	[HideInInspector] public Vector3 pos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.drag = this.drag;
		rb.mass = this.mass;
	}

	void FixedUpdate() {
		//Get controller inputs
		var fwd = XCI.GetAxis(forward, controller);
		var back = -XCI.GetAxis(backward, controller);

		var combined = fwd + back;

		//Add forward force
		rb.AddForce(transform.forward * linearForce * combined);

		//If the end is reached
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
