//DuckBike
//Tony le
//1 Nov 2018

using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Gear;

namespace CircuitKnights.Controllers
{
    public class ShieldController : MonoBehaviour
	{
		PlayerInput playerInput;
		Shield shield;
		[SerializeField][Range(0f, 1f)] float deadzone = 0.1f;

		void Awake()
		{
			shield = GetComponentInParent<Shield>();
			playerInput = GetComponentInParent<PlayerInput>();
		}

		void Start()
		{
			Assert.IsNotNull(playerInput, "No player input found! Attach a PlayerInput to root.");
			Assert.IsNotNull(shield, "No shield has been found!");
		}

		void Update()
		{
			// Debug.Log("X: "+playerInput.ShieldAxisX);
			// Debug.Log("Y: "+playerInput.ShieldAxisY);
			if (playerInput.ShieldAxisX < deadzone &&
				playerInput.ShieldAxisX > -deadzone &&
				playerInput.ShieldAxisY < deadzone &&
				playerInput.ShieldAxisY > -deadzone)
			{
				// Debug.Log("Shield resting");
				RestShield();
			}
			else
			{
				MoveShield();
			}
		}

		private void MoveShield()
		{
			var centre = shield.CentreOffset;
			var offset = Vector3.zero;
			var angleOffset = Vector3.zero;

			///Calculate position offset (Don't worry about the angle for now)
			//X offset (horizontal movement)
			if (playerInput.ShieldAxisX < Mathf.Abs(deadzone))	//left movement
			{
				offset.x = shield.BlockOffset.x * shield.BlockLeftWeight * playerInput.ShieldAxisX;
			}
			else if (playerInput.ShieldAxisX > Mathf.Abs(deadzone))	//Right movement
			{
				offset.x = shield.BlockOffset.x * shield.BlockRightWeight * playerInput.ShieldAxisX;
			}

			//Y offset (vertical movement)
			if (playerInput.ShieldAxisY > Mathf.Abs(deadzone))	//Up movement
			{
				offset.y = shield.BlockOffset.y * shield.BlockUpWeight * playerInput.ShieldAxisY;
			}
			else if (playerInput.ShieldAxisY < Mathf.Abs(deadzone))	//Down movement
			{
				offset.y = shield.BlockOffset.y * shield.BlockDownWeight * playerInput.ShieldAxisY;
			}

			transform.localPosition = Vector3.Lerp(transform.localPosition, offset, shield.tValue);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(angleOffset), shield.tValue);

			// offset.x = shieldData.BlockingOffset.x * playerInput.ShieldAxisX;
			// offset.z = shieldData.BlockingOffset.y * playerInput.ShieldAxisY;
			// angleOffset.x = shieldData.BlockingAngOffset.x * playerInput.ShieldAxisY;
			// angleOffset.y = shieldData.BlockingAngOffset.y * playerInput.ShieldAxisY;
		}

		private void RestShield()
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, shield.CentreOffset, shield.tValue);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(shield.CentreAngFactor), shield.tValue);
		}
	}
}




// var desOffset = Vector3.zero;
// var desAngOffset = Quaternion.identity;

// //offset = maxBlockOffset;
// desOffset = shield.BlockingOffset * playerInput.ShieldAxis;
// desAngOffset = Quaternion.Euler(shield.BlockingAngOffset * playerInput.ShieldAxis);

// transform.localPosition = Vector3.Lerp(transform.localPosition, desOffset, shield.tValue);
// transform.localRotation = Quaternion.Lerp(transform.localRotation, desAngOffset, shield.tValue);