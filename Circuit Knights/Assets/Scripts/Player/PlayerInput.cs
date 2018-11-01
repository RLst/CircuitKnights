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
        [Multiline] [SerializeField] string description = "Handles controller/keyboard input for the player";
        [SerializeField] Knight player;
        [SerializeField] bool getKBInput = false;
        [SerializeField] float KBSpeed = 5f;

        #region Outputs
        // public XboxController Controller { get; private set; }
        public float LanceAxisX { get; private set; }
        public float LanceAxisY { get; private set; }
        public float LeanAxisX { get; private set; }
        public float LeanAxisY { get; private set; }
        public float ShieldAxis { get; private set; }
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
            ShieldAxis = XCI.GetAxis(player.ShieldAxis, player.Controller);
            ThrustLanceButton = XCI.GetButton(player.ThrustLanceButton, player.Controller);
        }

        void ReadKeyboardInput()
        {
            ///hardcoded for debugging/ease of use purposes
            // LeanAxisX += Input.GetKey(KeyCode.A) ? KBSpeed : 0f;
            // LeanAxisX -= Input.GetKey(KeyCode.D) ? KBSpeed : 0f;
            // LeanAxisY += Input.GetKey(KeyCode.W) ? KBSpeed : 0f;
            // LeanAxisY -= Input.GetKey(KeyCode.S) ? KBSpeed : 0f;
            LeanAxisX = Input.GetAxis("Horizontal2");
            LeanAxisY = Input.GetAxis("Vertical2");
            LanceAxisX = Input.GetAxis("Horizontal");
            LanceAxisY = Input.GetAxis("Vertical");

            //These might not work well with the controller
            ShieldAxis = Input.GetKey(KeyCode.RightShift) ? 1f : 0f;
            ThrustLanceButton = Input.GetKey(KeyCode.RightControl) ? true : false;
        }

    }
}