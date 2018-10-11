using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour {
	////(Should be) attached to the horse
	//Controls the movement of the horse
	//Manual physics

	public float mass = 800f;	 	//kg
	public float linearForce = 25000f;	//Newtons
	public float drag = 0.5f;		//Percentage?

	[HideInInspector]
	public Vector3 force;
	[HideInInspector]
	public Vector3 accel;
	[HideInInspector]
	public Vector3 vel;
	[HideInInspector]
	public Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		//Move forward
		if (Input.GetButton("Boost")) {
			Debug.Log("Boost button press");
			AddForce(transform.forward * linearForce * Time.deltaTime);
		}
		// AddForce(transform.forward * linearForce * Input.GetAxis("Right Trigger") * Time.deltaTime);

		//Move backward
		if (Input.GetButton("B")) {
			Debug.Log("B button press");
			AddForce(-transform.forward * linearForce * Time.deltaTime);
		}
		// AddForce(-transform.forward * linearForce * Input.GetAxis("Left Trigger") * Time.deltaTime);
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		//Do physics
		DoPhysics();		

		Debug.Log("force: " + force);
		Debug.Log("accel: " + accel);
		Debug.Log("vel: " + vel);
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
