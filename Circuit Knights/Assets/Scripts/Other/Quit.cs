﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

}