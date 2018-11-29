//Duckbike
//Tony Le
//18th of October, 2018

using UnityEngine;
using System.Collections;

namespace CircuitKnights.Controllers
{
    public class SlowMotionController : MonoBehaviour
    {
        #region Singleton
        public static SlowMotionController Instance { get; private set; }
        private void Awake() {
            if (!Instance) Destroy(gameObject);
            Instance = this;
        }
        #endregion

        [SerializeField] float defaultSlowMoSpeed = 0.05f;
        [SerializeField] float defaultSlowMoDuration = 2.0f;

        public void SlowMotionOn()
        {
            //Does default slow motion
            Time.timeScale = defaultSlowMoSpeed;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f;
        }

        public void SlowMotionOn(float slowMoSpeed)
        {
            Time.timeScale = slowMoSpeed;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f;
        }

        public void SlowMotionOn(float slowMoSpeed, float transitionOutDuration)
        {
            StartCoroutine(TransitionBackToRealtime(slowMoSpeed, transitionOutDuration));
        }

        public void SlowMotionOff()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 1f / 60f;;
        }

        IEnumerator TransitionBackToRealtime(float slowMoSpeed, float transitionOutDuration)
        {
            //Slow motion factor has to be a valid value
            Mathf.Clamp01(slowMoSpeed);

            //Set the initial slow motion
            Time.timeScale = slowMoSpeed;

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


// bool toggleSlowMo = false;
// void Update()
// {
//     //DEBUG
//     if (Input.GetKeyDown(KeyCode.LeftBracket))
//     {
//         if (Input.GetKey(KeyCode.RightShift))
//         {
//             Debug.Log("Transition Slow Mo");
//             SlowMotionOn(0.1f, 5f);
//         }
//         else
//         {
//             Debug.Log("Toggle Default Slow Mo");
//             toggleSlowMo = !toggleSlowMo;
//             if (toggleSlowMo)
//                 SlowMotionOn();
//             else
//                 SlowMotionOff();
//         }
//     }
// }