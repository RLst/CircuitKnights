//DuckBike
//Tony Le
//29 Nov 2018

using CircuitKnights.Cameras;
using CircuitKnights.Objects;
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

		void SetHeadDeathCam(PlayerData.PlayerNumber playerNo, GameObject knockedOffHead)
		{
			//Check that this is the decapitated player
			if (playerNo == player.Data.No)
			{
                player.Data.Camera.DesiredPosition = knockedOffHead.transform;		//Move camera to a 
                player.Data.Camera.LookAt = player.Data.gameObject.transform;		//Look at the Player's root

            }
		}
    }

}