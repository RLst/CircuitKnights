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
	public class HeadHealth : Damageable
	{
		//Head falls off upon death

        ////Events
        //Death event broadcast; Broadcast an event upon death of this limb to whomever wants to tune in
        public static event Action<PlayerData.PlayerNumber, float> OnHeadHit = delegate { };
        public static event Action<PlayerData.PlayerNumber, GameObject> OnHeadDeath = delegate { };     //Subject or broadcaster; And observer needs to implement this
		
		
		[SerializeField] GameObject knockedOffPrefab;   //The limb that falls off
		[SerializeField] GameObject meshToHide;
		Transform InstantiatePoint;



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


		void OnCollisionEnter(Collision other)
		{
			if (other.collider == opponentData.LanceCollider)
			{
				//If another limb or shield has already be hit
				if (!isInvincible)
				{
					//Calculate impact; impact is the amount of damage based on the speed of the horse and lance attack rating
					float attackMultiplier;
					var attack = opponentData.LanceData.Attack;
                    var impact = CalculateImpact(attack, out attackMultiplier);

                    //This damageable is first hit; set the rest to temp invincibility
                    SetIFrames(playerData.No);

                    //Limb takes damage
					TakeDamage(impact);

                    //Let ether know head was hit
                    OnHeadHit(playerData.No, attackMultiplier);

                    //Knockback
                    // playerData.ImpactHandler.Execute(attackMultiplier);
				}
			}
		}


		public override void TakeDamage(float damage)
		{
			playerData.HeadHP -= damage;    //TODO make damage => finalDamage

			if (playerData.HeadHP <= 0)
				Death();
		}


		public override void Death()
		{
			////Knock head off
			//Hide the head
			meshToHide.SetActive(false);

			//Spawn in new head to simulate getting knocked off
			var knockedOffHead = Instantiate(knockedOffPrefab, InstantiatePoint.position, InstantiatePoint.rotation);

			//Let the system know that the player's head has fallen off
			OnHeadDeath(playerData.No, knockedOffHead);

            //Finally disable this object so no more commands will be received
            this.gameObject.SetActive(false);
        }

	}
}