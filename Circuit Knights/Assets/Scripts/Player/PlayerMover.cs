//DuckBike
//Tony Le
//31 Oct 2018

using UnityEngine;
using CircuitKnights.Objects;
using UnityEngine.Assertions;
using XInputDotNetPure;
using CircuitKnights.Variables;

namespace CircuitKnights
{
	// [RequireComponent(typeof(Player))]
    public class PlayerMover : MonoBehaviour
    {
        //Brent's
        [SerializeField] BoolVariable isVibration;
        [SerializeField] float LeftMotor = .5f;
        [SerializeField] float RightMotor = .5f;
        //////

        [TextArea] [SerializeField] string description =
			"Moves the horse.";
		PlayerData playerData;
		HorseData horseData;
		private PlayerInput playerInput;
		Vector3 startPosition;
		Vector3 tarPos;

		void Awake()
        {
			//Retrieve player datas from central Player component
            playerData = GetComponent<Player>().Data;     //Player should be on the same object
            horseData = GetComponent<Player>().HorseData;

            //Polls input via PlayerInput. If none present or disabled then the player can't move
            playerInput = GetComponent<PlayerInput>();

            RememberInitialStartPositions();
            Assertions();
        }

        private void RememberInitialStartPositions()
        {
            startPosition = transform.position;
            tarPos = transform.position;
        }

        private void Assertions()
        {
            Assert.IsNotNull(playerData, "Player component required on same object.");
            Assert.IsNotNull(horseData, "Horse data not found.");
        }

		void FixedUpdate()
        {
            MoveByLerp();

            //Brent's
            BrentsVibrationCode();
        }

        //What is this supposed to do? Is it meant to vibrate when the horse moves past a certain speed?
        //horseData.speed is essentially a constant. Need to implement custom physics so that the horse has a velocity
        //which         
        private void BrentsVibrationCode()
        {
            if (horseData.speed > 1)
            {
                Debug.Log(horseData.speed);
                LeftMotor = .2f;
                RightMotor = .2f;
                //selects what controlers to vibrate

                VibrateOnMovment(XInputDotNetPure.PlayerIndex.One);
                Debug.Log("vibrating ON");
                VibrateOnMovment(XInputDotNetPure.PlayerIndex.Two);
            }
        }

        private void MoveByCustomPhysics()
        {
            throw new NotImplementedException();
        }

        void MoveByLerp()
		{
			//Adjust the target position
			tarPos += transform.forward * horseData.speed * playerInput.AccelAxis * Time.deltaTime;

			//Lerp towards it
			transform.position = Vector3.Lerp(transform.position, tarPos, horseData.lerpSmoothness);
		}

		internal void SetDesiredPosition(Vector3 desiredPos)
		{
			//Used after a pass has occurred
			tarPos = desiredPos;
		}

		internal void SetPosition(Vector3 position)
		{
			//Used to instantly position the object ie. To reset the positions etc
			transform.position = position;
			tarPos = position;
		}

		internal void SetRotation(Quaternion rotation)
		{
            transform.rotation = rotation;
        }
        void VibrateOnMovment(XInputDotNetPure.PlayerIndex playerIndex)
        {
            if (isVibration.Value == true)
            {
                XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
            }
        }

    }

}
