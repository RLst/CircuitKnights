//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public class HeadHealth : Damageable
    {
        public static event Action<Collision> OnCollision = delegate { };
        public GameObject knockedOffPrefab;
        public GameObject dataObject;
        void Start()
        {
            AutoRetrieveReferences();
            AssertReferences();
            playerData.HeadHP = 10;
        }

        public override void AutoRetrieveReferences()
        {
            playerData = dataObject.GetComponent<Player>().Data;
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
            //Debug.Log("Collider hitting head = " + other.gameObject.name);
            if (other.collider == opponentData.LanceCollider)
            {
                TakeDamage(opponentData.LanceData.Attack);
            }
        }

        public override void TakeDamage(float damage)
        {
            playerData.HeadHP -= damage;
			if (playerData.HeadHP <= 0)
				Death();
        }

        public override void Death()
        {
			//Heads gets knocked off
			transform.SetParent(null);

            var newKnockedOff = Instantiate(knockedOffPrefab, transform.position, transform.rotation);
            this.gameObject.SetActive(false);

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
        }

    }
}