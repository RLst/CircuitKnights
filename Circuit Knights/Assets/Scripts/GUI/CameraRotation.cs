using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{
    public class CameraRotation : MonoBehaviour
    {
        public GameObject Camera;
        public Transform target;
        public Vector3 pivot;
        public float speed = 30.0f;
        void Update()
        {
            transform.LookAt(target);
            transform.RotateAround(pivot, Vector3.up, speed * Time.deltaTime);
        }
    }
}