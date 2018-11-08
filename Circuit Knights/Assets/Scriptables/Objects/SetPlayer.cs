//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;

namespace CircuitKnights.Objects
{
    public class SetPlayer : MonoBehaviour
    {
        //// Sets references for player's lance, shield, horse so that the can be retrieved from the player's SO
        [TextArea][Multiline] string description =
            "Sets all critical references inside the instance of Player.";
		[SerializeField] Player player;
		[SerializeField] Transform root;
		
	#region Equipment
		[SerializeField] Lance lance;
		[SerializeField] Shield shield;
		[SerializeField] Horse horse;
		[SerializeField] PlayerMover playerMover;
		[SerializeField] new Camera camera;
	#endregion

	#region Colliders
		[SerializeField] Collider headCollider;
        [SerializeField] Collider torsoCollider;
        [SerializeField] Collider leftArmCollider;
        [SerializeField] Collider rightArmCollider;
        [SerializeField] Collider shieldCollider;   //This might have to have a separate script
        [SerializeField] Collider lanceCollider;
	#endregion

		void Awake()
		{
			player.root = this.root;
			player.lance = this.lance;
			player.shield = this.shield;
			player.horse = this.horse;
			player.playerMover = this.playerMover;
			player.camera = this.camera;

			player.HeadCollider = this.headCollider;
            player.TorsoCollider = this.torsoCollider;
            player.RightArmCollider = this.rightArmCollider;
            player.LeftArmCollider = this.leftArmCollider;
            player.ShieldCollider = this.shieldCollider;
            player.LanceCollider = this.lanceCollider;
		}
    }
}