using UnityEngine;
using CircuitKnights.Variables;

namespace CircuitKnights
{
    public class ToggleVibration : MonoBehaviour
    {
        //[TextArea][SerializeField] string description = 
        //    "Attach this to the toggle button. Invoke Toggle() using the toggle button's unity event.";
        [SerializeField] BoolVariable vibration;    //This CK Variable can be reference by any object that needs it ie. PlayerInput, DamageDealer
        public void Toggle()    //Just make the vibration toggle button invoke this using it's unityevent system
        {
            vibration.Value = !vibration.Value;
        }
    }
}