//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CircuitKnights;


//[RequireComponent (typeof(HeadHealth))]
//public class HeadPopOff : MonoBehaviour {

//    // Put this on the object with the head's collider and Head Health Script

//    string myTag;

//    private void Start()
//    {
//        //myTag = GetComponent<HeadHealth>().dataObject.tag;
//    }


//    public void OnCollisionEnter (Collision col)
//    {
//        // If this object collided with the lance...
//        if (col.gameObject.name.Contains("Lance") && myTag != col.transform.tag)
//        {
//            // Pop Head off
//            this.GetComponent<HeadHealth>().Death();
//        }
//    }
//}
