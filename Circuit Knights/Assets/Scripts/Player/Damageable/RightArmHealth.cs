//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights
{
    public class RightArmHealth : Damageable
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
            player.RightArmHealth -= damage;
			if (player.RightArmHealth <= 0)
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
