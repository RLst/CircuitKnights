//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Variables
{
    [CreateAssetMenu(fileName = "New Transform", menuName = "Variables/Transform", order = 33)]
    public class TransformVariable : ScriptableObject
    {
        [HideInInspector]
        public Transform Value;
    }

}