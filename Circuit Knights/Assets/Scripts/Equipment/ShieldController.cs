using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{

public class ShieldController : MonoBehaviour {
	////Attach this to the shield

	public enum InputType {
		LeftTrigger,
		XButton
	}

	public InputType inputType;

	public Vector3 maxBlockOffset;		//The max offset of where the shield will 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset;

		switch (inputType) {
			case InputType.LeftTrigger:
				offset = maxBlockOffset * Input.GetAxis("Left Trigger");
				transform.localPosition = offset;				
			break;
			case InputType.XButton:

				var mult = Input.GetAxis("Fire");
				transform.localPosition = Vector3.one * mult * Time.deltaTime;	
			break;
		}
	}
}

}