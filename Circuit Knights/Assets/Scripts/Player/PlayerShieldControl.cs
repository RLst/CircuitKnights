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
	public class PlayerShieldControl : MonoBehaviour
	{
		PlayerInput playerInput;

		[SerializeField] Shield shield;
		public float xDeadzone = 0.1f;

		void Awake()
		{
			playerInput = GetComponentInParent<PlayerInput>();
		}

		void Start()
		{
			Assert.IsNotNull(playerInput, "No player input found! Attach PlayerInput to root.");
			Assert.IsNotNull(shield, "No shield has been selected! Attach a Shield scriptable.");
		}

		void Update()
		{
			// Debug.Log("X: "+playerInput.ShieldAxisX);
			// Debug.Log("Y: "+playerInput.ShieldAxisY);
			if (playerInput.ShieldAxisX < xDeadzone &&
				playerInput.ShieldAxisX > -xDeadzone &&
				playerInput.ShieldAxisY < xDeadzone &&
				playerInput.ShieldAxisY > -xDeadzone)
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
			var offset = Vector3.zero;
			var angleOffset = Vector3.zero;

			offset.x = shield.BlockingOffset.x * playerInput.ShieldAxisX;
			offset.z = shield.BlockingOffset.y * playerInput.ShieldAxisY;
			angleOffset.x = shield.BlockingAngOffset.x * playerInput.ShieldAxisY;
			angleOffset.y = shield.BlockingAngOffset.y * playerInput.ShieldAxisY;

			transform.localPosition = Vector3.Lerp(transform.localPosition, offset, shield.tValue);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(angleOffset), shield.tValue);
		}

		private void RestShield()
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, shield.RestingOffset, shield.tValue);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(shield.RestingAngOffset), shield.tValue);
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