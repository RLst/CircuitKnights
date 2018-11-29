//DuckBike
//Tony Le
//29 Nov 2018

using CircuitKnights.Cameras;
using CircuitKnights.Objects;
using UnityEngine;
// using CircuitKnights.Objects;

namespace CircuitKnights
{
    public class HeadDeathCamera : MonoBehaviour
    {
		// PlayerCamera playerCamera;
		// Player player;

		void Awake()
		{
			// player = GetComponent<Player>();

			// playerCamera = GetComponent<PlayerCamera>();
			HeadHealth.OnHeadDeath += SetHeadDeathCam;
		}

		void SetHeadDeathCam(PlayerData.PlayerNumber playerNo)
		{
			// if (playerNo)
			// player.Data.Camera.DesiredPosition = 
		}
    }

}