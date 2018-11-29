//DuckBike
//Tony Le
//9 Nov 2018

using System;
using System.Collections;
using CircuitKnights.Objects;
using UnityEngine;
using UnityEngine.Assertions;

namespace CircuitKnights
{
	public abstract class Damageable : MonoBehaviour
	{
		protected bool isInvincible = false;
		protected PlayerData playerData;
		protected PlayerData opponentData;

		public static event Action<PlayerData.PlayerNumber, float> OnFirstHit = delegate { };    //Params(playerNo, impact)
		public abstract void TakeDamage(float damage);
		public abstract void Death();

		protected void SetIFrames(PlayerData.PlayerNumber playerHit, float impact)
		{
			StartCoroutine(IFrames(playerHit, impact));
		}
		protected IEnumerator IFrames(PlayerData.PlayerNumber playerHit, float impact)
		{
			if (playerHit == playerData.No)
			{
				const float timeFactorTweak = 1f;
				//Make this invicible for a period of time
				isInvincible = true;
                Debug.Log("Invincible for "+impact * timeFactorTweak);
				yield return new WaitForSeconds(impact * timeFactorTweak);
                Debug.Log("Not invincible!");
				isInvincible = false;
			}
		}

		protected float CalculateImpact(float attack, out float attackMultiplierBasedOnSpeed)
		{
			var minSpeed = playerData.Horse.MinSpeed;
			var maxSpeed = playerData.Horse.MaxSpeed;
			var currentVelocity = playerData.Horse.Vel.magnitude;

			var baseAttack = attack;
			attackMultiplierBasedOnSpeed = (currentVelocity - minSpeed) / (maxSpeed - minSpeed);    //Maps within 0 & 1 based on min and max speeds

			return baseAttack * attackMultiplierBasedOnSpeed;
		}
	}
}


