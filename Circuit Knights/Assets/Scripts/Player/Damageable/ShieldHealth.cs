//DuckBike
//Tony Le, Jack Dawes
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public class ShieldHealth : Damageable
    {
        public static event Action<Collision> OnCollision = delegate { };

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
            playerData.ShieldHealth -= damage;
			if (playerData.ShieldHealth <= 0)
				Death();
        }

        public override void Death()
        {
			//shield breaks
            
            //trigger any particle effects
            
            //hide or delete game object or detach
			transform.SetParent(null);

			//Let the system know that the shield had come off via event system
        }

    }
}