//Duckbike
//Tony Le
//31 Oct 2018

using CircuitKnights.Objects;
using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights
{

    public class HorseInput : MonoBehaviour
    {
        [Multiline] [SerializeField] string description = "Handles controller/keyboard input for the horse";
        [SerializeField] Player player;  //Required to select which controller
        [SerializeField] Horse horse;

        [Header("Keyboard Controls")]
        [SerializeField] bool isUsingKB = true;
        [SerializeField] KeyCode accelKey = KeyCode.Space;
        [SerializeField] KeyCode decelKey = KeyCode.B;

        #region Outputs
        public float Accel { get; private set; }
        // public float Decel { get; private set; }
        #endregion

        private void Update()
        {
            ReadControllerInput();
            if (isUsingKB) ReadKeyboardInput();
        }

        private void ReadControllerInput()
        {
            Accel = XCI.GetAxis(horse.AccelAxis, player.Controller);
            // Decel = XCI.GetAxis(horse.decelAxis, player.controller) * horse.speed * Time.deltaTime;

            //Temp
            Accel = -System.Convert.ToSingle(XCI.GetButton(horse.DecelButton, player.Controller));
        }

        private void ReadKeyboardInput()
        {
            //If accel is already set


            if (Input.GetKey(accelKey))
                Accel = 1f;

            if (Input.GetKey(decelKey))
                Accel = -1f;

            if (!Input.GetKey(accelKey) && !Input.GetKey(decelKey))
                Accel = 0f;

            // Accel = Input.GetKey(accelKey) ? 1f : Accel;
            // Accel = Input.GetKey(decelKey) ? -1f : Accel;
        }
    }
}



















