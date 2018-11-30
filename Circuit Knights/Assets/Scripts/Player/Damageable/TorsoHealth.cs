//DuckBike
//Tony Le, Jack Dawes
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Variables;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
	[RequireComponent(typeof(Collider))]
	public class TorsoHealth : Damageable
	{
        //Torso doesn't break apart upon death
        //Player loses upon death

        ////Events
        //Death event broadcast; Broadcast an event upon death of this limb to whomever wants to tune in
        public static event Action<PlayerData.PlayerNumber, float> OnTorsoHit = delegate { };
        public static event Action<PlayerData.PlayerNumber> OnTorsoDeath = delegate { };  //Params: PlayerNo


		void Awake()
		{
			//Register for invincibility
            Damageable.OnFirstHit += SetIFrames;
        }
        void Start()
        {
            playerData = GetComponentInParent<Player>().Data;
            opponentData = playerData.GetOpponent();
            Assert.IsNotNull(playerData, "Player data not found!");
            Assert.IsNotNull(opponentData, "Opponent data not found!");
        }


        void OnCollisionEnter(Collision other)
        {
            if (other.collider == opponentData.LanceCollider)	//Must have collided with the opponent's lance
            {
				if (!isInvincible)	//if first limb to be hit
				{
                    //Calculate impact; impact is the amount of damage based on the speed of the horse and lance attack rating
                    float attackMultiplier;
                    var attack = opponentData.LanceData.Attack;
                    var impact = CalculateImpact(attack, out attackMultiplier);

                    //This damageable is first hit; set the rest to temp invincibility
                    SetIFrames(playerData.No);

                    //Limb takes damage
                    TakeDamage(impact);

                    //Let ether know
                    OnTorsoHit(playerData.No, attackMultiplier);

                    //Knockback
                    // playerData.ImpactHandler.Execute(attackMultiplier);
				}
            }
        }


		public override void TakeDamage(float damage)
		{
			playerData.TorsoHP -= damage;

            if (playerData.TorsoHP <= 0)
                Death();
		}


		public override void Death()
		{
            ////Kill player

			//Ragdoll by turning off the player's animator
            playerData.Animator.enabled = false;

            //Let the ether know this player has lost
            OnTorsoDeath(playerData.No);
                //TODO Camera locks onto this player
                //TODO Slow motion etc

            //Finally disable this object so no more commands will be received
            this.gameObject.SetActive(false);
        }



	}
}











// Debug.Log("Torso hit!");

// var RB = GetComponent<Rigidbody>();
// var C = GetComponent<Collider>();
// var oppLanceRB = opponentData.LanceData.gameObject.GetComponentInChildren<Rigidbody>();
// Assert.IsNotNull(oppLanceRB, "Opponent lance not found!");

///Make player semi-ragdoll
//Disable animator and kinematic?
// playerData.Animator.enabled = false;

///Apply force/impulse to player at point of contact
//Get opponent's lance direction vector
// collisionDirection = other.gameObject.transform.forward.normalized;
// collisionContact = other.contacts[0].point;

// //Detach the shield and make into plain rigidbody
// transform.SetParent(null);
// RB.isKinematic = false;
// C.isTrigger = false;

// //Add force to the shield which should chain reaction up the player
// RB.AddForceAtPosition(collisionDirection * forceMultiplier, collisionContact, forceMode);

// ///Make opponents lance non-kinematic and apply upwards/outwards impulse
// // oppLanceRB.isKinematic = false;

// void OnCollisionEnter(Collision other)
// {
// 	//If hit by opponent's lance
// 	if (other.collider == oppLance)
// 	{
// 		//Take damage
// 		TakeDamage(10);

// 		//Make loose
// 		GetComponent<Rigidbody>().isKinematic = false;

// 		Debug.Log("Collided");

// 		////Temporary
// 		//Ragdoll player and detach
// 		// player.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
// 		player.gameObject.GetComponentInChildren<Animator>().enabled = false;	//Turns of the animator so that it can ragdoll

// 		var limbs = player.gameObject.GetComponentsInChildren<Rigidbody>();		//Makes everything free
// 		foreach (var limb in limbs)
// 		{
// 			limb.isKinematic = false;
// 		}
// 		player.gameObject.transform.parent = null;

// 		//Make Lance a RB and detach
// 		player.lance.gameObject.transform.parent = null;
// 		player.lance.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;

// 		//Make Shield a RB and detach
// 		player.shield.gameObject.transform.parent = null;
// 		player.shield.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
// 	}
// }