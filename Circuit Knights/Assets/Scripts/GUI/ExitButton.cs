﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	public void ExitGame()
    {
        // UnityEditor.EditorApplication.isPlaying = false; //This was preventing unity from building it
        Application.Quit();
    }
}
