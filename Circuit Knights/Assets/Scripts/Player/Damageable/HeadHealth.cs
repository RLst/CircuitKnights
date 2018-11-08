//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    public class HeadHealth : MonoBehaviour, IHealth
    {
		[SerializeField] Player player;

		[SerializeField] GameObject head;
		[SerializeField] Collider headCollider;

        public void TakeDamage(float damage)
        {
            player.HeadHealth -= damage;
			if (player.HeadHealth <= 0)
				Death();
        }

        public void Death()
        {
			//Heads gets knocked off
			head.transform.SetParent(null);

			//Let the system know somehow that the head has been knocked off
				//Use an event?
			
            throw new System.NotImplementedException();
        }
    }
}