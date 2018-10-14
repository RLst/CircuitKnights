//Tony Le
//2 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights
{

    public class BasicPlayerController : MonoBehaviour {
	public float accelForce = 24000f;		//N, Roughly 1 hp

	public XboxController controller;

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

		//Acceleration pulse
		rb.AddForce(transform.forward * XCI.GetAxis(XboxAxis.RightTrigger) * accelForce);
		rb.AddForce(-transform.forward * XCI.GetAxis(XboxAxis.LeftTrigger) * accelForce);
	}

}

}