using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseDisabler : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		Cursor.lockState = CursorLockMode.Locked;
 		Cursor.visible = false;
	}
	
}
