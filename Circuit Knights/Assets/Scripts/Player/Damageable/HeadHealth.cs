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
        [SerializeField] GameObject knockedOffPrefab;   //The limb that falls off
		[SerializeField] Transform knockedOffInstatiatePoint;
		// [Tooltip("The mesh that will be hidden upon impact")] [SerializeField] GameObject headMesh;   //The mesh of the head that needs to disappear
		[Tooltip("Used to fine tune the damage")] [SerializeField] float damageFactor = 1f;


		// public GameObject dataObject;    //jack's code

        void OnCollisionEnter(Collision other)
        {
            //If hit by opponent's lance then raise/send event
            //Debug.Log("Collider hitting head = " + other.gameObject.name);
            if (other.collider == opponentData.LanceCollider)
            {
                TakeDamage(opponentData.LanceData.Attack);
            }
        }

        public override void TakeDamage(float damage)
        {
			//Take damage based on velocity of horse/lance
			//TODO var finalDamage = playerData.PlayerMover.Velocity * damageFactor * damage;
			playerData.HeadHP -= damage;    //TODO make damage => finalDamage

			//Play knockback animation
			//playerData.Animator.SetTrigger("Knockback");

			if (playerData.HeadHP <= 0)
				Death();
        }

        public override void Death()
        {
			///Heads gets knocked off
			//Hide the head
			// headMesh.SetActive(false);
			gameObject.SetActive(false);

            //Spawn in new head to simulate getting knocked off
            var newKnockedOff = Instantiate(knockedOffPrefab, knockedOffInstatiatePoint.position, knockedOffInstatiatePoint.rotation);
            //var newKnockedOff = Instantiate(knockedOffPrefab, transform.localPosition, transform.localRotation);


            //TODO let the system know that the player's head has fallen off

        }


		#region Inits
		void Start()
		{
			AutoRetrieveReferences();
			AssertReferences();
			// playerData.HeadHP = 10;
		}
		public override void AutoRetrieveReferences()
		{
			playerData = GetComponentInParent<Player>().Data;
			opponentData = playerData.GetOpponent();
			// playerData = dataObject.GetComponent<Player>().Data;
		}

		public override void AssertReferences()
		{
			Assert.IsNotNull(playerData, "Player data not found!");
			Assert.IsNotNull(opponentData, "Opponent data not found!");
		}
        #endregion
    }
}






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