﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CircuitKnights; 
public class xResetTrigger : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Main");
        MainMenuButton.Rematch = true;
    }
}