//DuckBike
//Tony Le
//30 Nov 2019

using UnityEngine;
using CircuitKnights.Controllers;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    public class HorseVibration : MonoBehaviour
    {
        VibrationController vibrationController;
        Horse horse;
        Player player;

        [SerializeField] float minVibration = 0f;
        [SerializeField] float maxVibration = 1f;



        private void Awake() {
            vibrationController = VibrationController.Instance;
            horse = GetComponent<Horse>();
            player = GetComponent<Player>();
        }

        private void Update() {
            //Constantly poll the horse's speed and set vibration accordingly
            var horseMotorVibration = Map(horse.Vel.magnitude, horse.MinSpeed, horse.MaxSpeed, minVibration, maxVibration);
            vibrationController.VibrateOn(player.Data.No, 0f, horseMotorVibration);
        }


        float Map(float value, float valueMin, float valueMax, float mappedMin, float mappedMax)
        {
            return ((value - valueMin) / (valueMax - valueMin)) * (mappedMax - mappedMin) + mappedMin;
        }
    }
}