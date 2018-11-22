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
        [SerializeField] float LeftMotor = .5f;
       // [SerializeField] float RightMotor = .5f;
        public GameObject player;
        private float timer = 0.0f;
        private bool timing = false;
        public float vibratefor = 1.0f;
        // PlayerData playerData;
        //
        // private void Awake()
        // {
        //     playerData = GetComponentInParent<Player>().Data;
        // }
        //

        private void Update()
        {
            if (timing == true)
            {
                timer += Time.deltaTime;
                if(timer > vibratefor)
                {
                    // changes the values of the vibratio so it stops vibrating
                    LeftMotor = .0f;
                   // RightMotor = .0f;
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    Debug.Log("vibrating OFF");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                    timer = 0.0f;
                    timing = false;
                }
                
            }


        }
        private void OnCollisionStay(Collision collision)
        {
            
            //checks if the lance is hiting the player 
            if (collision.gameObject == player)
            {
                timing = true;
                //resets the vibration on enter
                LeftMotor = 1.0f;
                //RightMotor = 1.0f;
                //selects what controlers to vibrate
                VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                Debug.Log("vibrating ON");
                VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                //VibrateOnCollision((PlayerIndex)playerData.No as PlayerIndex);
            }
        }
      // private void OnCollisionExit(Collision collision)
      // {
      //
      //     if (collision.gameObject == player)
      //     {
      //         // changes the values of the vibratio so it stops vibrating
      //         LeftMotor = .0f;
      //         RightMotor = .0f;
      //         VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
      //         Debug.Log("vibrating OFF");
      //         VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
      //     }
      // }

        void VibrateOnCollision(XInputDotNetPure.PlayerIndex playerIndex)
        {
            if (isVibration.Value == true)
            {
                XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, 0);
            }
        }
    }
  }
