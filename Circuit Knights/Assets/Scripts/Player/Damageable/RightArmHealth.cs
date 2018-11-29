//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    [RequireComponent(typeof(Collider))]
    public class RightArmHealth : Damageable
    {
        [SerializeField] GameObject knockedOffPrefab;
		[SerializeField] Transform knockedOffInstatiatePoint;
		// [Tooltip("The mesh that will be hidden upon impact")][SerializeField] GameObject rightArmMesh;
		[Tooltip("Used to fine tune the damage")][SerializeField] float damageFactor = 1f;

		void Start()
        {
            AutoRetrieveReferences();
            AssertReferences();
        }

        void OnCollisionEnter(Collision other)
        {
            //If hit by opponent's lance then raise/send event
            if (other.collider == opponentData.LanceCollider)
            {
                TakeDamage(opponentData.LanceData.Attack);
            }
        }

        public override void TakeDamage(float damage)
        {
			//Take damage based on velocity of horse/lance
			//var finalDamage = playerData.PlayerMover.Velocity * damageFactor * damage;
			playerData.RightArmHP -= damage;

			//Play knockback animation
			playerData.Animator.SetTrigger("Knockback");

			if (playerData.RightArmHP <= 0)
				Death();
        }

        public override void Death()
        {
			//Limb gets knocked off
			//Hide the limb
			// rightArmMesh.SetActive(false);
			gameObject.SetActive(false);

			//Spawn in new limb to simulate getting knocked off
			var newKnockedoff = Instantiate(knockedOffPrefab, knockedOffInstatiatePoint.position, knockedOffInstatiatePoint.rotation);

			//TODO let system know that Right Arm has fallen off via event
		}


        #region Inits
		public void AutoRetrieveReferences()
		{
			playerData = GetComponentInParent<Player>().Data;
			opponentData = GetComponentInParent<Player>().Data.GetOpponent();
		}

		public void AssertReferences()
		{
			Assert.IsNotNull(playerData, "Player data not found!");
			Assert.IsNotNull(opponentData, "Opponent data not found!");
		}
        #endregion
	}
}
