//DuckBike
//Tony Le
//23 Nov 2018

using System;
using System.Collections;
using CircuitKnights.Objects;
using CircuitKnights.Variables;
using UnityEngine;
using UnityEngine.Assertions;
using XInputDotNetPure;

namespace CircuitKnights.Controllers
{
    public class VibrationController : MonoBehaviour
    {
        #region Singleton
        public static VibrationController Instance { get; private set; }
        private void Awake()
        {
            //Setup singleton
            if (!Instance) Destroy(gameObject);
            Instance = this;
        }
        #endregion

        [SerializeField] BoolVariable isVibrationOn;
        [SerializeField] float defaultVibrationSpeed = 0.5f;
        [SerializeField] float defaultVibrationDuration = 1f;


        private void Start() {
            Assert.IsNotNull(isVibrationOn, "Vibration controller requires isVibrationOn boolean variable object.");
        }

        public void VibrateOn()
        //Vibrate all controllers, both motors, default speed and duration
        {
            if (isVibrationOn.Value == true)
            {
                StartCoroutine(RampDownVibration((PlayerData.PlayerNumber)1, defaultVibrationSpeed, defaultVibrationSpeed, defaultVibrationDuration));
                StartCoroutine(RampDownVibration((PlayerData.PlayerNumber)2, defaultVibrationSpeed, defaultVibrationSpeed, defaultVibrationDuration));
            }
        }

        public void VibrateOn(PlayerData.PlayerNumber player)
        //Default vibration on one controller, both motors, default speed and duration
        {
            if (isVibrationOn.Value == true)
            {
                StartCoroutine(RampDownVibration(player, defaultVibrationSpeed, defaultVibrationSpeed, defaultVibrationDuration));
            }
        }

        public void VibrateOn(PlayerData.PlayerNumber player, float heavyVibrateSpeed, float lightVibrateSpeed)
        //Vibration on one controller forever
        {
            if (isVibrationOn.Value == true)
            {
                GamePad.SetVibration((PlayerIndex)player, heavyVibrateSpeed, lightVibrateSpeed);
            }
        }

        public void VibrateOn(PlayerData.PlayerNumber player, float heavyVibrateSpeed, float lightVibrateSpeed, float rampDownDuration)
        //Vibration on one controller ramping down for a set amount of duration
        {
            if (isVibrationOn.Value == true)
            {
                StartCoroutine(RampDownVibration(player, heavyVibrateSpeed, lightVibrateSpeed, rampDownDuration));
            }
        }

        public void VibrateOff(PlayerData.PlayerNumber player)
        //Shuts down vibration on one controller
        {
            if (isVibrationOn.Value == true)
            {
                GamePad.SetVibration((PlayerIndex)(int)player, 0f, 1f);
            }
        }


        IEnumerator RampDownVibration(PlayerData.PlayerNumber player, float heavyVibrateSpeed, float lightVibrateSpeed, float defaultVibrationDuration)
        {
            float i = 1f;
            while (i > 0f)
            {
                i -= 1f / defaultVibrationDuration * Time.unscaledDeltaTime;

                //Calculate the current vibrate speeds
                var setHeavyVibrateSpeed = Map(i, 0f, 1f, 0f, heavyVibrateSpeed);
                var setLightVibrateSpeed = Map(i, 0f, 1f, 0f, lightVibrateSpeed);

                //Set the vibration speeds
                GamePad.SetVibration((PlayerIndex)(int)player, setLightVibrateSpeed, setLightVibrateSpeed);

                yield return null;
            }
            //Make sure to fully turn the motors off
            GamePad.SetVibration((PlayerIndex)(int)player, 0f, 0f);
        }


        float Map(float value, float valueMin, float valueMax, float mappedMin, float mappedMax)
        {
            return ((value - valueMin) / (valueMax - valueMin)) * (mappedMax - mappedMin) + mappedMin;
        }
    }

}