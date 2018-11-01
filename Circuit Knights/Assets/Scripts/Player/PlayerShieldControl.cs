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

		public float xLerp = 0.25f;		//x prefix means temporary/debug/etc

		void Awake()
		{
			playerInput = GetComponent<PlayerInput>();
		}

		void Start()
		{
			Assert.IsNotNull(playerInput, "is null");
			Assert.IsNotNull(shield, "No shield has been selected!");
		}

		void Update()
		{
			HandleShield();
		}

        void HandleShield()
        {
            var desOffset = Vector3.zero;
			var desAngOffset =
			// var currentOffset = transform.localPosition;

            //offset = maxBlockOffset;
            desOffset = shield.BlockingOffset * playerInput.ShieldAxis;
			transform.localPosition = Vector3.Lerp(transform.localPosition, desOffset, xLerp);
        }
	}

}