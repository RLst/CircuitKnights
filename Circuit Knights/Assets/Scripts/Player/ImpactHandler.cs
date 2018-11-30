//DuckBike
//Tony Le
//29 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using System.Collections;

namespace CircuitKnights.Controllers
{
	public class ImpactHandler : MonoBehaviour
	{
        [SerializeField]
        [TextArea]
        string help =
        	"Place this on each player's root object. Handles anything to do with being struck by the lance"
			+ "ie. animation, slowmotion, vibration, audio, particles...";

        PlayerData playerData;


		[Header("Animation")]
		[SerializeField] Transform leftHandBone;
		[SerializeField] Transform rightHandBone;
		Animator anim;


        // [SerializeField] 
		SlowMotionController slowMotionController;
		[Header("Slow Motion")]
        [Tooltip("Impacts below this strength will not trigger slow mo")][SerializeField] float impactSlowMoDeadzone = 0.2f;
        [Tooltip("Heavy impacts can slow time down to this speed")][SerializeField] float minSlowMoSpeed = 0.05f;		
		[Tooltip("Heavy impacts can last up to this duration")][SerializeField] float maxSlowMoDuration = 4f;


        // [SerializeField]
        VibrationController vibrationController;
		[Header("Vibration")]
        [Tooltip("Impacts below this strength will not trigger any vibration")] [SerializeField] float impactVibrationDeadzone = 0f;
        [Tooltip("Heavy impacts can vibrate up to this speed")] [SerializeField] float maxVibrationSpeed = 1f;
        [Tooltip("Heavy impacts can last up to this duration")] [SerializeField] float maxVibrationDuration = 2f;


        [Header("Audio")]
        [SerializeField] AudioSource audioSource;
		[SerializeField] AudioClip[] cheerSounds;
		[SerializeField] AudioClip[] lanceCollisionSounds;
		


        [Header("Particles")]
        [SerializeField] new ParticleSystem particleSystem;
        [SerializeField] GameObject particleFX;
        [SerializeField] Transform particlePoint;



        void Awake()
		{
			playerData = GetComponent<Player>().Data;
			anim = playerData.Animator;
            slowMotionController = SlowMotionController.Instance;
            vibrationController = VibrationController.Instance;
        }

		public IEnumerator Execute(float impact)
		{
			////1. Knocked back
			//Disable IK controllers
			playerData.IKShieldHold.enabled = false;
			playerData.IKLanceHolder.enabled = false;
			playerData.IKLook.enabled = false;

			//Parent shield and lance to arms
			var origLeftHand = playerData.ShieldData.gameObject.transform.parent;
			var origRightHand = playerData.LanceData.gameObject.transform.parent;
			playerData.ShieldData.gameObject.transform.SetParent(leftHandBone);
			playerData.LanceData.gameObject.transform.SetParent(rightHandBone);



            ////2. Display the result in game in real-time
            //Animation
            yield return StartCoroutine(AnimateKnockBack());

            //Slow motion
            var slowMoSpeed = Map(impact, impactSlowMoDeadzone, 1f, minSlowMoSpeed, 1f);
            var slowMoDuration = Map(impact, impactSlowMoDeadzone, 1f, 0f, maxSlowMoDuration);
            slowMotionController.SlowMotionOn(slowMoSpeed, slowMoDuration);

            //Vibration
            var vibrateSpeed = Map(impact, impactVibrationDeadzone, 1f, 0f, maxVibrationSpeed);
            var vibrateDuration = Map(impact, impactVibrationDeadzone, 1f, 0f, maxSlowMoDuration);
            vibrationController.VibrateOn(playerData.No, vibrateSpeed, 0f, vibrateDuration);

			//Audio

			//Particles
			

			////3. Recovery
			//Re-enable IK controllers
			playerData.IKShieldHold.enabled = false;
			playerData.IKLanceHolder.enabled = false;
			playerData.IKLook.enabled = false;

			//Reset shield and lance to arms
			playerData.ShieldData.gameObject.transform.SetParent(origLeftHand);
			playerData.LanceData.gameObject.transform.SetParent(origRightHand);
		}

		private IEnumerator AnimateKnockBack()
		{
			Debug.Log("Handling knockback animation");

			//Use parabolic formula: -(2x-1)^2 + 1
			for (float i = 0f; i < 1; i += 0.1f)
			{
				anim.SetFloat("KnockbackAxis", i);
				yield return null;
			}
		}

		float Map(float value, float valueMin, float valueMax, float mappedMin, float mappedMax)
		{
            return ((value - valueMin) / (valueMax - valueMin)) * (mappedMax - mappedMin) + mappedMin;
        }
	}

}