using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights.Controllers
{

	public class PlayerIKHoldLance : MonoBehaviour
	{
		[Multiline]
		public string description =
			"Holds the lance. Elbow hint should be up high to look cool and realistic." +
			"Lance handle should be offsetted correctly with empty game object." +
			"This script should be disabled upon events: PlayerDeath and/or very heavy impact" +
			"Attached to root object of animator.";

		Animator anim;

		[SerializeField] Transform rightHand;
		[SerializeField] Transform rightElbow;
		[SerializeField][Range(0f, 1f)] float IKWeight = 0.9f;

		private void Awake()
		{
			anim = GetComponentInChildren<Animator>();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (!rightHand && !rightElbow)
			{
				Debug.LogWarning("Right arm not set up yet!");
				return;
			}

			//Hand
			anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight);
			anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKWeight);
			anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
			anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);

			//Elbow
			anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, IKWeight);
			anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbow.position);

		}

	}
}