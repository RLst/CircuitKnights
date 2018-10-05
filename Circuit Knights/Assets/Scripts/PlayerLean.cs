//Tony Le
//5 Oct 2018

using UnityEngine;
using UnityEngine.UI;

namespace CircuitKnights
{

public class PlayerLean : MonoBehaviour {

	///To be placed on the player's object

	public ControllerAxis axis;
	public float leanForce;
	public float t_leanMultiplier = 0.25f;		//Metres
	public float t_leanAngleMultiplier = 45f;	//Degrees


	// private Player player;
	private Vector3 playerCentreOffset;

	void Start()
	{
		//Retrieve components
		// player = GetComponent<GameObject>();
		// player = GetComponent<Player>();

		//Save the player's center location
		// playerCentreOffset = player.transform.localPosition;
	}


	void FixedUpdate()
	{
		Lean();
	}
	

	private void Lean()
	{
		Vector3 leanOffset;
		Vector3 leanAngleOffset;

		if (axis == ControllerAxis.LeftThumbStick)
		{
			//Get the lean offset from horizontal and verticals
			leanOffset.x = Input.GetAxis("Horizontal") * t_leanMultiplier;
			leanOffset.z = Input.GetAxis("Vertical") * t_leanMultiplier;
			leanOffset.y = transform.localPosition.y;

			// Debug.Log("Lean offset: " + leanOffset);
			transform.localPosition = leanOffset;
		}
		else if (axis == ControllerAxis.RightThumbStick)
		{
			//Get the lean offset from horizontal and verticals
			leanOffset.x = Input.GetAxis("Right TS Horizontal") * t_leanMultiplier;
			leanOffset.z = Input.GetAxis("Right TS Vertical") * t_leanMultiplier;
			leanOffset.y = transform.localPosition.y;

			// Debug.Log("Lean offset: " + leanOffset);
			transform.localPosition = leanOffset;
		}
	}
	

}

}