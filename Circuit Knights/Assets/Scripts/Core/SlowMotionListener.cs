using UnityEngine;
using CircuitKnights.Controllers;
using CircuitKnights.Objects;

namespace CircuitKnights
{
	public class SlowMotionListener : MonoBehaviour
	{
		//listens to damageable on hit events and vibrates accordingly
        [Tooltip("Impacts below this strength will not trigger slow mo")][SerializeField] float impactSlowMoDeadzone = 0.2f;
        [Tooltip("Heavy impacts can slow time down to this speed")][SerializeField] float minSlowMoSpeed = 0.05f;		
		[Tooltip("Heavy impacts can last up to this duration")][SerializeField] float maxSlowMoDuration = 4f;
		
		void Awake()
		{
			HeadHealth.OnHeadHit += DoSlowMo;
			TorsoHealth.OnTorsoHit += DoSlowMo;
			LeftArmHealth.OnLeftArmHit += DoSlowMo;
			RightArmHealth.OnRightArmHit += DoSlowMo;
			ShieldHealth.OnShieldHit += DoSlowMo;
		}

		void DoSlowMo(PlayerData.PlayerNumber playerNo, float impact)
		{
            var slowMoSpeed = Map(impact, impactSlowMoDeadzone, 1f, minSlowMoSpeed, 1f);
            var slowMoDuration = Map(impact, impactSlowMoDeadzone, 1f, 0f, maxSlowMoDuration);
            SlowMotionController.Instance.SlowMotionOn(slowMoSpeed, slowMoDuration);
		}

		float Map(float value, float valueMin, float valueMax, float mappedMin, float mappedMax)
		{
            return ((value - valueMin) / (valueMax - valueMin)) * (mappedMax - mappedMin) + mappedMin;
        }
	}
}