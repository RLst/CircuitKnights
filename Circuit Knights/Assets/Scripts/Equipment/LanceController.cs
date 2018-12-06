using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Players;
using CircuitKnights.Gear;

namespace CircuitKnights
{
    public class LanceController : MonoBehaviour
    {
        //[TextArea][SerializeField] string description =
        //    "Attach to root object of lance. Controls the player's lance. The Lance should ONLY HAVE ONE rigidbody attached to the lance mesh itself.";

        ///References
        Player player;
        Lance lance;
        PlayerInput playerInput;
        Rigidbody rb;
        // PlayerData playerData;
        // LanceData lanceData;

        ///Internal vars
        Vector3 angAccel;
		Vector3 angVel;
		Vector3 angPos;

    #region Initialise
        void Start()
        {
            AutoRetrieveData();
            Assertions();

            //Match the initial lance orientation
            angPos = transform.localRotation.eulerAngles;

            //Set the mass of the lance
            //Important for calculated the damage dealt and when the lance becomes a standard rigidbody
            rb.mass = lance.Mass;
        }
        private void AutoRetrieveData()
        {
            // playerData = GetComponentInParent<Player>().Data;
            player = GetComponent<Player>();
            lance = GetComponentInParent<Lance>();
            playerInput = GetComponentInParent<PlayerInput>();
            rb = GetComponentInChildren<Rigidbody>();
        }

        private void Assertions()
        {
            //Lance needs these components otherwise it won't work properly
            Assert.IsNotNull(playerInput, "Player Input not found!");
            Assert.IsNotNull(rb, "Lance rigidbody not found!");
        }

    #endregion

        void Update()
        {
            HandleLanceAim();
            if (lance.isClamped) ClampLanceMovement();
            ApplyTransform();
        }

        private void HandleLanceAim()
        {
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
            angPos.z = angVel.z = angAccel.z = 0;           //These should always be zero to avoid any unwanted gimbal lock effects
            var currentRotation = this.transform.localRotation;
            lance.gameObject.transform.localRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(angPos), lance.LerpFactor);
            // lanceTranform.localRotation = Quaternion.Euler(angPos);
        }
    }
}