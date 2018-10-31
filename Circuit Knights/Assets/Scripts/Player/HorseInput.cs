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

        [Multiline] [SerializeField] string description = "Handles input for the horse";
        Knight player;  //Required to select which controller
        [SerializeField] Horse horse;


        public float Accel { get; private set; }
        public float Decel { get; private set; }

        private void Update()
        {
            GetControllerInput();
            // if (Debug.isDebugBuild)
            // GetKeyboardInput();
        }

        private void GetControllerInput()
        {
            Accel = XCI.GetAxis(horse.accelAxis, player.controller) * horse.speed * Time.deltaTime;
            // Decel = XCI.GetAxis(horse.decelAxis, player.controller) * horse.speed * Time.deltaTime;
            if (XCI.GetButton(horse.decelButton, player.controller))
            {
                Decel = -horse.speed * Time.deltaTime;
            }
        }

        private void GetKeyboardInput()
        {
            if (Input.GetKey(KeyCode.Space))
                Accel = horse.speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.B))
                Decel = -horse.speed * Time.deltaTime;
        }
    }
}



















