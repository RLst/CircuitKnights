//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;
using System.Collections;

namespace CircuitKnights
{
	[RequireComponent(typeof(Collider))]
	public class HeadHealth : Damageable
	{
		[SerializeField] GameObject knockedOffPrefab;   //The limb that falls off
		[SerializeField] GameObject meshToHide;
		Transform InstantiatePoint;

		//Broadcast event
		public static event Action<PlayerData.PlayerNumber> OnHeadDeath = delegate { };     //Subject or broadcaster; And observer needs to implement this



		#region Inits
		void Awake()
		{
			//Register for events
			Damageable.OnFirstHit += SetIFrames;
		}
		void Start()
		{
			playerData = GetComponentInParent<Player>().Data;
			opponentData = playerData.GetOpponent();

			Assert.IsNotNull(playerData, "Player data not found!");
			Assert.IsNotNull(opponentData, "Opponent data not found!");

			if (InstantiatePoint == null) InstantiatePoint = transform;     //Set to default if none
		}
		#endregion


		void OnCollisionEnter(Collision other)
		{
			Debug.Log("Limb.isInvincible: " + isInvincible);

			if (other.collider == opponentData.LanceCollider)
			{
				//If another limb or shield has already be hit
				if (!isInvincible)
				{
					//Calculate impact; impact is the amount of damage based on the speed of the horse and lance attack rating
					float attackMultiplierBasedOnSpeed;
					var attack = opponentData.LanceData.Attack;
                    var impact = CalculateImpact(attack, out attackMultiplierBasedOnSpeed);  

                    //Limb takes damage
					TakeDamage(impact);

                    //Knockback
			        // playerData.KnockbackController.Execute(attackMultiplierBasedOnSpeed);
				}
			}
		}

		public override void TakeDamage(float damage)
		{
			playerData.HeadHP -= damage;    //TODO make damage => finalDamage

			//Set invincibility for all the other limbs/shield
			SetIFrames(playerData.No, damage);

			if (playerData.HeadHP <= 0)
				Death();
		}

		public override void Death()
		{
			////Heads gets knocked off

			//Hide the head
			meshToHide.SetActive(false);

			//Spawn in new head to simulate getting knocked off
			var newKnockedOff = Instantiate(knockedOffPrefab, InstantiatePoint.position, InstantiatePoint.rotation);
			//var newKnockedOff = Instantiate(knockedOffPrefab, transform.localPosition, transform.localRotation);

			//TODO let the system know that the player's head has fallen off
			OnHeadDeath(playerData.No);
		}

		private float CalculateImpact(float attack, out float attackMultiplierBasedOnSpeed)
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





		// void SetIFrames(PlayerData.PlayerNumber playerHit, float impact)
		// {
		//     StartCoroutine(IFrames(playerHit, impact));
		// }
		// private IEnumerator IFrames(PlayerData.PlayerNumber playerHit, float impact)
		// {
		//     if (playerHit == playerData.No)
		//     {
		//         const float timeFactorTweak = 1f;
		//         //Make this invicible for a period of time
		//         isInvincible = true;
		//         yield return new WaitForSeconds(impact * timeFactorTweak);
		//         isInvincible = false;
		//     }
		// }

////Stickman
//         foreach (var mesh in GetComponentsInChildren<MeshRenderer>())
//         {

//             //mesh.enabled = false;
//         }
//         GetComponent<Rigidbody>().isKinematic = false;
//         var newKnockedOff = Instantiate(knockedOffPrefab, transform.position, transform.rotation);
//         Destroy(newKnockedOff, 3f);

////Let the system know somehow that the head has been knocked off via event
//             //Camera now looks from