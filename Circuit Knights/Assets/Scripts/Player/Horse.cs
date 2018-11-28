//DuckBike
//Tony Le
//31 Oct 2018

using UnityEngine;
using CircuitKnights.Objects;
using UnityEngine.Assertions;
using XInputDotNetPure;
using System;
using System.Collections;

namespace CircuitKnights
{
    [RequireComponent(typeof(Player))]
    public class Horse : MonoBehaviour
    {
        [TextArea][SerializeField]
        string description =
            "Hold method to move the player's 'horse', which is the root object in this case, which moves the entire player including equipment";

        PlayerData playerData;
        HorseData horseData;

        // PlayerInput playerInput;
        // Vector3 startPosition;  //obsolete; prevents unintended moving at start
        // Vector3 tarPos;     //discontinued; lerp


        [Header("Physics")]
        // [Range(0f, 1f)] [SerializeField] float DragFactor = 0.02f;
        [SerializeField] float MaxForce = 5000f;
        [SerializeField] float MaxDampeningForce = -30000f;
        [SerializeField] float MaxSpeed = 1000f;
        [SerializeField] float MinSpeed = 25f;

        public float Force { get; private set; }
        public Vector3 Accel { get; private set; }
        public Vector3 Vel { get; private set; }
        public Vector3 Pos { get; private set; }
        public float LinearSpeed { get { return Vel.magnitude; } }

        // [Header("Pass configuration")]
        // [SerializeField] float startingForce = 4000f;
        // [SerializeField] float forceIncreasePerPass = 250f;

        ////Events required
        //onStartPass: The horses will start moving
        //onEndPass: The horses start slowing down to get ready for the next pass
        //onReady: Let's the system know that the players are ready and horse can receive event onStartPass to start them moving

        void Awake()
        {
            //Retrieve player datas from central Player component
            playerData = GetComponent<Player>().Data;     //Player should be on the same object
            horseData = GetComponent<Player>().HorseData;

            //Check for errors
            Assert.IsNotNull(playerData, "Player component required on same object.");
            Assert.IsNotNull(horseData, "Horse data not found.");

            //Init physics
            Accel = Vector3.zero;
            Vel = Vector3.zero;
            Pos = transform.position;

        }


        void FixedUpdate()
        {
            // MoveByLerp();
            // MoveByCustomPhysics();
        }

        // public void HardSetPositionAndRotation(Vector3 position, Quaternion rotation)
        // {
        //     transform.position = position;
        //     transform.rotation = rotation;
        // }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void RotateY(float angDegreesY)
        {
            transform.Rotate(0f, angDegreesY, 0f);
        }

        public IEnumerator ArriveAtDestination(Transform destination, float arrivalDistance, float arrivalThreshold)
        {
            //Temp; move outside or make serializable
            // const float slowingDistance = 50f;
            // const float fineTune = 0.75f;        //Garbage
            // const float maxSlowDownForce = -30000f;

            ////Move toward destination as usual
            //Initialise position
            Pos = transform.position;

            float distanceToDestination = Mathf.Infinity;
            while (distanceToDestination > arrivalThreshold)
            {
                Vector3 arriveSteer = destination.position - transform.position;
                Vector3 arriveSteerNorm = Vector3.Normalize(arriveSteer);
                distanceToDestination = arriveSteer.magnitude;

                //Move toward the destination using max force
                //Get acceleration vector toward destination
                //Get velocity vector toward destination

                //If within arrival zone then start clamping the velocity directly
                // if (distanceToDestination < arrivalDistance)
                    // float rampedForce = (distanceToDestination / (arrivalDistance * fineTune));
                    // float clampedForce = Mathf.Min(rampedForce, MaxForce);
                    // Vector3 arriveForce = clampedForce * arriveSteerNorm;
                    //Vel = arriveVel - Vel;

                Force = MaxForce;       //dt or fixedDT?

                if (distanceToDestination < arrivalDistance)
                {
                    Force = -(arrivalDistance / distanceToDestination) * MaxForce;
                    // Force = -(distanceToDestination * MaxForce / arrivalDistance) * fineTune;
                    Force = Mathf.Clamp(Force, MaxDampeningForce, Force);
                    Debug.Log("Slowing down... Force: " + Force);
                }

                //Get acceleration toward destination
                Accel = arriveSteerNorm * Force / horseData.Mass;

                //Get velocity
                Vel += Accel * Time.fixedDeltaTime;
                //Prevent it from going backwards
                // Vel = Vector3.Max(Vel.normalized * MinSpeed, Vel);

                //Get position
                Pos += Vel * Time.fixedDeltaTime;

                //Apply transform
                transform.position = Pos;

                yield return null;
            }

            //Reset all forces
            Accel = Vector3.zero;
            Vel = Vector3.zero;

            Debug.Log("Do Pass Test Completed!");

            ////If within arrival boundary then start clamping the velocity directly

            ////If reached destination (ie: distance < = arrivalThreshold); stop and declare that player has reached the end of the track
        }

