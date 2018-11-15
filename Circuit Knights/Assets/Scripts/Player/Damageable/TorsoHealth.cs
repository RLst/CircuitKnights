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
	public class TorsoHealth : Damageable
	{
		///Events
		public static event Action<Collision> OnCollision = delegate { };
        public static event Action<PlayerData.PlayerNumber> OnPlayerLose = delegate { };

        ///Physics
        // new Rigidbody rigidbody;
        //// Test collision data
        Vector3 collisionDirection;
        Vector3 collisionContact;
        float forceMultiplier = 100f;
        ForceMode forceMode = ForceMode.Impulse;
        /////////////////////


        void Start()
		{
            AutoRetrieveReferences();
            AssertReferences();
        }

        public override void AutoRetrieveReferences()
        {
            playerData = GetComponentInParent<Player>().Data;
            opponentData = playerData.GetOpponent();
        }

        public override void AssertReferences()
        {
            Assert.IsNotNull(playerData, "Player data not found!");
            Assert.IsNotNull(opponentData, "Opponent data not found!");
        }

        void OnCollisionEnter(Collision other)
        {
            //Make sure it's the opponent's lance
            if (other.collider == opponentData.LanceCollider)
            {
                Debug.Log("Torso hit!");

                var RB = GetComponent<Rigidbody>();
                var C = GetComponent<Collider>();
                // var oppLanceRB = opponentData.LanceData.gameObject.GetComponentInChildren<Rigidbody>();
				// Assert.IsNotNull(oppLanceRB, "Opponent lance not found!");

				///Take damage
				TakeDamage(opponentData.LanceData.Attack - playerData.ShieldData.Defense);

                ///Make player semi-ragdoll
                //Disable animator and kinematic?
                // playerData.Animator.enabled = false;

                ///Apply force/impulse to player at point of contact
                //Get opponent's lance direction vector
                collisionDirection = other.gameObject.transform.forward.normalized;
                collisionContact = other.contacts[0].point;

                //Detach the shield and make into plain rigidbody
                transform.SetParent(null);
                RB.isKinematic = false;
                C.isTrigger = false;

                //Add force to the shield which should chain reaction up the player
                RB.AddForceAtPosition(collisionDirection * forceMultiplier, collisionContact, forceMode);

                ///Make opponents lance non-kinematic and apply upwards/outwards impulse
                // oppLanceRB.isKinematic = false;
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
            Debug.Log("Torso dead!");

            var RB = GetComponent<Rigidbody>();
            var C = GetComponent<Collider>();

            ///Player gets killed
            //Turn into a ragdoll: turn off kinematic, turn off animator
            playerData.Animator.enabled = false;

            //Let the system know the player has lost
            OnPlayerLose(playerData.No);    //Send this player's number to the ether
		}
    }
}



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