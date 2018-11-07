//DuckBike
//Tony Le
//30 Oct 2018

using UnityEngine;

namespace CircuitKnights.Variables
{

    public class SetGameObjectVariable : MonoBehaviour
    {
        //Sets a game object variable to this object
        // [SerializeField] GameObjectVariable gameObjectVariable;
        public GameObjectVariable gameObjectVariable;

        void Awake()
        {
            if (gameObjectVariable)
                gameObjectVariable.Value = this.gameObject;
            else
                Debug.LogWarning("Game Object Variable not set!");
        }
    }

}