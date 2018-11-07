//Duckbike
//Tony Le
//30 Oct 2018

using UnityEngine;

namespace CircuitKnights.Variables
{
    [CreateAssetMenu(fileName = "New Game Object", menuName = "Variables/GameObject", order = 33)]
    public class GameObjectVariable : ScriptableObject
    {
        [HideInInspector]
        public GameObject Value;
    }

}