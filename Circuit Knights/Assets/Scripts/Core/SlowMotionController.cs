//Duckbike
//Tony Le
//18th of October, 2018

using UnityEngine;
using System.Collections;

namespace CircuitKnights
{
    public class SlowMotionController : MonoBehaviour
    {
        [SerializeField] float slowdownFactor = 0.05f;
        [SerializeField] float slowMotionDuration = 2.0f;

        bool toggleSlowMo = false;
        void Update()
        {
            //DEBUG
            if (Input.GetKeyDown("s"))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Debug.Log("slowmo2");
                    SlowMotionOn(slowMotionDuration);
                }
                else
                {
                    toggleSlowMo = !toggleSlowMo;
                    if (toggleSlowMo)
                        SlowMotionOn();
                    else
                        SlowMotionOff();
                }
            }
        }

        public void SlowMotionOn()
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        public void SlowMotionOn(float transitionOutDuration)
        {
            StartCoroutine(TransitionBackToRealtime(transitionOutDuration));
        }

        private IEnumerator TransitionBackToRealtime(float transitionOutDuration)
        {
            Time.timeScale = slowdownFactor;
            while (Time.timeScale < 1f)
            {
                Time.timeScale += (1f / transitionOutDuration) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
                yield return null;
            }
            // Time.timeScale = 1f;
            // yield return new WaitUntil(() => Time.timeScale >= 1f);
        }

        public void SlowMotionOff()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 1f;
        }
    }
}



// if (Time.timeScale < 1f)   //Slight optimization
// {
//     Time.timeScale += (1f / slowdownDuration) * Time.unscaledDeltaTime;
// }

// //Calc distance
// var dist = Vector3.Distance(playerOne.Value.position, playerTwo.Value.position);
// var playerOneFacing = playerOne.Value.TransformDirection(Vector3.forward);
// var toPlayerTwo = playerTwo.Value.position - playerOne.Value.position;

// //If the players are facing each other...
// if (Vector3.Dot(playerOneFacing, toPlayerTwo) > 0)
// {
//     //and within range
//     if (dist <= range)
//     {
//         SlowMotion();
//     }
// }