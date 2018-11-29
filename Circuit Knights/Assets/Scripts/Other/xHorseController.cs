// //Tony Le
// //14 Oct 2018

// using UnityEngine;
// using XboxCtrlrInput;
// using UnityEngine.SceneManagement;

// namespace CircuitKnights
// {

// 	public class HorseController : MonoBehaviour
// 	{
// 		////Attach to the horse

// 		[SerializeField] Objects.Knight player;
// 		[SerializeField] Objects.Horse horse;

// 		[Header("Gamepad Controls")]

// 		// [SerializeField] Objects.KnightObject player;
// 		[SerializeField]
// 		XboxController controller;
// 		[SerializeField] XboxAxis accelAxis = XboxAxis.RightTrigger;
// 		[Tooltip("FOR DEBUGGING PURPOSES")] [SerializeField] XboxButton decelButton = XboxButton.B;

// 		[Header("Lerp")]
// 		[SerializeField]
// 		float speed = 50;
// 		[Tooltip("smoothness factor; lower is smoother")] [SerializeField] float tValue = 0.025f;
// 		private Vector3 tarPos;

// 		public bool isControlsEnabled = true;

// 		//For reset
// 		Vector3 startPosition;

// 		void Start()
// 		{
// 			//Get the current position of the object
// 			tarPos = transform.position;

// 			//Save the initial starting position
// 			startPosition = transform.position;
// 		}

// 		void Update()
// 		{
// 			//if (isControlsEnabled)
// 			//{
// 			//}
// 			LerpMove();
// 		}


// 		void LerpMove()
// 		{
// 			var dt = Time.deltaTime;

// 			//Controller
// 			var accel = XCI.GetAxis(player.accelAxis, player.controller);
// 			// var accel = XCI.GetAxis(accelerate, controller);

// 			//Keyboard (debug)
// 			if (Input.GetKey(KeyCode.Space))
// 			{
// 				accel = speed * dt;
// 			}
// 			if (Input.GetKey(KeyCode.B) || XCI.GetButton(decelButton, controller))
// 			{
// 				accel = -speed * dt;
// 			}

// 			//Adjust the target position
// 			tarPos += transform.forward * speed * accel * dt;

// 			//Clamp lerp
// 			tValue = Mathf.Clamp01(tValue);

// 			//Lerp towards it
// 			transform.position = Vector3.Lerp(transform.position, tarPos, tValue);

// 			// Debug.Log("cur: "+transform.position + "tar: "+tarPos);
// 		}

// 		void OnResetPlayers()
// 		{
// 			//Reset to start position if reset triggers are hit		
// 			transform.position = tarPos = startPosition;
// 			// SceneManager.LoadScene("Tony");
// 		}
// 	}

// }