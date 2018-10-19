//Tony Le
//14 Oct 2018

using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.SceneManagement;

namespace CircuitKnights {

public class HorseController : MonoBehaviour {
	////Attach to the horse

	[Header("Gamepad Controls")]
	[SerializeField] XboxController controller;
	[SerializeField] XboxAxis accelerate = XboxAxis.RightTrigger;
	[Tooltip("FOR DEBUGGING PURPOSES")][SerializeField] XboxButton decelerate = XboxButton.B;

	[Header("Lerp")]
	[SerializeField] float speed = 50;
	[SerializeField] float tValue = 0.025f;
	private Vector3 tarPos;

	bool isEnabled = true;

	//For reset
	Vector3 startPosition;

	void Start () {
		//Get the current position of the object
		tarPos = transform.position;

		//Save the initial starting position
		startPosition = transform.position;
	}

	void Update()
	{
		if (isEnabled)
		{
			//Move
			LerpMove();
		}
	}

	void OnRoundStart() {
		isEnabled = true;
	}

	void LerpMove()
	{		
		//Controller
		var accel = XCI.GetAxis(accelerate, controller);

		//Keyboard (debug)
		if (Input.GetKey(KeyCode.Space)) {
			accel = speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.B) || XCI.GetButton(decelerate, controller)) {
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

	void onResetPlayers()
	{
		//Reset to start position if reset triggers are hit		
		transform.position = tarPos = startPosition;
		// SceneManager.LoadScene("Tony");
	}
}

}