//DuckBike
//Tony Le
//31 Oct 2018

using UnityEngine;
using CircuitKnights.Objects;
using UnityEngine.Assertions;
using XInputDotNetPure;
using System;

namespace CircuitKnights
{
	// [RequireComponent(typeof(Player))]
    public class PlayerMover : MonoBehaviour
    {


        [TextArea]
        [SerializeField]
        string description =
            "Moves the player's 'horse', which in turns moves the entire player including equipment";
        PlayerData playerData;
		HorseData horseData;
		private PlayerInput playerInput;
		Vector3 startPosition;
		Vector3 tarPos;

		#region Physics
		// [SerializeField] float force;
		[Tooltip("Drag factor of 0.5 reduces factor by half")][Range(0f, 1f)] public float DragFactor;
		public float MaxForce = 50f;
		public float MaxSpeed;
		public Vector3 Force { get; private set; }
		public Vector3 Accel { get; private set; }
        public Vector3 Vel { get; private set; }
        public Vector3 Pos { get; private set; }
		public float LinearSpeed { get { return Vel.magnitude; } }
		#endregion

		void Awake()
        {
			//Retrieve player datas from central Player component
            playerData = GetComponent<Player>().Data;     //Player should be on the same object
            horseData = GetComponent<Player>().HorseData;

            //Polls input via PlayerInput. If none present or disabled then the player can't move
            playerInput = GetComponent<PlayerInput>();

            RememberInitialStartPositions();
            Assertions();

			PhysicsPrecalculations();
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
		private void PhysicsPrecalculations()
		{
			// Accel = for
			Accel = Vector3.zero;
			Vel = Vector3.zero;
			Pos = transform.position;
		}


		void FixedUpdate()
        {
            // MoveByLerp();
			MoveByCustomPhysics();
		}


        #region Custom Physics
        private void MoveByCustomPhysics()
        {
            if (playerInput.AccelAxis != 0)
			{
				Force = MaxForce * transform.forward * playerInput.AccelAxis;
			}
			else {
				Force = Vector3.zero;
				ApplyDrag();
			}
			DoPhysics();
			ApplyFinalTransform();
		}

		private void DoPhysics()
		{
			Pos = transform.position;   //This avoid "charging"
			//Do physics
			// Force = MaxForce * transform.forward * playerInput.AccelAxis;
			Accel = Force / horseData.Mass;
			Vel += Accel * Time.fixedDeltaTime;
			ClampMaxSpeed();
			Pos += Vel * Time.fixedDeltaTime;
		}
		private void ClampMaxSpeed()
		{
            if (Vel.magnitude > MaxSpeed)
            {
				Vel = Vel.normalized * MaxSpeed;
			}
		}
		public void ApplyDrag()
        {
			Vel *= (1f-DragFactor);     //Don't use deltatime!!!
		}

        private void ApplyFinalTransform()
		{
			transform.position = Pos;
		}
        ///////////////////////
        void ArriveToPosition(Vector3 arrivePos, float arriveRadius)
        {
			// Vel = Mathf.Min(Vector3.Distance(transform.position, arrivePos) / arriveRadius, MaxSpeed);
		}

        #endregion

        #region Lerp
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
        #endregion
    }

}
