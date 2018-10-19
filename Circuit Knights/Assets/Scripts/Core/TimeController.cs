using UnityEngine;

//Tony Le
//18th of October, 2018

namespace CircuitKnights
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] float slowdownFactor = 0.15f;
        [SerializeField] float slowdownDuration = 2.5f;
        [SerializeField] float range = 30f;

        [SerializeField] float idealFPS = 60f;

        [Header("Players")]
        [SerializeField] Transform playerOne;
        [SerializeField] Transform playerTwo;

        void Start()
        {
            playerOne = GameObject.FindGameObjectWithTag("Player1").transform;
            playerTwo = GameObject.FindGameObjectWithTag("Player2").transform;
        }

        void Update()
        {
            if (Time.timeScale < 1f)   //Slight optimization
            {
                Time.timeScale += (1f / slowdownDuration) * Time.unscaledDeltaTime;
            }

            //Calc distance
            var dist = Vector3.Distance(playerOne.position, playerTwo.position);
            var playerOneFacing = playerOne.TransformDirection(Vector3.forward);
            var toPlayerTwo = playerTwo.position - playerOne.position;

            //If the players are facing each other...
            if (Vector3.Dot(playerOneFacing, toPlayerTwo) > 0)
            {
                // Debug.Log("Facing each other");

                //and within range
                if (dist <= range)
                {
                    // Debug.Log("Slow motion!");
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
