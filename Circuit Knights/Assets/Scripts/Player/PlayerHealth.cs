//Duckbike
//Tony Le
//29 Oct 2018

using CircuitKnights.Objects;
using UnityEngine;

namespace CircuitKnights
{
    public class PlayerHealth : MonoBehaviour   
        //todo rename to takedamage or healthController
    {
        [TextArea][SerializeField] string description =
            "Attach to player root object. Handles damage";
		[SerializeField] Player player;
        [SerializeField] Player opponent;

        void Awake()
        {
            //Cache all colliders
            
            //Auto set the opponent based on the input player
            // if (player.Number == PlayerNumber.)
            // {
            //     stardew
            // }
            // var opponentIndex =

            opponent = player.GetOpponent();
        }

        // void OnTriggerEnter(Collider other)
        // {
        //     //Check if collided with opponent


        //     //..if hit shield
        //     if (other == opponent.)
        //     {
        //         //Turn them both into Rigidbodies to run natural physics 
        //         //and get collision physics
        //         opponent.ShieldCollider.isTrigger = false;

        //         // opponent.
        //         // opponent.ShieldHealth -= damage
        //     }

        //     //..if hit head

        //     //..if hit torso

        //     //..if hit left arm

        //     //..if hit right arm

        // }

        public void TakeDamage(float damage)
        {
            
        }

        public void Kill()
        {
			
        }
    }

}