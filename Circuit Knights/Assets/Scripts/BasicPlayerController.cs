using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour {
	//Attached object needs a rigidbody

	public float turnSpeed = 5f;
	public float accelForce = 24000f;		//N, Roughly 1 hp
	public float turnTorque = 1f;			//Nm

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// var rb = GetComponent<Rigidbody>();
		// //Acceleration pulse
		// if (Input.GetKey(KeyCode.Space))
		// {
		// 	rb.AddForce(transform.forward * accelForce * Time.deltaTime);
		// }
		// //
	}

	void FixedUpdate()
	{
		var rb = GetComponent<Rigidbody>();

		//DEBUG CONTROLS - Turning
		// if (Input.GetKey(KeyCode.LeftArrow))
		// {
		// 	transform.Rotate(0, -turnSpeed, 0);
		// }
		// if (Input.GetKey(KeyCode.RightArrow))
		// {
		// 	transform.Rotate(0, turnSpeed, 0);
		// }


		// var turn = Input.GetAxis("Horizontal");
		// rb.AddTorque(transform.forward * turnTorque *turn);
		// Debug.Log("Turn: " + turn);

		//Acceleration pulse
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(transform.forward * accelForce);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.forward * accelForce);
		}


	}

}
