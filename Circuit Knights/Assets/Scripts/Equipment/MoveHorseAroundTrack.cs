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


		void Awake()
		{
            //Cache stuff
            horse = GetComponent<Horse>();
            player = GetComponent<Player>();

            //Get start and end points
            gameCoordinator = FindObjectOfType<GameCoordinator>();
            startPoints = gameCoordinator.StartPoints;
            endPoints = gameCoordinator.EndPoints;
        }


        public void StartNextPass()
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
            //Test
            const float arrivalDistance = 25f;  //Should be in horseData
            const float arrivalThreshold = 0.1f;
            const float maxForce = 2500f;       //should be in horseData
            const float maxSpeed = 2000f;        //Should be in horseData

            StartCoroutine(horse.ArriveAtDestination(nextEndPoint, arrivalDistance, arrivalThreshold));
        }
    }
}