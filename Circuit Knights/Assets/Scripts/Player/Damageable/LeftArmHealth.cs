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
	public class LeftArmHealth : Damageable
	{
		//Left arm falls off upon death

        ////Events
        //Death event broadcast; Broadcast an event upon death of this limb to whomever wants to tune in
        public static event Action<Player.Number, float> OnLeftArmHit = delegate { };
        public static event Action<Player.Number> OnLeftArmDeath = delegate { };      //Subject or broadcaster; And observer needs to implement this
		
		[SerializeField] GameObject knockedOffPrefab;
		[SerializeField] GameObject meshToHide;
		Transform InstantiatePoint;




		void Awake()
		{
			//Register for the Iframe event
			Damageable.OnFirstHit += SetIFrames;
		}
		void Start()
		{
			player = GetComponentInParent<Player>();
			opponent = player.GetOpponent();
			Assert.IsNotNull(player, "Player not found!");
			Assert.IsNotNull(opponent, "Opponent not found!");

			InstantiatePoint = transform;
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
                    OnLeftArmHit(player.No, attackMultiplier);

                    //Knockback
                    // playerData.ImpactHandler.Execute(attackMultiplier);
                }
            }
        }


		public override void TakeDamage(float damage)
		{
			player.RightArmHP -= damage;

			if (player.RightArmHP <= 0)
				Death();
		}


		public override void Death()
		{
            ////Knock off left arm
            //Hide the mesh
            meshToHide.SetActive(false);

            //Spawn in new limb to simulate getting knocked off
            var newKnockedoff = Instantiate(knockedOffPrefab, InstantiatePoint.position, InstantiatePoint.rotation);

            //Let system know the Left Arm has been knocked off
            OnLeftArmDeath(player.No);
            	//TODO reduce lance accuracy?

            //Finally disable this object so no more commands will be received
            this.gameObject.SetActive(false);
        }

	}
}