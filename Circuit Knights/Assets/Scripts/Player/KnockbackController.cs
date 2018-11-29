//DuckBike
//Tony Le
//29 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using System.Collections;

namespace CircuitKnights.Controllers
{
	public class KnockbackController : MonoBehaviour
	{
		PlayerData playerData;
		Animator anim;
		[SerializeField] Transform leftHand;
		[SerializeField] Transform rightHand;

		void Awake()
		{
			playerData = GetComponent<Player>().Data;
			anim = playerData.Animator;
		}

		public IEnumerator Execute(float impact)
		{
			////1. Knockback
			//Disable IK controllers
			playerData.IKShieldHold.enabled = false;
			playerData.IKLanceHolder.enabled = false;
			playerData.IKLook.enabled = false;
			//Parent shield and lance to arms
			var origLeftHand = playerData.ShieldData.gameObject.transform.parent;
			var origRightHand = playerData.LanceData.gameObject.transform.parent;
			playerData.ShieldData.gameObject.transform.SetParent(leftHand);
			playerData.LanceData.gameObject.transform.SetParent(rightHand);

			////2. Display the result in game in real-time
			yield return StartCoroutine(HandleKnockBackAnimation());
			
			////3. Go back to normal
			//Re-enable IK controllers
			playerData.IKShieldHold.enabled = false;
			playerData.IKLanceHolder.enabled = false;
			playerData.IKLook.enabled = false;
			//Reset shield and lance to arms
			playerData.ShieldData.gameObject.transform.SetParent(origLeftHand);
			playerData.LanceData.gameObject.transform.SetParent(origRightHand);
		}

		private IEnumerator HandleKnockBackAnimation()
		{
			Debug.Log("handling knockback animation");

			//Use parabolic formula: -(2x-1)^2 + 1
			for (float i = 0f; i < 1; i += 0.1f)
			{
				anim.SetFloat("KnockbackAxis", i);
				yield return null;
			}
		}
	}

}