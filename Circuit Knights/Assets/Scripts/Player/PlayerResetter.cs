using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetter : MonoBehaviour {
	////Attach to the same object the horse controller is on

	[SerializeField] string resetTriggerTagName = "Reset";

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Reset") {
			// Debug.Log("Reset Triggers hit");
			SendMessage("onResetPlayers");
		}
	} 
}
