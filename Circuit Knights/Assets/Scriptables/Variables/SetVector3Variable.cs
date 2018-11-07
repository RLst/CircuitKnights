using UnityEngine;

namespace CircuitKnights.Variables
{
    public class SetVector3Variable : MonoBehaviour
    {
        //Sets a Vector3 variable to either position, rotate or scale
        [SerializeField] Vector3Variable variable;
        public enum TransformType
        {
            Position,
            Rotation,
            Scale
        }
        [SerializeField] TransformType transformType;

        void Awake()
        {
            if (variable)
            {
                switch (transformType)
                {
                    case TransformType.Position:
                        variable.Value = this.transform.position;
                        break;
                    case TransformType.Rotation:
                        variable.Value = this.transform.rotation.eulerAngles;
                        break;
                    case TransformType.Scale:
                        variable.Value = this.transform.localScale;
                        break;
                    default:
                        Debug.LogError("Transform type not selected!");
                        break;
                }
            }
			else
				Debug.LogError("Vector3 variable not set!");
        }
    }
}