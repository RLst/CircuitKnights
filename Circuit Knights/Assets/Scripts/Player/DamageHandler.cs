//DuckBike
//Tony Le
//7 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Variables;
using System;

namespace CircuitKnights
{
	// [RequireComponent(typeof(Rigidbody))]
	public class DamageHandler : MonoBehaviour
	//TODO change to PlayerDamageHandler?
	{

		#region Player
		PlayerData playerData;     //The player this object belongs to
		[SerializeField] Damageable headHealth;
		[SerializeField] Damageable torsoHealth;
		[SerializeField] Damageable leftArmHealth;
		[SerializeField] Damageable rightArmHealth;
		[SerializeField] Damageable shieldHealth;

		#endregion

		////Test
		public float ximpulseMultiplier = 5f;
		public float xdamageMultiplier = 5f;

		public enum ImpactType {
			RelativeVelocity,
			Impulse
		}
        [SerializeField] ImpactType usingImpactType;
        private float relativeVelocityFactor = 1f;
        private float impulseFactor = 1f;

        void Start()
		{
            RegisterForCollisionEvents();
            playerData = GetComponentInChildren<Player>().Data;
        }

        private void RegisterForCollisionEvents()
        {
            HeadHealth.OnCollision += OnHeadCollisionEnter;
            TorsoHealth.OnCollision += OnTorsoCollisionEnter;
            LeftArmHealth.OnCollision += OnLeftArmCollisionEnter;
            RightArmHealth.OnCollision += OnRightArmCollisionEnter;
            ShieldHealth.OnCollision += OnShieldCollisionEnter;
        }

		private void OnHeadCollisionEnter(Collision collision)
		{
			Debug.Log("Collided with head");
		}

		void OnTorsoCollisionEnter(Collision collision)
		{
			Debug.Log("Collided with torso");
		}

		void OnLeftArmCollisionEnter(Collision collision)
		{
			Debug.Log("Collided with left arm");
		}

		void OnRightArmCollisionEnter(Collision collision)
		{
			Debug.Log("Collided with right arm");
		}

		void OnShieldCollisionEnter(Collision collision)
		{
			Debug.Log("Collided with shield");

			////Reduce shield health based on collision

			switch (usingImpactType)
			{
				case ImpactType.RelativeVelocity:
                    shieldHealth.TakeDamage(collision.relativeVelocity.magnitude * relativeVelocityFactor);
                    break;
				case ImpactType.Impulse:
                    shieldHealth.TakeDamage(collision.impulse.magnitude * impulseFactor);
                    break;
				default:
                    shieldHealth.TakeDamage(1f);
                    break;
            }

			// //Simplify and refactor these
			// playerData.Shield.gameObject.transform.parent = null;
			// playerData.Shield.gameObject.GetComponent<PlayerShieldControl>().enabled = false;
			// playerData.Shield.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
		}

		void Update()
		{

		}
	}
}


// new Rigidbody rigidbody;
// new Collider collider;

// public enum BodyPart {
// 	Head,
// 	Torso,
// 	LeftArm,
// 	RightArm,
// 	Shield
// }
// [SerializeField] BodyPart bodyPart;
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


//Set caches
// opponentLanceCollider = player.GetOpponent().LanceCollider;

//Finds a default collider if none assigned
// if (!collider)
// 	this.collider = GetComponent<Collider>();
// if (!collider)
// 	this.collider = GetComponentInChildren<Collider>();

// void OnCollisionEnter(Collision other)
// {
// 	//If player has collided with opponent's lance
// 	if (other.collider == opponentLanceCollider)
// 	{
// 		//Set player body and limbs free: standard rigidbody
// 		// this.rigidbody.isKinematic = false;
// 		// this.collider.isTrigger = false;

// 		//Get the impulse of the impact (measured in N.s)
// 		Debug.Log("Collision Impulse: " + other.impulse);

// 		//Multiply with a damage factor to get the total damage units
// 		var totalDamage = other.impulse.magnitude * damageMultiplier;

// 		//Multiply with a impulse factor to get the force/impact/explosion to be applied to the player body part

// 		//Take damage
// 		// damageable.TakeDamage(totalDamage);

// 		// other.rigidbody.isKinematic = false;
// 	}

// }

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