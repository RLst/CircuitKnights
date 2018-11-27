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
        [Range(0f, 1f)] [SerializeField] float DragFactor = 0.02f;
        [SerializeField] float MaxForce = 5000f;
        [SerializeField] float MaxSpeed = 1000f;
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

            //Get starting and end points
            

            //Polls input via PlayerInput. If none present or disabled then the player can't move
            // playerInput = GetComponent<PlayerInput>();
            // RememberInitialStartPositions();
            // PhysicsPrecalculations();
        }


        void FixedUpdate()
        {
            // MoveByLerp();
            // MoveByCustomPhysics();
        }

        public void HardSetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public IEnumerator ArriveAtDestination(Transform destination, float arrivalDistance, float arrivalThreshold)
        {
            //Temp; move outside or make serializable
            // const float slowingDistance = 50f;
            // const float fineTune = 0.75f;        //Garbage
            const float maxSlowDownForce = -30000f;

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

                Force = MaxForce;       //dt or fixedDT?

                //If within arrival zone then start clamping the velocity directly
                // if (distanceToDestination < arrivalDistance)
                    // float rampedForce = (distanceToDestination / (arrivalDistance * fineTune));
                    // float clampedForce = Mathf.Min(rampedForce, MaxForce);
                    // Vector3 arriveForce = clampedForce * arriveSteerNorm;
                    //Vel = arriveVel - Vel;

                if (distanceToDestination < arrivalDistance)
                {
                    Force = -(arrivalDistance / distanceToDestination) * MaxForce;
                    // Force = -(distanceToDestination * MaxForce / arrivalDistance) * fineTune;
                    Force = Mathf.Clamp(Force, maxSlowDownForce, Force);
                    Debug.Log("Slowing down... Force: " + Force);
                }

                //Get acceleration toward destination
                Accel = arriveSteerNorm * Force / horseData.Mass;

                //Get velocity
                Vel += Accel * Time.deltaTime;

                // Vel = Vel * -0.5f;

                //Get position
                Pos += Vel * Time.deltaTime;

                //Apply transform
                transform.position = Pos;

                // Try1(arriveSteerNorm);

                yield return null;
            }

            //Zero all forces
            Accel = Vector3.zero;
            Vel = Vector3.zero;

            Debug.Log("Do Pass Test Completed!");

            ////If within arrival boundary then start clamping the velocity directly

            ////If reached destination (ie: distance < = arrivalThreshold); stop and declare that player has reached the end of the track
        }

        private void Try1(Vector3 arriveSteerNorm)
        {
            //Move toward destination using max force
            Force = MaxForce;       //dt or fixedDT?

            //Get acceleration toward destination
            Accel = arriveSteerNorm * Force / horseData.Mass;

            //Get velocity
            Vel += Accel * Time.deltaTime;

            //If within arrival zone then start clamping the velocity directly
            // if (distanceToDestination < arrivalDistance)
                // float rampedSpeed = (distanceToDestination / (slowingDistance * fineTune));
                // float clampedSpeed = Mathf.Min(rampedSpeed, MaxSpeed);
                // Vector3 arriveVel = clampedSpeed * arriveSteerNorm;
                // Vel = arriveVel - Vel;

            //Get position
            Pos += Vel * Time.deltaTime;

            //Apply transform
            transform.position = Pos;
        }


        #region Custom Physics
        // private void MoveByCustomPhysics()
        // {
        //     if (playerInput.AccelAxis != 0)
        //     {
        //         Force = MaxForce * playerInput.AccelAxis;
        //     }
        //     else
        //     {
        //         Force = 0f;
        //         ApplyDrag();
        //     }
        //     DoPhysics();
        //     ApplyFinalTransform();
        // }

        private void DoPhysics()
        {
            //This avoid unintended "charging"
            Pos = transform.position;

            Accel = transform.forward * Force / horseData.Mass;     //Always moves forward
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
            Vel *= (1f - DragFactor);     //Doesn't work well with deltatime for some reason!!!
        }

        private void ApplyFinalTransform()
        {
            transform.position = Pos;
        }
        ///////////////////////
        // void SetDestination(Vector3 arrivePos, float arriveRadius)
        // {
        //     //Do a coroutine?

        // 	//Keep updating the velocity until this is reached

        //     StartCoroutine(Arrive(arrivePos, arriveRadius));

        // }

        // IEnumerator Arrive(Vector3 destination, float arriveDistance)
        // {
        //     var seekSteerVec = Vector3.Normalize(destination - transform.position);

        // 	while (true)
        // 	{
        //     	var distance = Vector3.Distance(destination, transform.position);

        // 		//If the player is within arrive distance
        // 		if (distance < arriveDistance)
        // 		{
        //             //Seek toward destination using arrival
        //             Accel = Vector3.zero;   //Override and cancel out any acceleration


        // 			// Vel = seekSteerVec * 
        //             // Vel = Mathf.Min(Vector3.Distance(destination, transform.position) / arriveDistance, MaxSpeed);
        //             // Vel = Mathf.Min(Vector3.Distance(transform.position, arrivePos) / arriveRadius, MaxSpeed);
        //             // Accel = seekSteerNVector * (Force / horseData.Mass) * ;
        //         }
        // 		//Otherwise move as usual


        //         yield return null;
        //     }
        // }

        #endregion  //Custom Physics


        // Transform GetNextEndOfTrack()
        // {
        //     var round = GameSettings.Instance.Round;

        // 	if (round % 2 == 0)		//Even
        // 	{
        // 		return (playerData.No == 0) ? 
        // 	}
        // 	else if (round % 2 == 1)	//Odd
        // 	{

        // 	}
        // 	//Player 1
        //     if (playerData.No == 0)
        // 	{
        //         return endPoints[1];
        //     }
        // }

        /// Destination is the position you want the horse to move and arrive toward
        /// Arrival Distance is the distance at which the horse starts slowing down
        /// MaxForce
        // /// Arrive threshold is the distance to destination deadzone at which it is considered that the horse has reached its destination
        // private IEnumerator Arrive(Transform destination, float arrivalDistance, float maxForce, float arriveThreshold)
        // {
        //     //Initialise position
        //     Pos = transform.position;

        //     while (Vector3.Distance(destination.position, transform.position) > arriveThreshold)
        //     //Stop once the horse has reached the target
        //     {
        //         //Move toward destination using max force
        //         Force = maxForce * Time.deltaTime;       //dt or fixedDT?

        //         var arriveForce = Arrive(destination, 100f);
        //         Debug.Log("arriveForce: " + arriveForce);
        //         Accel = arriveForce / horseData.Mass;
        //         // Accel = seekSteer * (Force / horseData.Mass);

        //         Vel += Accel * Time.deltaTime;
        //         ClampMaxSpeed();

        //         Pos += Vel * Time.deltaTime;

        //         ApplyFinalTransform();

        //         yield return null;
        //     }
        //     Debug.Log("Arrived!");
        // }

        // Vector3 Arrive(Transform destination, float slowingDistance)
        // {
        //     const float arriveThreshold = 0.1f;

        //     Vector3 arriveSteer = destination.position - transform.position;
        //     Vector3 arriveSteerNorm = Vector3.Normalize(arriveSteer);
        //     Debug.Log("ToTarget: " + arriveSteer);

        //     float distance = arriveSteer.magnitude;
        //     Debug.Log("Distance: " + distance + ", SlowDist: " + slowingDistance);

        //     // if (distance == arriveThreshold) return Vector3.zero;		//Arrived at destination

        //     if (distance < slowingDistance)
        //     {   //Within slow range
        //         const float DecelerationTweak = 10f;        //Garbage
        //         float ramped = MaxForce * (distance / (slowingDistance * DecelerationTweak));

        //         float clamped = Mathf.Min(ramped, MaxForce);

        //         Vector3 desiredForce = clamped * arriveSteerNorm;

        //         return desiredForce - Vel;
        //     }
        //     else
        //     {
        //         return arriveSteer * MaxForce;
        //     }




        //     // float slowing = 1f;	//Why 100? slowing distance?
        //     // var seek = destination.position - transform.position;
        //     // var distToDest = seek.magnitude;
        //     // var ramped = MaxSpeed * (distToDest / slowing);
        //     // var clamped = Mathf.Min(MaxSpeed, ramped);
        //     // Vector3 desired = (clamped / distToDest) * seek;
        //     // return (desired - Vel);	//Why 8?
        // }

        // public void HardSetPositionAndRotation(Vector3 position, Quaternion rotation)
        // {

        // }




        // #region Lerp
        // void MoveByLerp()
        // {
        // 	//Adjust the target position
        // 	tarPos += transform.forward * horseData.speed * playerInput.AccelAxis * Time.deltaTime;

        // 	//Lerp towards it
        // 	transform.position = Vector3.Lerp(transform.position, tarPos, horseData.lerpSmoothness);
        // }
        // internal void SetDesiredPosition(Vector3 desiredPos)
        // {
        // 	//Used after a pass has occurred
        // 	tarPos = desiredPos;
        // }
        // internal void SetPosition(Vector3 position)
        // {
        // 	//Used to instantly position the object ie. To reset the positions etc
        // 	transform.position = position;
        // 	tarPos = position;
        // }
        // internal void SetRotation(Quaternion rotation)
        // {
        //     transform.rotation = rotation;
        // }
        // #endregion	//Lerp
    }

}
