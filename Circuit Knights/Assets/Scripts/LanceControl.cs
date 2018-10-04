//Tony Le
//3 Oct 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights {

public class LanceControl : MonoBehaviour {

	public float lanceHorizontalSpeed = 5;
	public float lanceVerticalSpeed = 5;

	// Update is called once per frame
	void FixedUpdate () {
		var rb = GetComponent<Rigidbody>();

		//Vertical
		var vertical = Input.GetAxis("Vertical");
		transform.Rotate(0, 0, vertical);
		
		//Horizontal
		var horizontal = Input.GetAxis("Horizontal");
		transform.Rotate(-horizontal, 0, 0);

	}
}

}