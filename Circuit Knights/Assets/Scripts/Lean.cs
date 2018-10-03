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
        var y = Input.GetAxis("Horizontal") * Time.deltaTime * player_lean_speed;


        transform.Rotate(-y, 0, 0);


    }
}
