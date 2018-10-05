using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{

public class lance_Ray_cast : MonoBehaviour {

    RaycastHit hit;
    public float Distance = 10;

    void Update()
    {

        Vector3 Vector3 = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        if (Physics.Raycast(transform.position, (Vector3.forward)))
        {
            Distance = hit.distance;
            print(Distance + " " + hit.collider.gameObject.name);
        }
    }
}

}