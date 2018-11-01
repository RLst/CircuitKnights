//DuckBike
//Tony Le
//30 Oct 2018

using UnityEngine;

namespace CircuitKnights.Variables
{
    public class SetTransformVariable : MonoBehaviour
    {
        public TransformVariable transformVariable;
        void Awake()
        {
            if (transformVariable)
                transformVariable.Value = this.transform;
            else
                Debug.LogWarning("Transform variable not set!");
        }
    }

}