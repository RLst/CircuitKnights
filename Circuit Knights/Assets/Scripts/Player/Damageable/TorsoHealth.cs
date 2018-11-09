//DuckBike
//Tony Le, Jack Dawes
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Variables;
using System;

namespace CircuitKnights
{
	public class TorsoHealth : Damageable
	{
		public static event Action<Collision> OnCollision = delegate { };
		new Rigidbody rigidbody;

        [SerializeField] Player player;
        // [SerializeField] GameObject torso;
        // [SerializeField] Collider torsoCollider;
		Collider oppLance;
        [SerializeField] FloatReference health;

		void Awake()
		{
            //Reset the health
            health.Value = player.TorsoHealth;
			rigidbody = GetComponent<Rigidbody>();

			oppLance = player.GetOpponent().LanceCollider;
		}

		public override void TakeDamage(float damage)
		{
			health.Value -= damage;
            if (health.Value <= 0)
                Death();
		}

		public override void Death()
		{
			Debug.Log("Torso dead!");
		}

	}

}







		// void OnCollisionEnter(Collision other)
		// {
		// 	//If hit by opponent's lance
		// 	if (other.collider == oppLance)
		// 	{
		// 		//Take damage
		// 		TakeDamage(10);

		// 		//Make loose
		// 		GetComponent<Rigidbody>().isKinematic = false;

		// 		Debug.Log("Collided");

		// 		////Temporary
		// 		//Ragdoll player and detach
		// 		// player.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
		// 		player.gameObject.GetComponentInChildren<Animator>().enabled = false;	//Turns of the animator so that it can ragdoll

		// 		var limbs = player.gameObject.GetComponentsInChildren<Rigidbody>();		//Makes everything free
		// 		foreach (var limb in limbs)
		// 		{
		// 			limb.isKinematic = false;
		// 		}
		// 		player.gameObject.transform.parent = null;

		// 		//Make Lance a RB and detach
		// 		player.lance.gameObject.transform.parent = null;
		// 		player.lance.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;

		// 		//Make Shield a RB and detach
		// 		player.shield.gameObject.transform.parent = null;
		// 		player.shield.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
		// 	}
		// }