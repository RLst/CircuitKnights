//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public class LeftArmHealth : Damageable
    {
        [SerializeField] GameObject knockedOffPrefab;
		[SerializeField] Transform knockedOffInstatiatePoint;
		// [Tooltip("The mesh that will be hidden upon impact")] [SerializeField] GameObject leftArmMesh;
		[Tooltip("Used to fine tune the damage")] [SerializeField] float damageFactor = 1f;

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
			//TODO var finalDamage = playerData.PlayerMover.Velocity * damageFactor * damage;
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
			// leftArmMesh.SetActive(false);
			gameObject.SetActive(false);

			//Spawn in new limb to simulate getting knocked off
			var newKnockedoff = Instantiate(knockedOffPrefab, knockedOffInstatiatePoint.position, knockedOffInstatiatePoint.rotation);

            //TODO Let system know the Left Arm has been knocked off ie. reduce lance accuracy
        }


		#region Inits
		void Start()
		{
			AutoRetrieveReferences();
			AssertReferences();
		}
		public override void AutoRetrieveReferences()
		{
			playerData = GetComponentInParent<Player>().Data;
			opponentData = GetComponentInParent<Player>().Data.GetOpponent();
		}
		public override void AssertReferences()
		{
			Assert.IsNotNull(playerData, "Player data not found!");
			Assert.IsNotNull(opponentData, "Opponent data not found!");
		}
		#endregion
	}
}