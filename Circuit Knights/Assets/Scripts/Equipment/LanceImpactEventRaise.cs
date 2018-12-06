//Duckbike
//Tony Le
//15 Nov 2018

using UnityEngine;
using System;
using CircuitKnights.Players;

namespace CircuitKnights
{
    public class LanceImpactEventRaise : MonoBehaviour
	{
		//[TextArea]
		//[SerializeField]
		//string description =
		//	"Attach to actual lance object with the collider. Relays OnCollisionEnter(lance)";
		public static event Action<Player.Number, float> onLanceCollision = delegate { };
		Player player;

		void Start()
		{
			player = GetComponentInParent<Player>();
		}

		void OnCollisionEnter(Collision other)
		{
			//If this object gets hit by the opponents lance
			if (other.collider == player.GetOpponent().LanceCollider)
			{
				onLanceCollision(player.No, player.Horse.Vel.magnitude);
			}
		}
	}

}