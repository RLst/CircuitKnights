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

        // VVV Thought it could avoid having to use SetTranformVariable.cs
        // [SerializeField] GameObject transformToSet;
        // void Awake()
        // {
        //     Value = transformToSet.transform;
        // }
    }

}