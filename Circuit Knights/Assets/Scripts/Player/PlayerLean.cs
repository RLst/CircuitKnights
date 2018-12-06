using CircuitKnights.Players;
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

		Player player;
		Animator animator;
		PlayerInput playerInput;
		float leanAxis;

		void Awake()
		{
			animator = GetComponentInChildren<Animator>();
			playerInput = GetComponent<PlayerInput>();
			player = GetComponent<Player>();
		}

		void Update()
		{
			DoLean();
		}

		private void DoLean()
		{
			var desiredLeanAxis = -playerInput.LeanLeft + playerInput.LeanRight;
			leanAxis = Mathf.Lerp(leanAxis, desiredLeanAxis, player.LeanInertia);
			animator.SetFloat("LeanAxis", leanAxis);
		}
	}

}