//DuckBike
//Tony Le
//31 Oct 2018

using UnityEngine;
using CircuitKnights.Objects;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public class PlayerMover : MonoBehaviour
    {
		[TextArea] [SerializeField] string description = "Handles horse movement ONLY";
		[SerializeField] Player player;
		[SerializeField] Horse horse;
		private PlayerInput playerInput;
		Vector3 startPosition;
		Vector3 tarPos;

		void Awake()
		{
			//Used to poll the controller axes
			playerInput = GetComponent<PlayerInput>();

			//Remember the initial starting position
			startPosition = transform.position;
			tarPos = transform.position;
		}

		void Start()
		{
			Assert.IsNotNull(playerInput, "Input not found!");
		}

		void FixedUpdate()
		{
			MoveByLerp();
		}

		void MoveByLerp()
		{
			//Adjust the target position
			tarPos += transform.forward * horse.speed * playerInput.AccelAxis * Time.deltaTime;

			//Clamp lerp
			// horse.ClampTValue();

			//Lerp towards it
			transform.position = Vector3.Lerp(transform.position, tarPos, horse.lerpSmoothness);
		}

		public void SetDesiredPosition(Vector3 desiredPos)
		{
			//Used after a pass has occurred
			tarPos = desiredPos;
		}

		public void SetPosition(Vector3 position)
		{
			//Used to instantly position the object ie. To reset the positions etc
			transform.position = position;
			tarPos = position;
		}


    }

}
