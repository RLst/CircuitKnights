using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Dawes
//11th of October, 2018

namespace CircuitKnights
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] GameObject Camera;
        [SerializeField] Transform target;
        [SerializeField] Vector3 pivot;
        [SerializeField] float speed = 30.0f;
        void Update()
        {
            transform.LookAt(target);
            transform.RotateAround(pivot, Vector3.up, speed * Time.deltaTime);
        }
    }
}