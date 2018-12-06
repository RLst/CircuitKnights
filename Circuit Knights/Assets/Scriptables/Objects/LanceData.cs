// //Duckbike
// //Tony Le
// //26 Oct 2018

// using UnityEngine;
// //using UnityEditor;

// namespace CircuitKnights.Objects
// {
//     [CreateAssetMenu(fileName = "New Lance Data", menuName = "Lance", order = 53)]
//     public class LanceData : ObjectData
//     {
//         //     [TextArea][SerializeField] string description = 
//         //"The player's lance";

//         [Header("Physics")]
//         [SerializeField] float mass = 25f;
//         [SerializeField] float length = 3.3f;
//         public float Mass { get { return mass; } }
//         public float Length { get { return length; } }
//         public float MomentOfInertia { get { return 1f / 3f * mass * length * length; } }
//         [Tooltip("Lazy implementation")] [Range(1.001f, 4f)] [SerializeField] float dragFactor = 1.05f;
//         [Tooltip("Lazy implementation")] [SerializeField] float gravityFactor = 300f;
//         public float DragFactor { get { return dragFactor; } }
//         public float GravityFactor { get { return gravityFactor; } }


//         [Header("Control")]
//         [Tooltip("Lerp to reduce jarring clamp. Too much may decrease accuracy")]
//         [Range(0.05f, 1f)] [SerializeField] float lerpFactor;
//         [SerializeField] float pitchTorque = 1000;
//         [SerializeField] float yawTorque = 1000;
//         public float LerpFactor { get { return lerpFactor; } }
//         public float PitchTorque { get { return pitchTorque; } }
//         public float YawTorque { get { return yawTorque; } }

//         [Header("Stats")]
//         [SerializeField] float attack = 20f;
//         public float Attack { get { return attack; } }

//         [Header("Limits")]
//         [SerializeField] bool clamped = true;
//         [SerializeField] float startingPitchAngle = -15f;
//         [SerializeField] float startingYawAngle = 80f;
//         [Tooltip("Degrees")] [SerializeField] float PitchRange = 90f;
//         [Tooltip("Degrees")] [SerializeField] float YawRange = 90f;
//         public bool isClamped { get { return clamped; } }
//         public float MinPitch { get { return startingPitchAngle; } }
//         public float MaxPitch { get { return startingPitchAngle + PitchRange; } }
//         public float MinYaw { get { return startingYawAngle; } }
//         public float MaxYaw { get { return startingYawAngle + YawRange; } }


//     }
// }