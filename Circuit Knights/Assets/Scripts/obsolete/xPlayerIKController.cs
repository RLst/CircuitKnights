// using UnityEngine;
// using XboxCtrlrInput;
// using CircuitKnights.Variables;

// namespace CircuitKnights
// {

// 	public class PlayerIKController : MonoBehaviour
// 	{
// 		////Handle all IK operations such as:
// 		//// - Left Arm (includes hand and elbow) holding onto the horse saddle handle
// 		//// - Right Arm holding onto the lance
// 		//// - Lean left and right using manual manipulation of chest and spine bones
// 		//// - Lance lunge/thrust
// 		//// - Lance impact recoil
// 		//// - Unhorse ragdolling

// 		//Controller
// 		[SerializeField] XboxController controller;

// 		Animator anim;

// 		///IK
// 		[Header("Look At")]
// 		[SerializeField] Transform lookAtTarget;
// 		[Range(0f, 1f)] [SerializeField] float lookAtIKWeight = 1f;
// 		[Range(0f, 1f)] [SerializeField] float bodyIKWeight = 0.7f;
// 		[Range(0f, 1f)] [SerializeField] float headIKWeight = 1f;
// 		[Tooltip("Not Applicable")] float eyesIKWeight = 0f;
// 		[Range(0f, 1f)] [SerializeField] float clampIKWeight = 1f;

// 		[Header("Left Arm")]
// 		[Tooltip("Attach to Horse Saddle Handle")]
// 		[SerializeField]
// 		Transform leftHandTarget;
// 		[Tooltip("Left elbow")] [SerializeField] Transform leftArmHint;
// 		[Range(0f, 1f)] [SerializeField] float leftArmIKWeight = 0.9f;


// 		[Header("Right Arm")]
// 		[Tooltip("Attach to lance handle")]
// 		[SerializeField]
// 		Transform rightHandTarget;
// 		[Tooltip("Right elbow")] [SerializeField] Transform rightArmHint;
// 		[Range(0f, 1f)] [SerializeField] float rightArmIKWeight = 1f;

// 		///Lean
// 		Transform chest;
// 		Transform spine;    //Abdomen/stomach; bone directly underneath the chest bone
// 		[Header("Lean")]
// 		// public Transform leanTarget;	//Should this be accessible by other scripts??? OR control directly
// 		[SerializeField]
// 		XboxAxis leanAxis;
// 		[SerializeField] Transform lance;
// 		[Tooltip("A dodge is positional only")] [SerializeField] float dodgeFactor = 5f;
// 		[Tooltip("A lean is angular")] [SerializeField] float leanFactor = 180f;

// 		void Start()
// 		{
// 			anim = GetComponent<Animator>();
// 			chest = anim.GetBoneTransform(HumanBodyBones.Chest);
// 			spine = anim.GetBoneTransform(HumanBodyBones.Spine);
// 		}
// 		void LateUpdate()
// 		{
// 			HandleLean();
// 			// tempMoveLance();
// 		}

// 		// void tempMoveLance()
// 		// {
// 		// 	var xThrow = XCI.GetAxis(leanAxis, controller);
// 		// 	Vector3 newLancePosition = lance.position;
// 		// 	newLancePosition.z += xThrow * dodgeFactor * Time.deltaTime;
// 		// 	lance.position = newLancePosition;
// 		// 	lance.rotation *= Quaternion.Euler(0f, xThrow * leanFactor * Time.deltaTime , 0f);
// 		// }

// 		void OnAnimatorIK()
// 		{
// 			HandleLook();
// 			HandleLeftArm();
// 			HandleRightArm();
// 		}



// 		void HandleLean()
// 		{
// 			var xThrow = XCI.GetAxis(leanAxis, controller);
// 			Vector3 newSpinePosition = spine.localPosition;
// 			newSpinePosition.z += xThrow * dodgeFactor * Time.deltaTime;
// 			spine.position += newSpinePosition;
// 			spine.rotation *= Quaternion.Euler(0f, xThrow * leanFactor * Time.deltaTime, 0f);
// 		}

// 		void HandleLeftArm()
// 		{
// 			if (leftHandTarget)
// 			{
// 				//Hand
// 				anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftArmIKWeight);
// 				anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftArmIKWeight);
// 				anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
// 				anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
// 				//Elbow
// 				anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, leftArmIKWeight);
// 				anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftArmHint.position);
// 			}
// 			else
// 			{
// 				Debug.LogWarning("Left arm not setup!");
// 			}
// 		}

// 		void HandleRightArm()
// 		{
// 			if (rightHandTarget)
// 			{
// 				//Hand
// 				anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightArmIKWeight);
// 				anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightArmIKWeight);
// 				anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
// 				anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
// 				//Elbow
// 				anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, rightArmIKWeight);
// 				anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightArmHint.position);
// 			}
// 			else
// 			{
// 				Debug.LogWarning("Right arm not setup!");
// 			}
// 		}

// 		void HandleLook()
// 		{

// 		}

// 	}

// }