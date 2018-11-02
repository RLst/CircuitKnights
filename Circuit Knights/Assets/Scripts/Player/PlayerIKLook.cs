using CircuitKnights.Variables;
using UnityEngine;
using UnityEngine.Assertions;

namespace CircuitKnights
{
	public class PlayerIKLook : MonoBehaviour
	{
		[Multiline]
		public string description =
			"Controls where the player looks." +
			"Should be set to the opponent at gameplay." +
			"Could possibly be set to look around at the audience.";

		Animator anim;

		[SerializeField] TransformVariable lookTarget;
		[SerializeField] FloatReference overallIKWeight;
		[SerializeField] FloatReference lookIKWeight;
		[SerializeField] FloatReference bodyIKWeight;
		[SerializeField] FloatReference headIKWeight;
		float eyesIKWeight = 0f;	//Not really applicable as our robots don't have eyes
		[SerializeField] FloatReference clampIKWeight;

		private void Awake()
		{
			anim = GetComponent<Animator>();
			if (!anim) anim = GetComponentInParent<Animator>();
		}

		void Start()
		{
			Assert.IsNotNull(anim, "Animator not found!");
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (lookTarget)
			{
				//Weights
				anim.SetLookAtWeight(
					overallIKWeight.Value,
					bodyIKWeight.Value,
					headIKWeight.Value,
					eyesIKWeight,
					clampIKWeight.Value);

				//IK
				anim.SetLookAtPosition(lookTarget.Value.position);
			}
			else
			{
				Debug.LogWarning("Look at not setup!");
			}
		}

	}
}