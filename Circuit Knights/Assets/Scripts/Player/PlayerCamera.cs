//DuckBike
//Max Brogno, Tony Le
//29 Nov 2018

using UnityEngine;

namespace CircuitKnights.Cameras
{
    public class PlayerCamera : MonoBehaviour
    {
        ////Smooth player camera with adjustable DesiredPosition

        [Header("Noise")]
        [SerializeField] float noiseSpeed;
        [SerializeField] float noiseMagnitude;

        [Header("Movement")]
        [SerializeField] float speed;
        public Transform DesiredPosition;   //Lazy property

        [Header("Rotation")]
        [SerializeField] float rotationSpeed;
        public Transform LookAt;        //Lazy property

        private float randomNumber;     

        private void Start()
        {
            randomNumber = Random.Range(1f, 0f);
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, DesiredPosition.transform.position, speed * Time.deltaTime);

            Vector3 noiseOffset;
            noiseOffset.x = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed) -0.5f) * noiseMagnitude;
            noiseOffset.y = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.33f) -0.5f) * noiseMagnitude;
            noiseOffset.z = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.66f) -0.5f) * noiseMagnitude;

            Vector3 newLookAt = LookAt.transform.position;
            newLookAt += noiseOffset;

            Quaternion desiredRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newLookAt - transform.position), rotationSpeed * Time.deltaTime);
            transform.rotation = desiredRotation;
        }


    }
}