using System.Collections;
using CircuitKnights.Events;
using CircuitKnights.Gear;
using CircuitKnights.Players;
using UnityEngine;

namespace CircuitKnights
{
    public class MoveHorseAroundTrack : MonoBehaviour
    {
        //Attach to root
        //Handles the movement of the horses around the track
        Horse horse;
        Player player;
        public GameCoordinator gameCoordinator;
        float arrivalDistance;
        float arrivalThreshold;
        Transform[] startPoints;
        Transform[] endPoints;


        ////Events
        [SerializeField] GameEvent OnPlayerReachedTheEnd;

        void Start()
        {
            //Cache and setup stuff
            horse = GetComponent<Horse>();
            player = GetComponent<Player>();

            //Get start and end points
            //gameCoordinator = GameObject.FindGameObjectWithTag("GameCoordinator").GetComponent<GameCoordinator>();
            startPoints = gameCoordinator.StartPoints;
            endPoints = gameCoordinator.EndPoints;

            arrivalDistance = GameSettings.Instance.ArrivalDistance;
            arrivalThreshold = GameSettings.Instance.ArrivalThreshold;
        }

        public void StartNextPass()
        {
            StartCoroutine(DoPass());
        }

        private IEnumerator DoPass()
        {
            //Get the next end points of the track
            Transform nextEndPoint;
            if (GameSettings.Instance.Round % 2 == 1)   //If the round is odd
            {
                nextEndPoint = endPoints[(int)player.No];
            }
            else    //If the round is even
            {
                nextEndPoint = endPoints[(1 - (int)player.No)];
            }
            // Debug.Log("Next End Point: "+nextEndPoint);

            yield return StartCoroutine(horse.ArriveAtDestination(nextEndPoint, arrivalDistance, arrivalThreshold));
            // Debug.Log("Arrived at destination!: "+arrivalDistance);

            yield return StartCoroutine(horse.SwingAroundEndOfTrack(2f, startPoints, endPoints));
            // Debug.Log("Swung around end of track!");

            //Let the system know that the pass has finished?
            //Debug.Log("Pass completed!");
            OnPlayerReachedTheEnd.Raise();
        }

    }
}