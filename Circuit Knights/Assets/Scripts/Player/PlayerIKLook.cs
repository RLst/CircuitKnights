using CircuitKnights.Variables;
using UnityEngine;
using UnityEngine.Assertions;

namespace CircuitKnights.Controllers
{
	public class PlayerIKLook : MonoBehaviour
	{
		[Multiline]
		public string description =
			"Controls where the player looks." +
			"Should be set to the opponent at gameplay." +
			"Could possibly be set to look around at the audience.";

		Animator anim;

		[SerializeField] Transform lookTarget;
		[SerializeField] [Range(0f, 1f)] float overallIKWeight = 1f;
		[SerializeField] [Range(0f, 1f)] float lookIKWeight = 1f;
		[SerializeField] [Range(0f, 1f)] float bodyIKWeight = 1f;
		[SerializeField] [Range(0f, 1f)] float headIKWeight = 1f;
		float eyesIKWeight = 0f;	//Not really applicable as our robots don't have eyes
		[SerializeField] [Range(0f, 1f)] float clampIKWeight = 1f;

		private void Awake()
		{
			anim = GetComponentInChildren<Animator>();
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
					overallIKWeight,
					bodyIKWeight,
					headIKWeight,
					eyesIKWeight,
					clampIKWeight);

				//IK
				anim.SetLookAtPosition(lookTarget.position);
			}
			else
			{
				Debug.LogWarning("Look at not setup!");
			}
		}

	}
}