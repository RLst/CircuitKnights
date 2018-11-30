using CircuitKnights.Objects;
using UnityEngine;

namespace CircuitKnights
{
	[RequireComponent(typeof(Player))]
	public class PlayerLean : MonoBehaviour
	{
		// [SerializeField]
		// [TextArea]
		// string description =
		// 	"Attach to root object.";

		PlayerData playerData;
		Animator animator;
		PlayerInput playerInput;
		float leanAxis;

		void Awake()
		{
			animator = GetComponentInChildren<Animator>();
			playerInput = GetComponent<PlayerInput>();
			playerData = GetComponent<Player>().Data;
		}

		void Update()
		{
			DoLean();
		}

		private void DoLean()
		{
			var desiredLeanAxis = -playerInput.LeanLeft + playerInput.LeanRight;
			leanAxis = Mathf.Lerp(leanAxis, desiredLeanAxis, playerData.LeanInertia);
			animator.SetFloat("LeanAxis", leanAxis);
		}
	}

}