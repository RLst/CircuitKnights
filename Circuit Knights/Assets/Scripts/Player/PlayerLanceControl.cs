using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerLanceControl : MonoBehaviour
    {
        [TextArea][SerializeField] string description = "Controls the player's lance";
        // [SerializeField] Knight player;
        [SerializeField] Lance lance;
        private PlayerInput playerInput;

		//Internal vars
		Vector3 angAccel;
		Vector3 angVel;
		Vector3 angPos;


        void Awake()
        {
            //Retrieve the player input
            playerInput = GetComponentInParent<PlayerInput>();

            //Match the initial lance orientation
            angPos = transform.localRotation.eulerAngles;
        }

        void Start()
        {
            //Set the lance rigidbody weight
            GetComponent<Rigidbody>().mass = lance.Mass;

            Assert.IsNotNull(playerInput, "Player Input not found!");
        }

        void Update()
        {
            HandleLanceAim();
            if (lance.isClamped) ClampLanceMovement();
            ApplyTransform();
        }

        private void HandleLanceAim()
        {
            //Calc angular accel
            angAccel.x += playerInput.LanceAxisY * lance.PitchTorque / lance.MomentOfInertia * Time.deltaTime;
            angAccel.y += playerInput.LanceAxisX * lance.YawTorque / lance.MomentOfInertia * Time.deltaTime;

            //Apply "gravity"
            angAccel.x -= lance.GravityFactor * Time.deltaTime;

            //Calc angular vel
            angVel.x += angAccel.x * Time.deltaTime;
            angVel.y += angAccel.y * Time.deltaTime;

            //Calc angular pos
            angPos.x += angVel.x * Time.deltaTime;
            angPos.y += angVel.y * Time.deltaTime;

            //Apply drag by reducing the accel and vel
            angAccel = angAccel / lance.DragFactor;
            angVel /= lance.DragFactor;
        }

        private void ClampLanceMovement()
        {
            //Clamp and also set angAccel to zero to mitigate stuck lance at limits
            if (angPos.x < lance.MinPitch || angPos.x > lance.MaxPitch)
            {
                angPos.x = Mathf.Clamp(angPos.x, lance.MinPitch, lance.MaxPitch);
                angAccel.x = 0f;
            }

            if (angPos.y < lance.MinYaw || angPos.y > lance.MaxYaw)
            {
                angPos.y = Mathf.Clamp(angPos.y, lance.MinYaw, lance.MaxYaw);
                angAccel.y = 0f;
            }
            angPos.z = 0f; angAccel.z = 0;
        }

        private void ApplyTransform()
        {
            transform.localRotation = Quaternion.Euler(angPos);
        }
    }
}