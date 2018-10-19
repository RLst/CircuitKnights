using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{
    public class HorseReset : MonoBehaviour
    {
        [SerializeField] Transform horseStartPosition;

        private GameObject[] resetTrigger;

        private void Start()
        {
            resetTrigger = GameObject.FindGameObjectsWithTag("Reset");
        }

        private void OnTriggerEnter()
        {
            //Do things


        }

    }
}
