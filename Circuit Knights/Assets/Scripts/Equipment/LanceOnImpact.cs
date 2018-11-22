using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircuitKnights.Variables;
using CircuitKnights;
using CircuitKnights.Objects;
using XInputDotNetPure;

//Brent D'Auria
namespace CircuitKnights { 
    public class LanceOnImpact : MonoBehaviour {

        [SerializeField] BoolVariable isVibration;
        private float LeftMotor;
        private float RightMotor;
        public GameObject player;
        private float timer = 0.0f;
        private bool timing = false;
        public float VibrateOnCollisionFor = .5f;
        public bool VibrateMovementOn;
        public bool VibrateCollisionOn;

        
       

        private void Update()
        {
            collisionVibrationOff();
          VibrationOnMovment();


        }
        //vibrates on collision
        private void OnCollisionStay(Collision collision)
        {
            if (VibrateCollisionOn == true)
            {
                //checks if the lance is hiting the player 
                if (collision.gameObject == player)
                {
                    timing = true;
                    //resets the vibration on enter
                    LeftMotor = 1.0f;
                    RightMotor = 1.0f;
                    //selects what controlers to vibrate
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    Debug.Log("vibrating Collision ON");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                    //VibrateOnCollision((PlayerIndex)playerData.No as PlayerIndex);
                    
                }
            }
        }

        private void collisionVibrationOff()
        {
            //checks if there was a collision
            if (timing == true)
            {
                timer += Time.deltaTime; //creates a timer that starts counting on the colision
                if (timer > VibrateOnCollisionFor)//turns off the vibration when the timer is greater than the amount you set the VibrateOnCollisionfor
                {
                    // changes the values of the vibratio so it stops vibrating
                    LeftMotor = .0f;
                    RightMotor = .0f;
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    Debug.Log("Vibrating Collision OFF");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                    timer = 0.0f;
                    timing = false;
                }

            }
        }
      
        // this currently vibrates all the time as tony is creating a way to get the players velocit than the vibration will change depending on there velocity
       private void VibrationOnMovment()
       {
            if (VibrateMovementOn == true)
            {
                if (timing == false)
                {
                    LeftMotor = .1f;
                    RightMotor = .1f;
                    Debug.Log("Vibrating on Movement");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                    
                    
                }
            }

            if(VibrateMovementOn == false)
            {
                if (timing == false)
                {
                    LeftMotor = .0f;
                    RightMotor = .0f;
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                }
            }
               
           
       }

        //this is to check if the vibrating setting is ticked for any of the code to work
        void VibrateOnCollision(XInputDotNetPure.PlayerIndex playerIndex)
        {
            if (isVibration.Value == true)
            {

                XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
            }
            else
            {
                LeftMotor = 0.0f;
                RightMotor = 0.0f;
                XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
            }
        }
    }
  }
