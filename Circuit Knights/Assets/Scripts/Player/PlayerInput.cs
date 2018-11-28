//Duckbike
//Tony Le
//1 Nov 2018

using XboxCtrlrInput;
using CircuitKnights.Objects;
using UnityEngine;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    [RequireComponent(typeof(Player))]
    public class PlayerInput : MonoBehaviour
    {
        [TextArea] [SerializeField] string description = "Handles controller/keyboard input for the player. Attach to the root object";
        PlayerData playerData;
        HorseData horseData;
        [SerializeField] bool getKBInput = false;
		[SerializeField] KeyCode thrustKey = KeyCode.RightControl;

		#region Outputs
		public float LanceAxisX { get; private set; }
        public float LanceAxisY { get; private set; }

        public float LeanLeft { get; private set; }
        public float LeanRight { get; private set; }

        public float ShieldAxisX { get; private set; }
        public float ShieldAxisY { get; private set; }

        // public float AccelAxis { get; private set; }
        // public bool DecelButton { get; private set; }

        // public bool ThrustLanceButton { get; private set; }
        #endregion


        public void Start()
        {
            //// HOPEFULLY GetComponentInChildren also finds component in the same object too
            playerData = GetComponentInChildren<Player>().Data;
            horseData = GetComponentInChildren<Player>().HorseData;

            Assert.IsNotNull(playerData, "Player data not found!");
            Assert.IsNotNull(horseData, "Horse data not found!");
        }

        void Update()
        {
            ReadControllerInput();
            if (getKBInput) xReadKeyboardInput();
        }

        void ReadControllerInput()
        {
            // Controller = player.Controller;
            LanceAxisX = XCI.GetAxisRaw(playerData.LanceAxisX, playerData.Controller);
            LanceAxisY = XCI.GetAxisRaw(playerData.LanceAxisY, playerData.Controller);
            LeanLeft = XCI.GetAxisRaw(playerData.LeanLeft, playerData.Controller);
            LeanRight = XCI.GetAxisRaw(playerData.LeanRight, playerData.Controller);

            ShieldAxisX = XCI.GetAxisRaw(playerData.ShieldAxisX, playerData.Controller);
            ShieldAxisY = XCI.GetAxisRaw(playerData.ShieldAxisY, playerData.Controller);

            // AccelAxis = XCI.GetAxis(horseData.AccelAxis, playerData.Controller);
            // DecelButton = XCI.GetButton(horseData.DecelButton, playerData.Controller);

            // ThrustLanceButton = XCI.GetButton(playerData.ThrustLanceButton, playerData.Controller);
        }

        void xReadKeyboardInput()
		{
			///hardcoded for debugging/ease of use purposes
			LeanLeft = Input.GetAxis("Horizontal2");
			LeanRight = Input.GetAxis("Vertical2");
			LanceAxisX = Input.GetAxis("Horizontal");
			LanceAxisY = Input.GetAxis("Vertical");
            ShieldAxisX = Input.GetAxis("Horizontal2");
			ShieldAxisY = Input.GetAxis("Vertical2");

            //Temp
            // if (Input.GetKey(KeyCode.Space))
            //     AccelAxis = 1f;
            // if (Input.GetKey(KeyCode.B))
            //     AccelAxis = -1f;
            // if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.B))
            //     AccelAxis = 0;

            // ThrustLanceButton = Input.GetKey(thrustKey);
		}
	}
}