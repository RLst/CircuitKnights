//DuckBike
//Tony Le
//29 Nov 2018

using CircuitKnights.Players;
using UnityEngine;

namespace CircuitKnights
{
    public class HeadDeathCamera : MonoBehaviour
    {
		// PlayerCamera playerCamera;
		Player player;

		void Awake()
		{
			player = GetComponent<Player>();

			HeadHealth.OnHeadDeath += SetHeadDeathCam;
		}

		void SetHeadDeathCam(Player.Number playerNo, GameObject knockedOffHead)
		{
			//Check that this is the decapitated player
			if (playerNo == player.No)
			{
				//TODO
				
                // player.Camera.DesiredPosition = knockedOffHead.transform;		//Move camera to a 
                // player.Camera.LookAt = player.gameObject.transform;		//Look at the Player's root

            }
		}
    }

}