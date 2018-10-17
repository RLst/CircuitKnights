using UnityEngine;

//Brent D'Auria & Jack Dawes
//17th of October, 2018

namespace CircuitKnights
{
    public class TimeController : MonoBehaviour
    {
        public float slowdownFactor = 0.05f;
        public float slowdownLength = 2f;
        public Collider collider;
        private bool isSlowMotion = false;

        void Start()
        {
            collider = GetComponent<Collider>();    
        }

        void Update()
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            if (isSlowMotion == true)
            {
                SlowMotion();
            }
        }
        void OnCollisionEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                isSlowMotion = true;
            }
        }
        public void SlowMotion()
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }
    }
}