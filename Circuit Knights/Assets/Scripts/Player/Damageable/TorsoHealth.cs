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

		///Physics
		// new Rigidbody rigidbody;

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
            //If hit by opponent's lance then raise/send event
            if (other.collider == opponentData.LanceCollider)
            {
                OnCollision(other);
            }
        }

		public override void TakeDamage(float damage)
		{
			playerData.TorsoHealth -= damage;
            if (playerData.TorsoHealth <= 0)
                Death();
		}

		public override void Death()
		{
			//Player gets killed
			
			//Turn into a ragdoll: turn off kinematic, turn off animator

			//Let the system know the player has lost

			Debug.Log("Torso dead!");
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