using UnityEngine;
using XboxCtrlrInput;

public class HorseController : MonoBehaviour {
	////(Should be) attached to the horse
	//Controls the movement of the horse
	//Manual physics

	public float mass = 800f;	 	//kg
	public float linearForce = 25000f;	//Newtons
	public float drag = 0.5f;		//Percentage?

	public XboxController controller;

	[HideInInspector] public Vector3 force;
	[HideInInspector] public Vector3 accel;
	[HideInInspector] public Vector3 vel;
	[HideInInspector] public Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {

		//Move forward
		var forward = XCI.GetAxis(XboxAxis.RightTrigger, controller);
		var backward = XCI.GetAxis(XboxAxis.LeftTrigger, controller);
		AddForce(transform.forward * linearForce * forward * Time.deltaTime);
		AddForce(-transform.forward * linearForce * backward * Time.deltaTime);

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		//Do physics
		DoPhysics();		

		Debug.Log("force: "+force + ", accel: "+accel + ", vel: "+vel);
	}

    private void DoPhysics()
    {
		accel = force / mass;
		vel = vel + accel * Time.fixedDeltaTime;
		ApplyDrag();
		transform.localPosition += vel * Time.fixedDeltaTime;
    }

    void AddForce(Vector3 newForce) {
		force = newForce;
	}

	void ApplyDrag() {
		force *= drag;
	}
}
