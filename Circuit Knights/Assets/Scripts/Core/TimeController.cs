//Duckbike
//Tony Le
//18th of October, 2018

using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Variables;

namespace CircuitKnights
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] float slowdownFactor = 0.15f;
        [SerializeField] float slowdownDuration = 2.5f;
        [SerializeField] float range = 30f;

        [SerializeField] float idealFPS = 60f;

        [Header("Players")]
        [SerializeField] TransformVariable playerOne;
        [SerializeField] TransformVariable playerTwo;

        void Start()
        {
            Assert.IsNotNull(playerOne, "Player one transform not found!");
            Assert.IsNotNull(playerTwo, "Player two transform not found!");
        }

        void Update()
        {
            if (Time.timeScale < 1f)   //Slight optimization
            {
                Time.timeScale += (1f / slowdownDuration) * Time.unscaledDeltaTime;
            }

            //Calc distance
            var dist = Vector3.Distance(playerOne.Value.position, playerTwo.Value.position);
            var playerOneFacing = playerOne.Value.TransformDirection(Vector3.forward);
            var toPlayerTwo = playerTwo.Value.position - playerOne.Value.position;

            //If the players are facing each other...
            if (Vector3.Dot(playerOneFacing, toPlayerTwo) > 0)
            {
                //and within range
                if (dist <= range)
                {
                    SlowMotion();
                }
            }
        }

        public void SlowMotion()
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 1f / idealFPS;
        }
    }
}
