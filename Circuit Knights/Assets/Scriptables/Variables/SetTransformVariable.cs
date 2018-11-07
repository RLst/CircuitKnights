//DuckBike
//Tony Le
//30 Oct 2018

using UnityEngine;

namespace CircuitKnights.Variables
{
    public class SetTransformVariable : MonoBehaviour
    {
        public TransformVariable variable;
        void Awake()
        {
            if (variable)
                variable.Value = this.transform;
            else
                Debug.LogError("Transform variable not set!");
        }
    }

}