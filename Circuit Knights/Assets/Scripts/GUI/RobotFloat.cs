using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Dawes
//26th of October, 2018

namespace CircuitKnights
{
    public class RobotFloat : MonoBehaviour
    {
        [SerializeField] float FloatStrength = 1;
        float OriginalY;
        void Start()
        {
            this.OriginalY = this.transform.position.y;
        }

        void Update()
        {
            transform.position = new Vector3(transform.position.x,
            OriginalY + ((float)Mathf.Sin(Time.time) * FloatStrength),
            transform.position.z);
        }
    }
}
