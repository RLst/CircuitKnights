//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public class LeftArmHealth : Damageable
    {
        public static event Action<Collision> OnCollision = delegate { };
		// [SerializeField] PlayerData player;
        // private Collider opponentsLance;

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
            playerData.LeftArmHealth -= damage;
			if (playerData.LeftArmHealth <= 0)
				Death();
        }

        public override void Death()
        {
			//Left Arm gets knocked off
			transform.SetParent(null);

            //Let system know the Left Arm has been knocked off
            
        }

    }
}