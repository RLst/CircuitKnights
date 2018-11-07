//Duckbike
//Tony Le
//6 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    // [RequireComponent(typeof(Player))]
    public class SetPlayerColliders : MonoBehaviour
    {
        [TextArea][Multiline] string description =
            "Sets the colliders inside the Player Scriptable Object";
        [SerializeField] Player player;
        [SerializeField] Collider headCollider;
        [SerializeField] Collider torsoCollider;
        [SerializeField] Collider leftArmCollider;
        [SerializeField] Collider rightArmCollider;
        [SerializeField] Collider shieldCollider;   //This might have to have a separate script
        [SerializeField] Collider lanceCollider;
        
        // public Collider shield;

        ////Might not need these because the colliders have to already be in position
        ////So the designer just drags and drop directly
        // [SerializeField] Transform headColliderMount;
        // [SerializeField] Transform torsoColliderMount;
        // [SerializeField] Transform leftArmColliderMount;
        // [SerializeField] Transform rightArmColliderMount;

		void Awake()
		{
            //Set reference to this player
			// player = GameSettings.Instance.Player

            //Set references to the colliders
            player.HeadCollider = this.headCollider;
            player.TorsoCollider = this.torsoCollider;
            player.RightArmCollider = this.rightArmCollider;
            player.LeftArmCollider = this.leftArmCollider;
            player.ShieldCollider = this.shieldCollider;
            player.LanceCollider = this.lanceCollider;

            
		}
    }

}