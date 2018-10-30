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

		Animator anim;
		Transform spine;
		[SerializeField] KnightObject player;

		[Header("IK")]
		[SerializeField] TransformVariable leftHand;
		[SerializeField] TransformVariable leftElbow;
		[SerializeField] FloatReference IKWeight;

		[Header("Lean & Dodge")]
		[SerializeField] FloatReference leanFactor;
		[SerializeField] FloatReference dodgeFactor;

		private void Start()
		{
			anim = GetComponent<Animator>();
			spine = anim.GetBoneTransform(HumanBodyBones.Spine);
		}

		private void LateUpdate()
		{
			var xThrow = XCI.GetAxis(player.leanAxisX, player.controller);
			Vector3 newSpinePosition = spine.localPosition;
			newSpinePosition.z += xThrow * dodgeFactor * Time.deltaTime;
			spine.position += newSpinePosition;
			spine.rotation *= Quaternion.Euler(0f, xThrow * leanFactor * Time.deltaTime, 0f);
		}
    }
}