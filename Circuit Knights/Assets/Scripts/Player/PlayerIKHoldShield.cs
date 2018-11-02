using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights
{
	public class PlayerIKHoldShield : MonoBehaviour
	{

		[Multiline]
		public string description =
			"Connected to the shield.\n Can also hold the reins if any.\n" +
			"Shield handle should be offsetted to the left with empty game object." +
			"This script should be disabled upon events: PlayerDeath, LeftArmDeath." +
			"Attach to root object of animator.";

		Animator anim;

		[SerializeField] Transform leftHand;
		[SerializeField] Transform leftElbow;
		[SerializeField] FloatReference IKWeight;

		private void Awake()
		{
			anim = GetComponent<Animator>();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (!leftHand && !leftElbow)
			{
				Debug.LogWarning("Left arm not set up yet!");
				return;
			}

			//Hand
			anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKWeight.Value);
			anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKWeight.Value);
			anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
			anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);

			//Elbow
			anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, IKWeight.Value);
			anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbow.position);

		}
	}
}
