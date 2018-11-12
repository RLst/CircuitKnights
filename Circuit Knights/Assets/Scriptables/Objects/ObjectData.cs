//Duckbike
//Tony Le
//3 Nov 2018/*

using UnityEngine;

namespace CircuitKnights.Objects
{
    [RequireComponent(typeof(SetObject))]   //All CK Objects must be set and init using a SetObject component
    public abstract class ObjectData : ScriptableObject
    {
        ////The base object that all CK objects derive from
        //Reference to the actual game object itself
        //This must be set by the SetObject script ASAP (ie. first thing in Awake())
        public GameObject gameObject { get; internal set; }

        // public SkinnedMeshRenderer skinnedMeshRenderer;         //Is this required?
        // public abstract void Mount(Transform mountPoint);
        // public abstract void UnMount();
    }
}