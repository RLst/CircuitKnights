//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Objects
{

    [CreateAssetMenu(fileName = "New Shield", menuName = "Shield", order = 54)]
    public class Shield : ScriptableObject
    {
        [Multiline][SerializeField] string description = "";
        [SerializeField] float mass = 10f;
        [SerializeField] float hitPoints = 100;
		public float HitPoints { get { return hitPoints;} }

        [SerializeField] Vector3 blockingOffset;
        public Vector3 BlockingOffset { get { return blockingOffset; } }

    }
}