// //Duckbike
// //Tony Le
// //26 Oct 2018

// using UnityEngine;

// namespace CircuitKnights.Objects
// {

//     [CreateAssetMenu(fileName = "New Shield Data", menuName = "Shield", order = 54)]
//     public class ShieldData : ObjectData
//     {
//         //[TextArea][SerializeField] string description = 
//         //    "Holds shield data. Defense is how much of the lance's attack get's taken off.";
//         [Tooltip("Lower is smoother")][Range(0f, 1f)][SerializeField] float smoothness = 0.25f;
//         //[SerializeField] float mass = 10f;

//         [Header("Stats")]
//         [SerializeField] float maxHP = 100;
//         [SerializeField] float defense = 10f;
//         public float Defense { get { return defense; } }
// 		public float HP { get; set; }
//         public bool IsDead { get { return HP <= 0; } }
//         public float tValue { get { return smoothness; } }


//         [Header("Offsets and Angle Factors")]
//         [SerializeField] Vector3 centreOffset;
//         [SerializeField] Vector3 centreAngFactor;
//         [SerializeField] Vector3 blockOffset;
//         [SerializeField] float blockXAngFactor;
//         [SerializeField] float blockYAngFactor;
//         public Vector3 CentreOffset { get { return centreOffset; } }
//         public Vector3 CentreAngFactor { get { return centreAngFactor; } }
//         public Vector3 BlockOffset { get { return blockOffset; } }
//         public float BlockingXAngleFactor { get { return blockXAngFactor; } }
//         public float BlockingYAngleFactor { get { return blockYAngFactor; } }

//         [Header("Block Weights")]
//         [Tooltip("How much input the shield can go left")][SerializeField] float blockLeftWeight = 1f;
//         [SerializeField] float blockRightWeight = 1f;
//         [SerializeField] float blockUpWeight = 0.75f;
//         [SerializeField] float blockDownWeight = 0.2f;
//         public float BlockLeftWeight { get { return blockLeftWeight; } }
//         public float BlockRightWeight { get { return blockRightWeight; } }
//         public float BlockUpWeight { get { return blockUpWeight; } }
//         public float BlockDownWeight { get { return blockDownWeight; } }


//         void OnEnable()
//         {
//             ResetHP();
//         }

//         public void ResetHP()
//         {
//             HP = maxHP;
//         }
//     }
// }