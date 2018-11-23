//Duckbike
//Tony Le
//15 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights
{
	public class LanceImpactEventRaise : MonoBehaviour
	{
		[TextArea]
		[SerializeField]
		string description =
			"Attach to actual lance object with the collider. Relays OnCollisionEnter(lance)";
		public static event Action<PlayerData.PlayerNumber, float> onLanceCollision = delegate { };
		PlayerData playerData;

		void Start()
		{
			playerData = GetComponentInParent<Player>().Data;
		}

		void OnCollisionEnter(Collision other)
		{
			//If this object gets hit by the opponents lance
			if (other.collider == playerData.GetOpponent().LanceCollider)
			{
				onLanceCollision(playerData.No, playerData.PlayerMover.Vel.magnitude);
			}
		}
	}

}