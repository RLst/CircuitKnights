//Duckbike
//Tony Le
//1 Nov 2018

using XboxCtrlrInput;
using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Players;
using CircuitKnights.Gear;

namespace CircuitKnights
{
    [RequireComponent(typeof(Player))]
    public class PlayerInput : MonoBehaviour
    {
        // [TextArea] [SerializeField] string description = "Handles controller/keyboard input for the player. Attach to the root object";
        Player player;
        [SerializeField] bool getKBInput = false;

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
            player = GetComponentInChildren<Player>();
            Assert.IsNotNull(player, "Player data not found!");
        }

        void Update()
        {
            ReadControllerInput();
            if (getKBInput) xReadKeyboardInput();
        }

        void ReadControllerInput()
        {
            LanceAxisX = XCI.GetAxisRaw(player.LanceAxisX, player.Controller);
            LanceAxisY = XCI.GetAxisRaw(player.LanceAxisY, player.Controller);

            LeanLeft = XCI.GetAxisRaw(player.LeanLeft, player.Controller);
            LeanRight = XCI.GetAxisRaw(player.LeanRight, player.Controller);

            ShieldAxisX = XCI.GetAxisRaw(player.ShieldAxisX, player.Controller);
            ShieldAxisY = XCI.GetAxisRaw(player.ShieldAxisY, player.Controller);

            // ThrustLanceButton = XCI.GetButton(playerData.ThrustLanceButton, playerData.Controller);
        }

        void xReadKeyboardInput()
		{
			///hardcoded for debugging/ease of use purposes
            if (Input.GetKey(KeyCode.Q))
			    LeanLeft = 1;
            else
                LeanLeft = 0;

            if (Input.GetKey(KeyCode.E))
                LeanRight = 1;
            else
                LeanRight = 0;

			LanceAxisX = Input.GetAxis("Horizontal");
			LanceAxisY = Input.GetAxis("Vertical");

            ShieldAxisX = Input.GetAxis("Horizontal2");
			ShieldAxisY = Input.GetAxis("Vertical2");
		}
	}
}