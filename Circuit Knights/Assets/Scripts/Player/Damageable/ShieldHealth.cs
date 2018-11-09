//DuckBike
//Tony Le, Jack Dawes
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights
{
    public class ShieldHealth : Damageable
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
            player.ShieldHealth -= damage;
			if (player.ShieldHealth <= 0)
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