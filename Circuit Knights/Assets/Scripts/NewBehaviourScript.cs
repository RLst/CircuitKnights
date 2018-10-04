using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    
    public float player_speed;


	
	
	// Update is called once per frame
	void Update () {

        //sets foward movment to w
        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(player_speed, 0, 0);
        }
        //sets backward movment to s
        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(-player_speed, 0, 0);
        }


    }
}
