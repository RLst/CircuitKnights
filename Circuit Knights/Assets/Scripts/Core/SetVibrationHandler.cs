using UnityEngine;
using CircuitKnights.Variables;

public class SetVibrationHandler : MonoBehaviour {

    [SerializeField] BoolVariable isVibration;


   public void SetVibration(bool setVibration)
    {
        isVibration.Value = setVibration;
    }
}
