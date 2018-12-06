using UnityEngine;
using CircuitKnights.Controllers;
using CircuitKnights.Players;

namespace CircuitKnights
{
    public class VibrationListener : MonoBehaviour
	{
		//listens to damageable on hit events and vibrates accordingly

		void Awake()
		{
			HeadHealth.OnHeadHit += DoVibrate;
			TorsoHealth.OnTorsoHit += DoVibrate;
			LeftArmHealth.OnLeftArmHit += DoVibrate;
			RightArmHealth.OnRightArmHit += DoVibrate;
			ShieldHealth.OnShieldHit += DoVibrate;
		}

		void DoVibrate(Player.Number playerNo, float impact)
		{
			VibrationController.Instance.VibrateOn(playerNo, impact, 0f);
		}

	}
}