using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircuitKnights.Variables;
using CircuitKnights;
using CircuitKnights.Objects;
using XInputDotNetPure;

//Brent D'Auria

public class LanceOnImpact : MonoBehaviour {

    [SerializeField] BoolVariable isVibration;
    [SerializeField] float LeftMotor = .5f;
    [SerializeField] float RightMotor = .5f;
    public GameObject player;
    // PlayerData playerData;
    //
    // private void Awake()
    // {
    //     playerData = GetComponentInParent<Player>().Data;
    // }
    //

    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //checks if the lance is hiting the player 
       if (collision.gameObject == player)
        {
            //resets the vibration on enter
                LeftMotor = .5f;
                RightMotor = .5f;
            //selects what controlers to vibrate
                VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                Debug.Log("vibrating");
                VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
            //VibrateOnCollision((PlayerIndex)playerData.No as PlayerIndex);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            // changes the values of the vibratio so it stops vibrating
            LeftMotor = .0f;
            RightMotor = .0f;
            VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
            Debug.Log("vibrating");
            VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
        }
    }

    void VibrateOnCollision(XInputDotNetPure.PlayerIndex playerIndex)
    {
        if (isVibration.Value == true)
        {
            XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
        }
    }
}
