using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircuitKnights.Variables;
//Brent D'Auria

public class LanceOnImpact : MonoBehaviour {

    [SerializeField] BoolVariable isVibration;
    [SerializeField] float LeftMotor = .5f;
    [SerializeField] float RightMotor = .5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
            Debug.Log("vibrating");
        }
        if (collision.gameObject.tag == "Player2")
        {
            VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
            Debug.Log("vibrating");
        }

    }

    void VibrateOnCollision(XInputDotNetPure.PlayerIndex playerIndex)
    {
        if (isVibration)
        {
            XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
        }
    }
}
