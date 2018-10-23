using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour {
    [SerializeField] Animator textAnimator;
	
	// Update is called once per frame
	public void onClick () {
        textAnimator.SetTrigger("startcreditroll");
		
	}
}
