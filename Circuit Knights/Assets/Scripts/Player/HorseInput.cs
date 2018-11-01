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
        [SerializeField] Knight player;  //Required to select which controller
        [SerializeField] Horse horse;
        [SerializeField] bool getKBInput = true;

        #region Outputs
        public float Accel { get; private set; }
        // public float Decel { get; private set; }
        #endregion

        private void Update()
        {
            ReadControllerInput();
            if (getKBInput) ReadKeyboardInput();
        }

        private void ReadControllerInput()
        {
            Accel = XCI.GetAxis(horse.Accel, player.Controller);
            // Decel = XCI.GetAxis(horse.decelAxis, player.controller) * horse.speed * Time.deltaTime;
            if (XCI.GetButton(horse.Decel, player.Controller))
            {
                Accel = -horse.speed;
            }
        }

        private void ReadKeyboardInput()
        {
            //Hardcoded
            if (Input.GetKey(KeyCode.Space))
                Accel = horse.speed;
            if (Input.GetKey(KeyCode.B))
                Accel = -horse.speed;
        }
    }
}



















