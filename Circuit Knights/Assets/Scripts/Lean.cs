using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour {

    public float player_lean_speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //var y = Input.GetAxis("Horizontal") * Time.deltaTime * player_lean_speed;


            Debug.Log("leeen");
            transform.Rotate(0, 0, player_lean_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //var y = Input.GetAxis("Horizontal") * Time.deltaTime * player_lean_speed;


            Debug.Log("leeen");
            transform.Rotate(0, 0, -player_lean_speed);
        }
    }
}
