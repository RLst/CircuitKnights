//Duckbike
//Tony Le
//1 Nov 2018

using XboxCtrlrInput;
using CircuitKnights.Objects;
using UnityEngine;

namespace CircuitKnights
{
    public class PlayerInput : MonoBehaviour
    {
        [TextArea] [SerializeField] string description = "Handles controller/keyboard input for the player. Attach to the root object";
        [SerializeField] Knight player;
        [SerializeField] bool getKBInput = false;
		[SerializeField] KeyCode shieldKey = KeyCode.LeftShift;
		[SerializeField] KeyCode thrustKey = KeyCode.RightControl;

		#region Outputs
		// public XboxController Controller { get; private set; }
		public float LanceAxisX { get; private set; }
        public float LanceAxisY { get; private set; }
        public float LeanAxisX { get; private set; }
        public float LeanAxisY { get; private set; }
        public float ShieldAxisX { get; private set; }
        public float ShieldAxisY { get; private set; }
        public bool ThrustLanceButton { get; private set; }
        #endregion

        void Update()
        {
            ReadControllerInput();
            if (getKBInput) ReadKeyboardInput();
        }

        void ReadControllerInput()
        {
            // Controller = player.Controller;
            LanceAxisX = XCI.GetAxis(player.LanceAxisX, player.Controller);
            LanceAxisY = XCI.GetAxis(player.LanceAxisY, player.Controller);
            LeanAxisX = XCI.GetAxis(player.LeanAxisX, player.Controller);
            LeanAxisY = XCI.GetAxis(player.LeanAxisY, player.Controller);
            ShieldAxisX = XCI.GetAxis(player.ShieldAxisX, player.Controller);
            ShieldAxisY = XCI.GetAxis(player.ShieldAxisY, player.Controller);
            ThrustLanceButton = XCI.GetButton(player.ThrustLanceButton, player.Controller);
        }

        void ReadKeyboardInput()
		{
			///hardcoded for debugging/ease of use purposes
			LeanAxisX = Input.GetAxis("Horizontal2");
			LeanAxisY = Input.GetAxis("Vertical2");
			LanceAxisX = Input.GetAxis("Horizontal");
			LanceAxisY = Input.GetAxis("Vertical");

			ReadShieldInput();
			ReadThrustInput();
		}

		private void ReadThrustInput()
		{
            ThrustLanceButton = Input.GetKey(thrustKey);
		}

		private void ReadShieldInput()
		{
            ShieldAxisX = System.Convert.ToSingle(Input.GetKey(shieldKey));  //Might not work well with the controller

            // if (Input.GetKey(shieldKey))
            //     ShieldAxis = 1f;
            // else
            //     ShieldAxis = 0f;
			// ShieldAxis = Input.GetKey(KeyCode.LeftShift) ? 1f : 0f;
		}
	}
}