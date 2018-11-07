//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;

namespace CircuitKnights.Objects
{
    public class SetPlayer : MonoBehaviour
    {
        //// Sets references for player's lance, shield, horse so that the can be retrieved from the player's SO
		[SerializeField] Player player;
		[SerializeField] Lance lance;
		[SerializeField] Shield shield;
		[SerializeField] Horse horse;
		[SerializeField] PlayerMover playerMover;

		void Awake()
		{
			player.lance = this.lance;
			player.shield = this.shield;
			player.horse = this.horse;
			player.playerMover = this.playerMover;
		}
    }

}