using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights
{

public class PlayerIKController : MonoBehaviour {
	////Handle all IK operations such as:
	//// - Left Arm (includes hand and elbow) holding onto the horse saddle handle
	//// - Right Arm holding onto the lance
	//// - Lean left and right using manual manipulation of chest and spine bones
	//// - Lance lunge/thrust
	//// - Lance impact recoil
	//// - Unhorse ragdolling

	//Controller
	[SerializeField] XboxController controller;
	[SerializeField] XboxAxis leanAxis;

	Animator anim;

	///IK
	[Header("Look At")]
	[SerializeField] Transform lookAtTarget;
	[SerializeField] float lookAtIKWeight = 1f;
	[SerializeField] float bodyIKWeight = 0.7f;
	[SerializeField] float headIKWeight = 1f;
	[Tooltip("Not Applicable")] float eyesIKWeight = 0f;
	[SerializeField] float clampIKWeight = 1f;

	[Header("Left Arm")]
	[Tooltip("Attach to Horse Saddle Handle")][SerializeField] Transform leftHandTarget;
	[Tooltip("Left elbow")][SerializeField] Transform leftArmHint;
	[SerializeField] float leftArmIKWeight = 0.9f;
	

	[Header("Right Arm")]
	[Tooltip("Attach to lance handle")][SerializeField] Transform rightHandTarget;
	[Tooltip("Right elbow")][SerializeField] Transform rightArmHint;
	[SerializeField] float rightArmIKWeight = 1f;

	[Header("Lean")]
	Transform chest;
	Transform spine;	//Abdomen/stomach; bone directly underneath the chest bone
	// public Transform leanTarget;	//Should this be accessible by other scripts??? OR control directly
	[Tooltip("A dodge is positional only")][SerializeField] float dodgeFactor = 5f;
	[Tooltip("A lean is angular")][SerializeField] float leanFactor = 180f;

	void Start () {
		anim = GetComponent<Animator>();
		chest = anim.GetBoneTransform(HumanBodyBones.Chest);
		spine = anim.GetBoneTransform(HumanBodyBones.Spine);

		//Set IK Weights (should these be in OnAnimatorIK()?)
		anim.SetLookAtWeight(lookAtIKWeight, bodyIKWeight, headIKWeight, eyesIKWeight, clampIKWeight);
		anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftArmIKWeight);
		anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightArmIKWeight);
	}

	void LateUpdate () {
		HandleLean();
	}

	void OnAnimatorIK()
	{
		HandleLook();
		HandleLeftArm();
		HandleRightArm();
	}



	void HandleLean() {
		var xThrow = XCI.GetAxis(leanAxis, controller);
		spine.position += new Vector3(xThrow * dodgeFactor * Time.deltaTime, 0f, 0f);
		spine.rotation *= Quaternion.Euler(0f, xThrow * leanFactor * Time.deltaTime , 0f);
	}

	void HandleLeftArm() {
		if (leftHandTarget != null)
		{
			
		}
		// else {
		// 	Debug.LogWarning("Left arm not setup!");
		// }
	}

	void HandleRightArm() {
		if (rightHandTarget != null)
		{
			anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
			anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);

			anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, rightArmIKWeight);
			anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightArmHint.position);
		}
		// else {
		// 	Debug.LogWarning("Right arm not setup!");
		// }
	}

	void HandleLook() {
		if (lookAtTarget != null)
		{
			anim.SetLookAtPosition(lookAtTarget.position);
		}
	}



}

}