//Duckbike
//Tony Le
//15 Nov 2018

using UnityEngine;
using CircuitKnights.Events;
using CircuitKnights.Objects;

namespace CircuitKnights
{
	public class SloMoOnImpact : MonoBehaviour {

		[SerializeField] GameEvent OnLanceImpact;
		PlayerData playerData;

		void Start()
		{
			playerData = GetComponentInParent<Player> ().Data;
		}

		void OnCollisionEnter(Collision other)
		{
			if (other.collider == playerData.TorsoCollider) {
				OnLanceImpact.Raise ();
			}
		}
	}

}