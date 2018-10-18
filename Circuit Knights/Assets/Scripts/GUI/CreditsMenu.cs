using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour {
    public Animator textAnimator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void onClick () {
        textAnimator.SetTrigger("startcreditroll");
		
	}
}
