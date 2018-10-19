//Tony Le
//14 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights {

public class HorseController : MonoBehaviour {
	////Attach to the horse

	[Header("Gamepad Controls")]
	[SerializeField] XboxController controller;
	[SerializeField] XboxAxis inputAccel = XboxAxis.RightTrigger;
	[SerializeField] XboxAxis forward;
	[SerializeField] XboxAxis backward;


	[Header("Lerp")]
	[SerializeField] float speed = 50;
	[SerializeField] float tValue = 0.025f;
	private Vector3 tarPos;

	void Start () {
		//Get the current position of the object
		tarPos = transform.position;
	}

	void Update()
	{
		//Move
		LerpMove();
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

	void ResetPlayers()
	{
		//Reset to start position if reset triggers are hit		


	}


}

}