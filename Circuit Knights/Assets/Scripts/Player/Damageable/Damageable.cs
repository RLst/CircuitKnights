//DuckBike
//Tony Le
//9 Nov 2018

using System;
using System.Collections;
using CircuitKnights.Players;
using UnityEngine;

namespace CircuitKnights
{
    public abstract class Damageable : MonoBehaviour
	{
		protected Player player;
		protected Player opponent;


		public abstract void TakeDamage(float damage);
		public abstract void Death();


        protected float CalculateImpact(float attack, out float attackMultiplier)
        {
            var minSpeed = player.Horse.MinSpeed;
            var maxSpeed = player.Horse.MaxSpeed;
            var currentVelocity = player.Horse.Vel.magnitude;

            var baseAttack = attack;
			//Attack multiplier based on speed
            attackMultiplier = (currentVelocity - minSpeed) / (maxSpeed - minSpeed);    //Maps within 0 & 1 based on min and max speeds

            return baseAttack * attackMultiplier;
        }


	#region Invincibility
		//If a player damageable is hit, the others must become invincinble for short period,
		//otherwise the lance can just swing across multiple limbs and damage them all.
		//Only the first damageable hit will be affected.
		//Static just in case each Health script creates different OnFirstHits
		protected static event Action<Player.Number> OnFirstHit = delegate { };    //Params(playerNo, impact)
		protected bool isInvincible = false;
		const float invincibilityTime = 1f;		//1 second of invincibility should be enough right?
		protected void SetIFrames(Player.Number playerHit)
		{
            if(gameObject.activeInHierarchy)
			    StartCoroutine(IFramesRoutine(playerHit));
		}
		protected IEnumerator IFramesRoutine(Player.Number playerHit)
		{
			if (playerHit == player.No)
			{
				//Make this invicible for a period of time
				isInvincible = true;
                Debug.Log("Player " + playerHit + " invincible! "+Time.time);
				yield return new WaitForSeconds(invincibilityTime);
                Debug.Log("Player " + playerHit + " not Invincible! "+Time.time);
				isInvincible = false;
			}
		}
	#endregion
	}
}


