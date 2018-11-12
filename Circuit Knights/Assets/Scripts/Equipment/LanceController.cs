using UnityEngine;
using UnityEngine.Assertions;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    public class LanceController : MonoBehaviour
    {
        [TextArea][SerializeField] string description =
            "Controls the player's lance. The Lance should ONLY HAVE ONE rigidbody attached to the lance mesh itself.";

        ///References
        PlayerData playerData;
        LanceData lanceData;
        PlayerInput playerInput;
        new Rigidbody rigidbody;

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
            rigidbody.mass = lanceData.Mass;
        }
        private void AutoRetrieveData()
        {
            playerData = GetComponentInParent<Player>().Data;
            lanceData = GetComponentInParent<Player>().LanceData;
            playerInput = GetComponentInParent<PlayerInput>();
            rigidbody = GetComponentInChildren<Rigidbody>();
        }

        private void Assertions()
        {
            //Lance needs these components otherwise it won't work properly
            Assert.IsNotNull(playerInput, "Player Input not found!");
            Assert.IsNotNull(rigidbody, "Lance rigidbody not found!");
        }

    #endregion

        void Update()
        {
            HandleLanceAim();
            if (lanceData.isClamped) ClampLanceMovement();
            ApplyTransform();
        }

        private void HandleLanceAim()
        {
            //Calc angular accel
            angAccel.x -= playerInput.LanceAxisY * lanceData.PitchTorque / lanceData.MomentOfInertia * Time.deltaTime;
            angAccel.y += playerInput.LanceAxisX * lanceData.YawTorque / lanceData.MomentOfInertia * Time.deltaTime;

            //Apply "gravity"
            angAccel.x += lanceData.GravityFactor * Time.deltaTime;

            //Calc angular vel
            angVel.x += angAccel.x * Time.deltaTime;
            angVel.y += angAccel.y * Time.deltaTime;

            //Calc angular pos
            angPos.x += angVel.x * Time.deltaTime;
            angPos.y += angVel.y * Time.deltaTime;

            //Apply drag by reducing the accel and vel
            angAccel = angAccel / lanceData.DragFactor;
            angVel /= lanceData.DragFactor;
        }

        void ClampLanceMovement()
        {
            //Clamp and also zero accel and vel to mitigate lance getting stuck at limits effect
            if (angPos.x < lanceData.MinPitch || angPos.x > lanceData.MaxPitch)
            {
                angPos.x = Mathf.Clamp(angPos.x, lanceData.MinPitch, lanceData.MaxPitch);
                angVel.x = angAccel.x = 0f;
            }

            if (angPos.y < lanceData.MinYaw || angPos.y > lanceData.MaxYaw)
            {
                angPos.y = Mathf.Clamp(angPos.y, lanceData.MinYaw, lanceData.MaxYaw);
                angVel.y = angAccel.y = 0f;
            }
        }

        void ApplyTransform()
        {
            angPos.z = angVel.z = angAccel.z = 0;           //These should always be zero to avoid any unwanted gimbal lock effects
            var currentRotation = this.transform.localRotation;
            lanceData.gameObject.transform.localRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(angPos), lanceData.LerpFactor);
            // lanceTranform.localRotation = Quaternion.Euler(angPos);
        }
    }
}