//DuckBike
//Tony Le
//30 Oct 2018

using CircuitKnights.Objects;
using CircuitKnights.Variables;
using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights
{
    public class PlayerIKLeanDodge : MonoBehaviour
    {
		[Multiline]
		public string description =
			"Connected to the shield. Can also hold the reins if any.\n" +
			"Shield handle should be offsetted to the left with empty game object." +
			"This script should be disabled upon events: PlayerDeath, LeftArmDeath." +
			"Attach to root object of animator.";

		private Animator anim; private Transform spine;
		private PlayerInput playerInput;

		[Header("IK")]
		[SerializeField] TransformVariable leftHand;
		[SerializeField] TransformVariable leftElbow;
		[SerializeField] FloatReference IKWeight;

		[Header("Lean & Dodge")]
		[SerializeField] FloatReference leanFactor;
		[SerializeField] FloatReference dodgeFactor;

		private void Start()
		{
			//Get the bone needed to do the lean from the animator
			anim = GetComponent<Animator>();
			spine = anim.GetBoneTransform(HumanBodyBones.Spine);

			//Get the input reader
			playerInput = GetComponent<PlayerInput>();
		}

		private void LateUpdate()
		{
			Vector3 newSpinePosition = spine.localPosition;
			newSpinePosition.z += playerInput.LeanAxisX * dodgeFactor * Time.deltaTime;
			spine.position += newSpinePosition;
			spine.rotation *= Quaternion.Euler(0f, playerInput.LeanAxisX * leanFactor * Time.deltaTime, 0f);
		}
    }
}