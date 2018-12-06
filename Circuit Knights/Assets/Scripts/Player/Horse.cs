//DuckBike
//Tony Le
//31 Oct 2018

using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using CircuitKnights.Players;

namespace CircuitKnights.Gear
{
    public class Horse : Equipment
    {
        // [TextArea][SerializeField]
        // string description =
        //     "Hold method to move the player's 'horse', which is the root object in this case, which moves the entire player including equipment";

        Player player;
        Horse horse;

        [Header("Physics")]
        public float Mass = 750f;
        public float MaxSpeed = 200f;
        public float MinSpeed = 0f;
        public float Force { get; private set; }
        public Vector3 Accel { get; private set; }
        public Vector3 Vel { get; private set; }
        public Vector3 Pos { get; private set; }
        public float LinearSpeed { get { return Vel.magnitude; } }


        [Header("Rounds speed up")]
        public float StartingForce = 5000f;
        public float ForceIncreasePerPass = 1000f;


        void Awake()
        {
            //Retrieve player datas from central Player component
            player = GetComponentInParent<Player>();

            //Check for errors
            Assert.IsNotNull(player, "Player component required on same object.");
        }

        void Start()
        {
            //Init physics
            Accel = Vector3.zero;
            Vel = Vector3.zero;
            Pos = transform.position;
        }

        public IEnumerator ArriveAtDestination(Transform destination, float arrivalDistance, float arrivalThreshold)
        {
            ////Move toward destination as usual
            //Initialise position
            Pos = transform.position;

            float distanceToDestination = Mathf.Infinity;
            while (distanceToDestination > arrivalThreshold)
            {
                Vector3 arriveSteer = destination.position - transform.position;
                Vector3 arriveSteerNorm = Vector3.Normalize(arriveSteer);
                distanceToDestination = arriveSteer.magnitude;
                // Debug.Log("distance: " + distanceToDestination);

                //Max force increases per round
                Force = StartingForce + GameSettings.Instance.Round * ForceIncreasePerPass;
                
                if (distanceToDestination < arrivalDistance)
                {
                    Force = -Force * GameSettings.Instance.ArrivalBrakingFineTuneFactor;
                    // Force = -(arrivalDistance / distanceToDestination * MaxForce / dampeningForceFineTune);

                    //Clamp the dampening force
                    // Debug.Log("Slowing down... Force: " + Force);
                }

                //Get acceleration toward destination
                Accel = arriveSteerNorm * Force / Mass;

                //Get velocity
                Vel += Accel * Time.fixedDeltaTime;
                // Debug.Log("Before Clamp: " + Vel.magnitude);
                ClampSpeed();
                // Debug.Log("After Clamp: " + Vel.magnitude);

                //Get position
                Pos += Vel * Time.fixedDeltaTime;

                //Apply transform
                transform.position = Pos;

                yield return null;
            }

            //Zero all forces
            Accel = Vector3.zero;
            Vel = Vector3.zero;

            ////If within arrival boundary then start clamping the velocity directly

            ////If reached destination (ie: distance < = arrivalThreshold); stop and declare that player has reached the end of the track
        }

        public IEnumerator SwingAroundEndOfTrack(float angSpeed, Transform[] startPoints, Transform[] endPoints)
        {
            ////Players follows the track around to the next side
            //Automatically calculate useful and comprehensive variables to do work with
            var currentRound = GameSettings.Instance.Round;
            var playerNumber = (int)player.No;
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
            Vector3 playerPos; 

            ///Arch players around the track ends
            if (oneIfRoundOdd == 1)
            {
                for (float degrees = 180f; degrees > 0f; degrees -= angSpeed)
                {
                    var rads = (playerNumber * 180f + degrees) * Mathf.Deg2Rad;
                    //Trackend midpoint offset
                    var offset = new Vector3(Mathf.Sin(rads), 0f, Mathf.Cos(rads) * trackEndRadius);
                    playerPos = midPoint + offset;

                    //Apply transform
                    transform.position = playerPos;
                    transform.Rotate(0f, -angSpeed, 0f);

                    yield return null;
                }
            }
            else
            {
                for (float degrees = 360f; degrees > 180f; degrees -= angSpeed)
                {
                    var rads = (playerNumber * 180f + degrees) * Mathf.Deg2Rad;
                    //Trackend midpoint offset
                    var offset = new Vector3(Mathf.Sin(rads), 0f, Mathf.Cos(rads) * trackEndRadius);
                    playerPos = midPoint + offset;

                    //Apply transform
                    transform.position = playerPos;
                    transform.Rotate(0f, -angSpeed, 0f);

                    yield return null;
                }
            }
        }

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


    }
}




        // #region Custom Physics
        // private void DoPhysics()
        // {
        //     //This avoid unintended "charging"
        //     Pos = transform.position;

        //     Accel = transform.forward * Force / horseData.Mass;     //Always moves forward
        //     Vel += Accel * Time.fixedDeltaTime;
        //     ClampSpeed();
        //     Pos += Vel * Time.fixedDeltaTime;
        // }
        // public void ApplyDrag()
        // {
        //     Vel *= (1f - DragFactor);     //Doesn't work well with deltatime for some reason!!!
        // }

        // private void ApplyFinalTransform()
        // {
        //     transform.position = Pos;
        // }
        // #endregion  //Custom Physics