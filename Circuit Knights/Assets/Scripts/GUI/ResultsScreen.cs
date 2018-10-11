using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreen : MonoBehaviour {

    public GameObject ResultScreen;

	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ResultScreen.SetActive(true);
        }
	}
}
