using UnityEngine;

namespace CircuitKnights
{
    public class DrawGizmo : MonoBehaviour
    {
				public enum GizmoType {
					Cube,
					Line,
					Sphere,
					CubeWireframe,
					SphereWireframe
				}

				[SerializeField] Color color = Color.red;
				[SerializeField] GizmoType gizmoType = GizmoType.Cube;
				[SerializeField] Vector3 scale = Vector3.one;

				void OnDrawGizmos()
				{
					Gizmos.color = color;
					switch (gizmoType)
					{
						case GizmoType.Cube:
							Gizmos.DrawCube(transform.position, scale);
						break;
						case GizmoType.Line:
							Gizmos.DrawLine(transform.position, transform.position + transform.localRotation.eulerAngles.normalized * 1f);
						break;
					}
				}
    }

}