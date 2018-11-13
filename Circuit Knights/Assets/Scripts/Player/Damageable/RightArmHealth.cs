//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public class RightArmHealth : Damageable
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
            opponentData = GetComponentInParent<Player>().Data.GetOpponent();
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
            playerData.RightArmHP -= damage;
			if (playerData.RightArmHP <= 0)
				Death();
        }

        public override void Death()
        {
			//Right Arm gets knocked off
			transform.SetParent(null);
            
            //let system know that Right Arm has fallen off via event
            

        }

    }
}
