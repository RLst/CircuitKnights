//Duckbike
//Tony Le
//18th of October, 2018

using UnityEngine;
using System.Collections;

namespace CircuitKnights
{
    public class SlowMotionController : MonoBehaviour
    {
        [SerializeField] float defaultSlowMoFactor = 0.05f;
        [SerializeField] float defaultSlowMoDuration = 2.0f;

        bool toggleSlowMo = false;

        void Update()
        {
            //DEBUG
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                if (Input.GetKey(KeyCode.RightShift))
                {
                    Debug.Log("Transition Slow Mo");
                    SlowMotionOn(0.1f, 5f);
                }
                else
                {
                    Debug.Log("Toggle Default Slow Mo");
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
            //Does default slow motion
            Time.timeScale = defaultSlowMoFactor;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f;
        }

        public void SlowMotionOn(float slowMoFactor)
        {
            Time.timeScale = slowMoFactor;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f;
        }

        public void SlowMotionOn(float slowMoFactor, float transitionOutDuration)
        {
            StartCoroutine(TransitionBackToRealtime(slowMoFactor, transitionOutDuration));
        }

        public void SlowMotionOff()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f;;
        }

        private IEnumerator TransitionBackToRealtime(float slowMoFactor, float transitionOutDuration)
        {
            //Slow motion factor has to be a valid value
            Mathf.Clamp01(slowMoFactor);

            //Set the initial slow motion
            Time.timeScale = slowMoFactor;

            while (Time.timeScale < 1f)
            {
                Time.timeScale += (1f / transitionOutDuration) * Time.unscaledDeltaTime;
                //
                yield return null;
            }

            //Reset             
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f; ;
            // yield return new WaitUntil(() => Time.timeScale >= 1f);
        }
    }
}
