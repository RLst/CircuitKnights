using UnityEngine;


namespace CircuitKnights.Cameras
{
    public class _3DMenuItem : MonoBehaviour
    {
		// [SerializeField] new string name;
        [Tooltip("The 3d camera transform that corresponds to this menu item")]
		[SerializeField] Transform camTransform;
		public Transform CamTransform { get { return camTransform; } }
    }
}