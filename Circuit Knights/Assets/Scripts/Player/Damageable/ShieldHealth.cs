﻿//DuckBike
//Tony Le, Jack Dawes
//9 Nov 2018

using UnityEngine;
using System;
using UnityEngine.Assertions;
using CircuitKnights.Players;
using CircuitKnights.Gear;

namespace CircuitKnights
{
    [RequireComponent(typeof(Collider))]
    public class ShieldHealth : Damageable
    {
        //Shield detaches from player upon death; Turns into standard rigidbody

        ////Events
        public static event Action<Player.Number, float> OnShieldHit = delegate { };
        public static event Action<Player.Number> OnShieldDeath = delegate { };   //Pass shield death with player
        private Shield shield;
		
        
        [SerializeField] GameObject knockedOffPrefab;   //The limb that falls off
		[SerializeField] Transform knockedOffSpawnPoint;
		// [Tooltip("The mesh that will be hidden upon impact")] [SerializeField] GameObject shieldMesh;   //The mesh of the head that needs to disappear


        void Start()
        {
            player = GetComponentInParent<Player>();
            opponent = player.GetOpponent();
            shield = player.Shield;
            Assert.IsNotNull(player, "Player not found!");
            Assert.IsNotNull(opponent, "Opponent not found!");
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
                    OnShieldHit(player.No, attackMultiplier);

                    //Knockback
                    // playerData.ImpactHandler.Execute(attackMultiplier);
                }
            }
        }


        public override void TakeDamage(float damage)
        {
            //Shield reduces attack due to defense rating
            var defendedDamage = damage - player.Shield.Defense;

            player.Shield.HP -= defendedDamage;

			if (player.Shield.HP <= 0)
				Death();
        }


        public override void Death()
        {
            //Detach shield and fall to ground?
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;

            //Let ether know shield has been destroyed
            OnShieldDeath(player.No);

            //Finally disable this object so no more commands will be received
            this.gameObject.SetActive(false);
        }

    }
}



			// //TODO Let system know the Left Arm has been knocked off ie. reduce lance accuracy

			// var RB = GetComponent<Rigidbody>();
            // var C = GetComponent<Collider>();

            // //Detach
            // transform.SetParent(null);
            // RB.isKinematic = false;
            // C.isTrigger = false;

            // //Send flying
            // RB.AddForceAtPosition(collisionDirection * forceMultiplier, collisionContact, forceMode);

            // //Let the system know that the shield had come off via event system
            // //Shield coming off means the player can't block with it anymore...
            // //which it should take care of itself since the shield will be on the ground somewhere
            // // onShieldDeath.Raise();

            // //Disable shield controller
            // playerData.ShieldController.enabled = false;

            // //Disable left arm IK controller
            // playerData.IKShieldHold.enabled = false;

            // //Play sounds etc
            // //Shield breaks, trigger any particle effects, shield texture changes?