//DuckBike
//Tony Le
//31 Oct 2018

using UnityEngine;
using CircuitKnights.Objects;

namespace CircuitKnights
{

    public class HorseMover : MonoBehaviour
    {
		[SerializeField] Knight player; 		//Need this?
		[SerializeField] Horse horse;
		private HorseInput horseInput;
		Vector3 startPosition;
		Vector3 tarPos;


		void Start()
		{
			//Used to poll the controller axes
			horseInput = GetComponent<HorseInput>();

			//Remember the initial starting position
			startPosition = transform.position;
			tarPos = transform.position;	
		}

		void Update()
		{
			MoveByLerp();
		}

		void MoveByLerp()
		{
			var dt = Time.deltaTime;

			var accel = horseInput.Accel;
			var decel = horseInput.Decel;

			//Adjust the target position
			tarPos += transform.forward * horse.speed * accel * dt;

			//Clamp lerp
			horse.ClampTValue();

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