                private IEnumerator SwingPlayerAroundEndsOfTrack(float speed)
        {
            ////Players follows the track around to the next side

            //Automatically calculate useful and comprehensive variables to do work with
            var currentRound = GameSettings.Instance.Round;
            var playerNumber = (int)player.Data.No;

            int zeroIfRoundEven, oneIfRoundOdd;
            zeroIfRoundEven = oneIfRoundOdd = GameSettings.Instance.Round % 2;   //0 if even, 1 if odd
            int zeroIfRoundOdd, oneIfRoundEven;
            zeroIfRoundOdd = oneIfRoundEven = 1 - zeroIfRoundEven;    

            /*
            p1, r1
            abs(0-1) = 1, abs(0-0) = 0;   OK
            p1, r0
            abs(0-0) = 0, abs(0-1) = 1;     OK
            P2, r1 needs to be SP = 0, EP = 1
            abs(1-1) = 0, abs(1-0) = 1;     OK
            p2, r0 nees to be SP = 1, EP = 0
            abs(1-0) = 1, abs(1-1) = 0;     OK
            */

            var trackEndRadius = 1f;        //Crunch crap
            //Just trust that this works for all situations
            var midPoint = ((startPoints[Mathf.Abs(playerNumber - oneIfRoundOdd)].position + endPoints[Mathf.Abs(playerNumber - zeroIfRoundOdd)].position) / 2f);

            // var p1MidPoint = ((startPoints[oneIfOdd].position + endPoints[zeroIfOdd].position) / 2f);
            // var p2MidPoint = ((startPoints[zeroIfOdd].position + endPoints[oneIfOdd].position) / 2f);

            Vector3 playerPos;
            Quaternion playerAng;

            ///Arch players around the track ends
            if (GameSettings.Instance.Round % 2 == 1)
            {
                for (float degrees = 180f; degrees > 0f; degrees -= speed)
                {
                    var rads = (playerNumber * 180f + degrees) * Mathf.Deg2Rad;

                    //Trackend midpoint offset
                    var offset = new Vector3(Mathf.Sin(rads), 0f, Mathf.Cos(rads) * trackEndRadius);

                    playerPos = midPoint + offset;

                    player.Data.Horse.SetPosition(playerPos);
                    player.Data.Horse.RotateY(-speed);

                    // var p1Offset = new Vector3(Mathf.Sin(degrees * Mathf.Deg2Rad), 0f, Mathf.Cos(degrees * Mathf.Deg2Rad)) * trackEndRadius;
                    // var p2Offset = new Vector3(Mathf.Sin((180f - degrees) * Mathf.Deg2Rad), 0f, Mathf.Cos((180f - degrees) * Mathf.Deg2Rad)) * trackEndRadius;

                    // playerOne.Root.position = p1MidPoint + p1Offset;
                    // playerTwo.Root.position = p2MidPoint + p2Offset;

                    //Rotation
                    // playerOne.Root.Rotate(playerOne.Root.up * -speed);
                    // playerTwo.Root.Rotate(playerTwo.Root.up * -speed);

                    yield return null;
                }

            }
            else if (GameSettings.Instance.Round % 2 == 0)
            {
                for (float degrees = 0f; degrees < 180f; degrees += speed)
                {
                    var rads = (playerNumber * 180f + degrees) * Mathf.Deg2Rad;

                    //Trackend midpoint offset
                    var offset = new Vector3(Mathf.Sin(rads), 0f, Mathf.Cos(rads) * trackEndRadius);

                    playerPos = midPoint + offset;

                    player.Data.Horse.SetPosition(playerPos);
                    player.Data.Horse.RotateY(speed);

                    yield return null;
                }
            }
        }












        #region Custom Physics

        private void ClampSpeed()
        {
            if (Vel.magnitude > MaxSpeed)
            {
                Vel = Vel.normalized * MaxSpeed;
            }
            if (Vel.magnitude < MinSpeed)
            {
                Vel = Vel.normalized * MinSpeed;
            }
        }
        // public void ApplyDrag()
        // {
        //     Vel *= (1f - DragFactor);     //Doesn't work well with deltatime for some reason!!!
        // }

        private void ApplyFinalTransform()
        {
            transform.position = Pos;
        }

        // private void DoPhysics()
        // {
        //     //This avoid unintended "charging"
        //     Pos = transform.position;

        //     Accel = transform.forward * Force / horseData.Mass;     //Always moves forward
        //     Vel += Accel * Time.fixedDeltaTime;
        //     ClampSpeed();
        //     Pos += Vel * Time.fixedDeltaTime;
        // }

        #endregion  //Custom Physics
    }

}
