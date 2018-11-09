//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights
{
    public class LeftArmHealth : Damageable
    {
        public static event Action<Collision> OnCollision = delegate { };
		[SerializeField] Player player;
        private Collider opponentsLance;

        void Start()
        {
            opponentsLance = player.GetOpponent().LanceCollider;
        }

        void OnCollisionEnter(Collision other)
        {
            //If hit by opponent's lance then raise/send event
            if (other.collider == opponentsLance)
            {
                OnCollision(other);
            }
        }

        public override void TakeDamage(float damage)
        {
            player.LeftArmHealth -= damage;
			if (player.LeftArmHealth <= 0)
				Death();
        }

        public override void Death()
        {
			//Heads gets knocked off
			transform.SetParent(null);

			//Let the system know somehow that the head has been knocked off
				//Use an event?
        }

    }
}