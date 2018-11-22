//DuckBike
//Tony Le, Jack Dawes
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;
using CircuitKnights.Events;

namespace CircuitKnights
{
    [SerializeField]
    public class ShieldHealth : Damageable
    {
        // public static event Action<PlayerData.PlayerNumber> onShieldDeath = delegate { };   //Pass shield death with player
        private ShieldData shieldData;
		[SerializeField] GameObject knockedOffPrefab;   //The limb that falls off
		[SerializeField] Transform knockedOffSpawnPoint;
		// [Tooltip("The mesh that will be hidden upon impact")] [SerializeField] GameObject shieldMesh;   //The mesh of the head that needs to disappear
		[Tooltip("Used to fine tune the damage")] [SerializeField] float damageFactor = 1f;


		//// Test collision data
		Vector3 collisionDirection;
        Vector3 collisionContact;
        float forceMultiplier = 0f;
        ForceMode forceMode = ForceMode.Force;
        /////////////////////


        void OnCollisionEnter(Collision other)
        {
            //If hit by opponent's lance then raise/send event
            if (other.collider == opponentData.LanceCollider)
            {
                // var RB = GetComponent<Rigidbody>();
                // var C = GetComponent<Collider>();
                // var oppRB = opponentData.LanceData.gameObject.GetComponentInChildren<Rigidbody>();

                ///Take damage
                TakeDamage(opponentData.LanceData.Attack - playerData.ShieldData.Defense);

                // ///Make player semi-ragdoll
                // //Disable animator and kinematic?
                // playerData.Animator.enabled = false;

                // ///Apply force/impulse to player at point of contact
                // //Get opponent's lance direction vector
                // collisionDirection = other.gameObject.transform.forward.normalized;
                // collisionContact = other.contacts[0].point;

                // //Detach the shield and make into plain rigidbody
                // transform.SetParent(null);
                // RB.isKinematic = false;
                // C.isTrigger = false;

                // //Add force to the shield which should chain reaction up the player
                // RB.AddForceAtPosition(collisionDirection * forceMultiplier, collisionContact, forceMode);

                // ///Release opponent's lance
                // oppRB.isKinematic = false;
                // other.transform.SetParent(null);
                // opponentData.IKLanceHolder.enabled = false;
            }
        }

        public override void TakeDamage(float damage)
        {
            playerData.ShieldData.HP -= damage;
			if (playerData.ShieldData.HP <= 0)
				Death();
        }

        public override void Death()
        {
			//Object gets knocked off
			//Hide the object
			// shieldMesh.SetActive(false);
			gameObject.SetActive(false);

			//Spawn in new limb to simulate getting knocked off
			var newKnockedoff = Instantiate(knockedOffPrefab, knockedOffSpawnPoint.position, knockedOffSpawnPoint.rotation);

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
			opponentData = playerData.GetOpponent();
		}

		public override void AssertReferences()
		{
			Assert.IsNotNull(playerData, "Player data not found!");
			Assert.IsNotNull(opponentData, "Opponent data not found!");
		}
        #endregion
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