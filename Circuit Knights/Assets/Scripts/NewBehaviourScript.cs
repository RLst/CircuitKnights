using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    
    public float player_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        var x = Input.GetAxis("Vertical") * Time.deltaTime * player_speed;

      
        transform.Translate(x, 0, 0);
     

    }
}
