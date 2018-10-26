using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brent D'Auria
//5-10-28

public class Movment : MonoBehaviour {
    public float PlayerSpeed = .2f;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, PlayerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -PlayerSpeed);
        }

    }
}
