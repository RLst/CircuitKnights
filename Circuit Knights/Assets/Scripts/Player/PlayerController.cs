using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


namespace CircuitKnights 
{

public class PlayerController : MonoBehaviour
{

    [Header("Temp")]
    private Rigidbody rb;

    //Controller
    public XboxController controller;
    public XboxAxis xAxis;
    public XboxAxis zAxis;
    public bool canLean = true;
    public bool canDodge = false;


    //Lean
    public float leanTorque = 50f;      //Linear torque

    //Dodge
    public float dodgeForce = 50f;


    //Return
    public float returnSmoothness = 5f;     //Lerp back to zero


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //Handle lean
        Lean();
		

        //Constantly apply torque to "seek" toward centre
		// Centre();

        TestRotate();
    }

    private void TestRotate()
    {
		//Keypad 0
        if (Input.GetKey(KeyCode.Keypad0))
            transform.Rotate(10, 0, 0);
    }

    private void Lean()
    {
		///Leaning
	    if (canLean)
        {
            ///Forward and back
            //Xbox
            rb.AddRelativeTorque(transform.forward * leanTorque * XCI.GetAxis(zAxis, controller) * Time.fixedDeltaTime);

            //Keyboard
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeTorque(-transform.forward * leanTorque);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeTorque(transform.forward * leanTorque);
            }

            ///Left and right
            //Xbox
            rb.AddRelativeTorque(transform.right * leanTorque * XCI.GetAxis(xAxis, controller) * Time.fixedDeltaTime);

            //Keyboard
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddRelativeTorque(transform.right * leanTorque);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeTorque(-transform.right * leanTorque);
            }

        }
    }

	private void Dodge()
	{
		///Dodging
        if (canDodge)
        {

        }
	}

	private void Centre() {
        ///Lerp back to centre
        //Get current rotations
        var currentRotation = transform.rotation;
        var targetRotation = Quaternion.identity;

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, returnSmoothness * Time.fixedDeltaTime);
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

}