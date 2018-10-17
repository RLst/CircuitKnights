using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Temp")]
	public Rigidbody rb;

	public float Ltorque = 50f;		//Linear torque
	
	public float smoothness = 5f;		//Lerp back to zero

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		
	}

	void FixedUpdate() {
		//Constantly apply torque to "seek" toward centre

		//Handle lean
		Lean();

		// TestRotate();
	}

	private void TestRotate() {
		if (Input.GetKey(KeyCode.X))
			transform.Rotate(10, 0, 0);
	}
    private void Lean()
    {
		//Forward and back
		if (Input.GetKey(KeyCode.W)) {
			rb.AddRelativeTorque(-transform.forward * Ltorque);
		}
		if (Input.GetKey(KeyCode.S)) {
			rb.AddRelativeTorque(transform.forward * Ltorque);
		}
		//Left and right
		if (Input.GetKey(KeyCode.A)) {
			rb.AddRelativeTorque(transform.right * Ltorque);
		}    
		if (Input.GetKey(KeyCode.D)) {
			rb.AddRelativeTorque(-transform.right * Ltorque);
		}

		///Lerp back to centre
		//Get current rotations
		var currentRotation = transform.rotation;
		var targetRotation = Quaternion.identity;

		transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, smoothness * Time.fixedDeltaTime);


		// var XA = transform.rotation.x;
		// var ZA = transform.rotation.z;
		// Debug.Log("XA: "+XA + " ZA: "+ZA);

		// var curAngle = new Vector3(XA, 0f, ZA);
		// var tarAngle = new Vector3(0,0,0);

		// var lerpedRotation = Vector3.Lerp(curAngle, tarAngle, smoothness);
		// transform.Rotate(lerpedRotation);


		//Move back to centre
		// var testReturnTorqueMultiplier = 100f;
		// var xAxisReturnTorque = -transform.rotation.x * testReturnTorqueMultiplier;
		// var zAxisReturnTorque = -transform.rotation.z * testReturnTorqueMultiplier;
		// // rb.AddRelativeTorque(xAxisReturnTorque, 0f, zAxisReturnTorque);
		// transform.Rotate(xAxisReturnTorque, 0, zAxisReturnTorque);

	}
}
