//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using System;
using UnityEngine.Assertions;
using CircuitKnights.Players;

namespace CircuitKnights
{
    [RequireComponent(typeof(Collider))]
	public class HeadHealth : Damageable
	{
		//Head falls off upon death

        ////Events
        //Death event broadcast; Broadcast an event upon death of this limb to whomever wants to tune in
        public static event Action<Player.Number, float> OnHeadHit = delegate { };
        public static event Action<Player.Number, GameObject> OnHeadDeath = delegate { };     //Subject or broadcaster; And observer needs to implement this
		
		
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
			player = GetComponentInParent<Player>();
			opponent = player.GetOpponent();
			Assert.IsNotNull(player, "Player not found!");
			Assert.IsNotNull(opponent, "Opponent not found!");

			if (InstantiatePoint == null) InstantiatePoint = transform;     //Set to default if none
		}


		void OnCollisionEnter(Collision other)
		{
			if (other.collider == opponent.LanceCollider)
			{
				//If another limb or shield has already be hit
				if (!isInvincible)
				{
					//Calculate impact; impact is the amount of damage based on the speed of the horse and lance attack rating
					float attackMultiplier;
					var attack = opponent.Lance.Attack;
                    var impact = CalculateImpact(attack, out attackMultiplier);

                    //This damageable is first hit; set the rest to temp invincibility
                    SetIFrames(player.No);

                    //Limb takes damage
					TakeDamage(impact);

                    //Let ether know head was hit
                    OnHeadHit(player.No, attackMultiplier);

                    //Knockback
                    // playerData.ImpactHandler.Execute(attackMultiplier);
				}
			}
		}


		public override void TakeDamage(float damage)
		{
			player.HeadHP -= damage;    //TODO make damage => finalDamage

			if (player.HeadHP <= 0)
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
			OnHeadDeath(player.No, knockedOffHead);

            //Finally disable this object so no more commands will be received
            this.gameObject.SetActive(false);
        }

	}
}