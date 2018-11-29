using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights.Controllers
{
	public class PlayerIKHoldShield : MonoBehaviour
	{

		[Multiline]
		public string description =
			"Attach to the robot/player root" +
			"Connected to the shield.\n Can also hold the reins if any.\n" +
			"Shield handle should be offsetted to the left with empty game object." +
			"This script should be disabled upon events: PlayerDeath, LeftArmDeath.";

		Animator anim;

		[SerializeField] Transform leftHand;
		[SerializeField] Transform leftElbow;
		[SerializeField][Range(0f,1f)] float IKWeight = 0.9f;

		private void Awake()
		{
			anim = GetComponentInChildren<Animator>();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (!leftHand && !leftElbow)
			{
				Debug.LogWarning("Left arm not set up yet!");
				return;
			}

			//Hand
			anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKWeight);
			anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
			anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);

			//Elbow
			anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, IKWeight);
			anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbow.position);

		}
	}
}
