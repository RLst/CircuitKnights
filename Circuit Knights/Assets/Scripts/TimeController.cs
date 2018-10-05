using UnityEngine;

namespace CircuitKnights
{

public class TimeController : MonoBehaviour {

    public float slowdown_Factor = 0.05f;
    public float slowdown_length = 2f;

     void Update()
    {
            
        Time.timeScale += (1f / slowdown_length) * Time.unscaledDeltaTime;
    
    }
    public void Slowmotion ()
    {
        Time.timeScale = slowdown_Factor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

      //  private void OnTriggerEnter(Collider other)
      //  {
      //      Slowmotion();
      //  }
    }

}