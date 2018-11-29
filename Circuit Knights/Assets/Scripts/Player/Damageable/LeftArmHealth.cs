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
	public class LeftArmHealth : Damageable
	{
		[SerializeField] GameObject knockedOffPrefab;
		[SerializeField] GameObject meshToHide;
		Transform InstatiatePoint;

		//Broadcast events
		public static event Action<PlayerData.PlayerNumber> OnLeftArmDeath = delegate { };      //Subject or broadcaster; And observer needs to implement this



		#region Inits
		void Awake()
		{
			//Register for the Iframe event
			Damageable.OnFirstHit += SetIFrames;
		}
		void Start()
		{
			playerData = GetComponentInParent<Player>().Data;
			opponentData = GetComponentInParent<Player>().Data.GetOpponent();
			Assert.IsNotNull(playerData, "Player data not found!");
			Assert.IsNotNull(opponentData, "Opponent data not found!");

			InstatiatePoint = transform;
		}
		#endregion


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
			var newKnockedoff = Instantiate(knockedOffPrefab, InstatiatePoint.position, InstatiatePoint.rotation);

			//TODO Let system know the Left Arm has been knocked off ie. reduce lance accuracy
		}

	}
}