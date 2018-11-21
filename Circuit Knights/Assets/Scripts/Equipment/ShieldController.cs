//DuckBike
//Tony le
//1 Nov 2018

using XboxCtrlrInput;
using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
	public class ShieldController : MonoBehaviour
	{
		PlayerInput playerInput;
		ShieldData shieldData;
		[SerializeField][Range(0f,1f)] float deadZone = 0.1f;

		void Awake()
		{
			shieldData = GetComponentInParent<Player>().ShieldData;
			playerInput = GetComponentInParent<PlayerInput>();
		}

		void Start()
		{
			Assert.IsNotNull(playerInput, "No player input found! Attach PlayerInput to root.");
			Assert.IsNotNull(shieldData, "No shield has been selected! Attach a Shield scriptable.");
		}

		void Update()
		{
			// Debug.Log("X: "+playerInput.ShieldAxisX);
			// Debug.Log("Y: "+playerInput.ShieldAxisY);
			if (playerInput.ShieldAxisX < deadZone &&
				playerInput.ShieldAxisX > -deadZone &&
				playerInput.ShieldAxisY < deadZone &&
				playerInput.ShieldAxisY > -deadZone)
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
            var centre = shieldData.CentreOffset;
            var offset = Vector3.zero;
			var angleOffset = Vector3.zero;

			///Calculate position offset (Don't worry about the angle for now)
			//X offset (horizontal movement)
			if (playerInput.ShieldAxisX < Mathf.Abs(deadZone))	//Left
			{
				offset.x = shieldData.BlockOffset.x * shieldData.BlockLeftWeight * playerInput.ShieldAxisX;
            }
			else if (playerInput.ShieldAxisX > Mathf.Abs(deadZone)) //Right
            {
                offset.x = shieldData.BlockOffset.x * shieldData.BlockRightWeight * playerInput.ShieldAxisX;
            }   //else offset.x = 0;

            //Y offset (vertical movement)
            if (playerInput.ShieldAxisY > Mathf.Abs(deadZone))  //Up
            {
                offset.y = shieldData.BlockOffset.y * shieldData.BlockUpWeight * playerInput.ShieldAxisY;
            }
            else if (playerInput.ShieldAxisY < Mathf.Abs(deadZone)) //Down
            {
                offset.y = shieldData.BlockOffset.y * shieldData.BlockDownWeight * playerInput.ShieldAxisY;
            }   //else offset.y = 0;

            // offset.x = shield.BlockXOffset.x * playerInput.ShieldAxisX;
            // offset.y = shield.BlockXOffset.y * playerInput.ShieldAxisY;

            // angleOffset.x = shield.BlockAngOffset.x * playerInput.ShieldAxisY;
			// angleOffset.y = shield.BlockAngOffset.y * playerInput.ShieldAxisY;

			transform.localPosition = Vector3.Lerp(transform.localPosition, offset, shieldData.tValue);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(angleOffset), shieldData.tValue);
		}

		private void RestShield()
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, shieldData.CentreOffset, shieldData.tValue);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(shieldData.CentreAngFactor), shieldData.tValue);
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