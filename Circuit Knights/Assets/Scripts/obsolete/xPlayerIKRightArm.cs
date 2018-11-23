// using CircuitKnights.Variables;
// using UnityEngine;

// namespace CircuitKnights
// {

// 	public class xPlayerIKRightArm : MonoBehaviour
// 	{
// 		[Multiline]
// 		public string description =
// 			"Holds the lance. Elbow hint should be up high to look cool and realistic." +
// 			"Lance handle should be offsetted correctly with empty game object." +
// 			"This script should be disabled upon events: PlayerDeath and/or very heavy impact" +
// 			"Attached to root object of animator.";

// 		Animator anim;

// 		[SerializeField] Transform rightHand;
// 		[SerializeField] Transform rightElbow;
// 		[SerializeField] FloatReference IKWeight;

// 		private void Start()
// 		{
// 			anim = GetComponent<Animator>();
// 		}

// 		private void OnAnimatorIK(int layerIndex)
// 		{
// 			if (!rightHand && !rightElbow)
// 			{
// 				Debug.LogWarning("Right arm not set up yet!");
// 				return;
// 			}

// 			//Hand
// 			anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight.Value);
// 			anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKWeight.Value);
// 			anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
// 			anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);

// 			//Elbow
// 			anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, IKWeight.Value);
// 			anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbow.position);

// 		}

// 	}
// }