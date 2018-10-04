using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour {
   
    public float player_lean_speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        //sets A to lean left
        if (Input.GetKey(KeyCode.A))
        {
    
            Debug.Log("leeen");
            //sets what axis rotate
            transform.Rotate(0, 0, player_lean_speed);
        }
        //sets D to lean right
        if (Input.GetKey(KeyCode.D))
        {

            Debug.Log("leeen");
            //sets what axis rotate
            transform.Rotate(0, 0, -player_lean_speed);
        }
    }
}
