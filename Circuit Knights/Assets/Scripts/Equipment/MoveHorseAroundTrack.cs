using System;
using System.Collections;
using CircuitKnights.Objects;
using UnityEngine;

namespace CircuitKnights
{
    public class MoveHorseAroundTrack : MonoBehaviour
    {
        //Attach to root
        //Handles the movement of the horses around the track
        Horse horse;
        Player player;
        GameCoordinator gameCoordinator;
        Transform[] startPoints;
        Transform[] endPoints;

        public static event Action onDoNextPass = delegate {};
        [SerializeField] float arrivalDistance = 75f;
        [SerializeField] float arrivalThreshold = 0.1f;

        void Awake()
        {
            //Cache stuff
            horse = GetComponent<Horse>();
            player = GetComponent<Player>();

            //Get start and end points
            gameCoordinator = FindObjectOfType<GameCoordinator>();
            startPoints = gameCoordinator.StartPoints;
            endPoints = gameCoordinator.EndPoints;

            //Events
            
        }


        public void DoNextPass()
        {
            //Get the next end points of the track
            Transform nextEndPoint;
            if (GameSettings.Instance.Round % 2 == 1)   //If the round is odd
            {
                nextEndPoint = endPoints[(int)player.Data.No];
            }
            else    //If the round is even
            {
                nextEndPoint = endPoints[(1 - (int)player.Data.No)];
            }

            ////Move this horse toward the end
            Debug.Log(nextEndPoint);

            yield return StartCoroutine(horse.ArriveAtDestination(nextEndPoint, arrivalDistance, arrivalThreshold));
            // StartCoroutine(SwingPlayerAroundEndsOfTrack(2f));            
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


    }
}