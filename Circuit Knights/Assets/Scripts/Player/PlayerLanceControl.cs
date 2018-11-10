using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    // [RequireComponent(typeof(Rigidbody))]
    public class PlayerLanceControl : MonoBehaviour
    {
        [TextArea][SerializeField] string description =
            "Controls the player's lance. The Lance should ONLY HAVE ONE rigidbody attached to the lance mesh itself.";

        //This needs to auto reference the lance from the root object
        [SerializeField] Lance lance;

        // [Tooltip("Helps reduce lance hitting the wall at limit effect. Too much lerp will affect accuracy.")]
        // [SerializeField] [Range(0f, 1f)] float lerpAmount;

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
            Assert.IsNotNull(playerInput, "Player Input not found!");
            
            //Make sure the lance has a rigidbody on it
            var rb = GetComponentInChildren<Rigidbody>();
            Assert.IsNotNull(rb, "Lance rigidbody not found!");
            rb.mass = lance.Mass;
        }

        void Update()
        {
            HandleLanceAim();
            if (lance.isClamped) ClampLanceMovement();
            ApplyTransform();
        }

        private void HandleLanceAim()
        {
            //Get current angular position
            // angPos = transform.rotation.eulerAngles;

            //Calc angular accel
            angAccel.x -= playerInput.LanceAxisY * lance.PitchTorque / lance.MomentOfInertia * Time.deltaTime;
            angAccel.y += playerInput.LanceAxisX * lance.YawTorque / lance.MomentOfInertia * Time.deltaTime;

            //Apply "gravity"
            angAccel.x += lance.GravityFactor * Time.deltaTime;

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

        void ClampLanceMovement()
        {
            //Clamp and also zero accel and vel to mitigate lance getting stuck at limits effect
            if (angPos.x < lance.MinPitch || angPos.x > lance.MaxPitch)
            {
                angPos.x = Mathf.Clamp(angPos.x, lance.MinPitch, lance.MaxPitch);
                angVel.x = angAccel.x = 0f;
            }

            if (angPos.y < lance.MinYaw || angPos.y > lance.MaxYaw)
            {
                angPos.y = Mathf.Clamp(angPos.y, lance.MinYaw, lance.MaxYaw);
                angVel.y = angAccel.y = 0f;
            }
        }

        void ApplyTransform()
        {
            //These should always be zero to avoid any unwanted gimbal lock effects
            angPos.z = angVel.z = angAccel.z = 0;
            var currentRotation = this.transform.localRotation;
            lance.gameObject.transform.localRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(angPos), lance.LerpFactor);
            // lanceTranform.localRotation = Quaternion.Euler(angPos);
        }
    }
}