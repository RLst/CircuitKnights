//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using UnityEditor;

namespace CircuitKnights.Objects
{
    [CreateAssetMenu(fileName = "New Lance", menuName = "Lance", order = 53)]
    public class Lance : ScriptableObject
    {
        [Multiline][SerializeField] string description = "";

        [Header("Physics")]
		[SerializeField] float mass = 25f;
        [SerializeField] float length = 3.3f;
        public float Mass { get { return mass; } }
        public float Length { get { return length; } }
		public float MomentOfInertia { get { return 1f/ 3f * mass * length * length; } }
		public float GravityFactor { get { return gravityFactor;} }
		public float DragFactor { get { return dragFactor; } }

		[Header("Control")]
		[Tooltip("Lazy implementation")][SerializeField] float gravityFactor = 300f;
		[Tooltip("Lazy implementation")][Range(1.001f, 10f)][SerializeField] float dragFactor = 1.05f;
        [Tooltip("Increases control by decreasing lerp tValue")][SerializeField] float controlFactor = 0.1f;
		[SerializeField] float pitchTorque = 1000;
		[SerializeField] float yawTorque = 1000;
		public float PitchTorque { get { return pitchTorque; } }
		public float YawTorque { get { return yawTorque; } }

		[Header("Limits")]
        [SerializeField] bool clamped = true;
		[SerializeField] float startingPitchAngle = -15f;
		[SerializeField] float startingYawAngle = 80f;
		[Tooltip("Degrees")][SerializeField] float PitchRange = 90f;
		[Tooltip("Degrees")][SerializeField] float YawRange = 90f;
		public float ControlFactor { get { return controlFactor; } }
        public bool isClamped { get { return clamped; } }
		public float MinPitch { get { return startingPitchAngle; } }
		public float MaxPitch { get { return startingPitchAngle + PitchRange; } }
		public float MinYaw { get { return startingYawAngle; } }
		public float MaxYaw { get { return startingYawAngle + YawRange; } }


    }
}