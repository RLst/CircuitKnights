using UnityEngine;

namespace CircuitKnights
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("Noise")]
        [SerializeField] float noiseSpeed;
        [SerializeField] float noiseMagnitude;

        [Header("Movement")]
        [SerializeField] float speed;
        [SerializeField] GameObject desiredPos;

        [Header("Rotation")]
        [SerializeField] float rotationSpeed;
        [SerializeField] GameObject lookAt;

        private float randomNumber;

        private void Start()
        {
            randomNumber = Random.Range(1f, 0f);
        }

        private void Update()
        {
            var dt = Time.deltaTime;

            // Vector3 position = transform.position;
            // position.x = Mathf.Lerp(transform.position.x, moveObject.transform.position.x, speed * dt);
            // position.y = Mathf.Lerp(transform.position.y, moveObject.transform.position.y, speed * dt);
            // position.z = Mathf.Lerp(transform.position.z, moveObject.transform.position.z, speed * dt);
            // transform.position = position;
            transform.position = Vector3.Lerp(transform.position, desiredPos.transform.position, speed * dt);

            Vector3 noiseOffset;
            noiseOffset.x = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed) -0.5f) * noiseMagnitude;
            noiseOffset.y = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.33f) -0.5f) * noiseMagnitude;
            noiseOffset.z = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.66f) -0.5f) * noiseMagnitude;

            Vector3 newLookAt = lookAt.transform.position;
            newLookAt += noiseOffset;

            Quaternion desiredRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newLookAt - transform.position), rotationSpeed * dt);
            transform.rotation = desiredRotation;
        }


    }
}