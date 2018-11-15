//Duckbike
//Tony Le
//15 Nov 2018

using UnityEngine;
using CircuitKnights.Events;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights
{
	public class LanceImpactEventRaise : MonoBehaviour
	{
		public static event Action<PlayerData.PlayerNumber> onLanceCollision = delegate { };
		[SerializeField] GameEvent OnLanceImpact;
		PlayerData playerData;

		void Start()
		{
			playerData = GetComponentInParent<Player>().Data;
		}

		void OnCollisionEnter(Collision other)
		{
			if (other.collider == playerData.TorsoCollider)
			{
				OnLanceImpact.Raise();
			}
		}
	}

}