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
        [SerializeField] Player player;
        [SerializeField] Horse horse;
        [SerializeField] bool getKBInput = false;
		[SerializeField] KeyCode thrustKey = KeyCode.RightControl;

		#region Outputs
		// public XboxController Controller { get; private set; }
		public float LanceAxisX { get; private set; }
        public float LanceAxisY { get; private set; }
        public float LeanAxisX { get; private set; }
        public float LeanAxisY { get; private set; }

        public float ShieldAxisX { get; private set; }
        public float ShieldAxisY { get; private set; }

        public float AccelAxis { get; private set; }
        public bool DecelButton { get; private set; }

        public bool ThrustLanceButton { get; private set; }
        #endregion

        void Update()
        {
            ReadControllerInput();
            if (getKBInput) xReadKeyboardInput();
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

            AccelAxis = XCI.GetAxis(horse.AccelAxis, player.Controller);
            DecelButton = XCI.GetButton(horse.DecelButton, player.Controller);

            ThrustLanceButton = XCI.GetButton(player.ThrustLanceButton, player.Controller);
        }

        void xReadKeyboardInput()
		{
			///hardcoded for debugging/ease of use purposes
			LeanAxisX = Input.GetAxis("Horizontal2");
			LeanAxisY = Input.GetAxis("Vertical2");
			LanceAxisX = Input.GetAxis("Horizontal");
			LanceAxisY = Input.GetAxis("Vertical");
            ShieldAxisX = Input.GetAxis("Horizontal2");
			ShieldAxisY = Input.GetAxis("Vertical2");
            
            //Temp
            if (Input.GetKey(KeyCode.Space))
                AccelAxis = 1f;
            if (Input.GetKey(KeyCode.B))
                AccelAxis = -1f;
            if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.B))
                AccelAxis = 0;

			ReadThrustInput();
		}

		private void ReadThrustInput()
		{
            ThrustLanceButton = Input.GetKey(thrustKey);
		}
	}
}