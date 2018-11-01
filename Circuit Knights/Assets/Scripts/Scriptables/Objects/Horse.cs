//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights.Objects
{

    public enum HorseType
    {
        Standard,
        Pedal,
        Rocket
    }

    [CreateAssetMenu(fileName = "New Horse", menuName = "Horse", order = 52)]
    public class Horse : ScriptableObject
    {
        [Multiline] [SerializeField] string description = "";
        public HorseType horseType = HorseType.Standard;
        public GameObject mesh;

#region Controls
        [Header("Controls")]
        [SerializeField] XboxAxis accelAxis;
        [SerializeField] XboxButton decelButton;
        public XboxAxis Accel { get { return accelAxis; }}
        public XboxButton Decel { get { return decelButton; }}
#endregion
#region Movement
        [Header("Movement")]
        [Range(1f, 100f)] public float speed;
        [Range(0f, 10f)] public float lerpSmoothness;
#endregion
        public void ClampTValue()
        {
            lerpSmoothness = Mathf.Clamp01(lerpSmoothness);
        }
    }

}