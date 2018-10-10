using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreen : MonoBehaviour {

    public GameObject VictoryScreen;
    public GameObject DefeatScreen;

	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DefeatScreen.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            VictoryScreen.SetActive(true);
        }
        
	}
}
