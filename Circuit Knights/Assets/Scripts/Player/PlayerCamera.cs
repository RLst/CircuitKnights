using UnityEngine;

namespace CircuitKnights
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("Camera Sway")]
        [SerializeField] float swaySpeed;
        [SerializeField] float swayAmount;

        [Header("Movement")]
        [SerializeField] float moveSpeed;
        [SerializeField] GameObject moveObject;

        [Header("Rotation")]
        [SerializeField] float rotationSpeed;
        [SerializeField] GameObject rotateObject;


        private void Update()
        {
            var dt = Time.deltaTime;

            Vector3 position = transform.position;
            position.x = Mathf.Lerp(transform.position.x, moveObject.transform.position.x, moveSpeed * dt);
            position.y = Mathf.Lerp(transform.position.y, moveObject.transform.position.y, moveSpeed * dt);
            position.z = Mathf.Lerp(transform.position.z, moveObject.transform.position.z, moveSpeed * dt);
            transform.position = position;

            float swayX = (Mathf.PerlinNoise(0, Time.time * swaySpeed) - 0.5f) * swayAmount;
            float swayY = (Mathf.PerlinNoise(0, Time.time * swaySpeed) - 0.5f) * swayAmount;

            Vector3 newLookAt = rotateObject.transform.position;
            newLookAt.x += swayX;
            newLookAt.y += swayY;
            Quaternion desiredRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newLookAt - transform.position), rotationSpeed * dt);
            transform.rotation = desiredRotation;
        }


    }
}