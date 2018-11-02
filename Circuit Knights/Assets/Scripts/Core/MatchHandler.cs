//DuckBike
//Tony Le
//1 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Events;
using CircuitKnights.Variables;
using System.Collections;

namespace CircuitKnights
{
	public class MatchHandler : MonoBehaviour
	{
		[Multiline][SerializeField] string description = "Controls the passes and rounds";
		[SerializeField] Game game;
		public Knight playerOne;
		public Knight playerTwo;
		[SerializeField] GameEvent startCountDown;
		// public static event Action<> StartCountDownTimer = delegate { };

		//Starting and ending positions
		public Transform startPointOne, startPointTwo;
		public Transform endPointOne, endPointTwo;

		void Awake()
		{

		}

		void Start()
		{
			SetupMatch();
		}

		public void SetupMatch()
		{
			//Reset settings
			game.Reset();

			//Position players at start points
			InitPlayers();

			//Do any starting routines
			// StartCoroutine(RunStartingCinematicCutScenes());
			// startCountDown.Raise();
		}

		public void InitPlayers()
		{
			// playerOne.SetPosition(startPointOne.position);
			// playerTwo.SetPosition(startPointTwo.position);
		}

		// private IEnumerator RunStartingCinematicCutScenes()
		// {
		// 	// yield return IEnumerable = 0;
		// }

		/////////////////////////
		void Update()
		{

		}


		////Publics
		public void IncrementPass()
		{
			game.Pass++;
		}

		public void IncrementRound()
		{
			game.Round++;
		}

		public void ResetMatch()
		{
			game.Pass = 0;
			game.Round = 0;
		}

	}
}