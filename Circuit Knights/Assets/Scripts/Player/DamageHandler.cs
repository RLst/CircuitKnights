//DuckBike
//Tony Le
//7 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Variables;

namespace CircuitKnights
{
	// [RequireComponent(typeof(Rigidbody))]
    public class DamageHandler : MonoBehaviour
		//TODO change to PlayerDamageHandler?
    {
        ////Place this on damageable 

	#region Player
		[SerializeField] Player player;		//The player this object belongs to

		[SerializeField] FloatVariable hitpoints;

		[SerializeField] IHealth damageable;
		new Rigidbody rigidbody;
		new Collider collider;

		public enum BodyPart {
			Head,
			Torso,
			LeftArm,
			RightArm,
			Shield
		}

		[SerializeField] BodyPart bodyPart;

		// [SerializeField] Collider headC;
		// Rigidbody headRB;
		// [SerializeField] Collider torsoC;
		// Rigidbody torsoRB;
		// [SerializeField] Collider leftArmC;
		// Rigidbody leftArmRB;
		// [SerializeField] Collider rightArmC;
		// Rigidbody rightArmRB;
		// [SerializeField] Collider shieldC;
		// Rigidbody shieldRB;
	#endregion

	#region Opponent
		[SerializeField] Collider opponentLanceCollider;
	#endregion

		////Test
		public float impulseMultiplier = 5f;
		public float damageMultiplier = 5f;

		void Start()
		{
			//Set caches
			opponentLanceCollider = player.GetOpponent().LanceCollider;

			//Finds a default collider if none assigned
			if (!collider)
				this.collider = GetComponent<Collider>();
			if (!collider)
				this.collider = GetComponentInChildren<Collider>();
		}

		void OnCollisionEnter(Collision other)
		{
			//If player has collided with opponent's lance
			if (other.collider == opponentLanceCollider)
			{
				//Set player body and limbs free: standard rigidbody
				this.rigidbody.isKinematic = false;
				this.collider.isTrigger = false;
				
				//Get the impulse of the impact (measured in N.s)
				Debug.Log("Collision Impulse: " + other.impulse);

				//Multiply with a damage factor to get the total damage units
				var totalDamage = other.impulse.magnitude * damageMultiplier;

				//Multiply with a impulse factor to get the force/impact/explosion to be applied to the player body part
				
				//Take damage
				damageable.TakeDamage(totalDamage);

				// other.rigidbody.isKinematic = false;
			}

		}

		// void OnTriggerEnter(Collider other) {
		// 	//Detect if opponent's lance has made contact
		// 	// Collider oppLance = player.GetOpponent().LanceCollider;
		// 	if (other == opponentLanceCollider)
		// 	{
		// 		var oppNo = player.GetOpponent().No;
		// 		Debug.Log("Player " + player.No + "has been hit by Player's " + oppNo + " Lance");
		// 	}	
		// }

        // public void TakeDamage(float damage)
        // {
        //     throw new System.NotImplementedException();
        // }
        // public void Death()
        // {
        //     throw new System.NotImplementedException();
        // }

    }
}