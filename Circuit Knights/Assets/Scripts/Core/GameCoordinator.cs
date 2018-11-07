//DuckBike
//Tony Le
//1 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Events;
using CircuitKnights.Variables;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

namespace CircuitKnights
{
	public class GameCoordinator : MonoBehaviour
	{
		[Multiline][SerializeField] string description = "Controls the passes and rounds";
		
		#region Players
		[SerializeField] Player playerOne;
		[SerializeField] Player playerTwo;
		#endregion

		#region IEnumerators
		IEnumerator runStartOfRoundCutscene;
		IEnumerator runStartOfMatchCutscene;
		#endregion

		#region GUI
		public Canvas countDownCanvas;
		#endregion

		#region Events	
		[SerializeField] GameEvent startCountDown;		//TODO Might not need this
		[SerializeField] GameEvent onLanceCollision;
		[SerializeField] GameEvent onJoustCollision;
		#endregion

		#region Cinematic Cameras
		// [SerializeField] CinematicCamera cinematicCamera;
		[Tooltip("The time after which you can skip the cutscene")][SerializeField] float cutSceneUnskippableDuration = 3.0f;
		#endregion

		#region Positions
		[SerializeField] Transform[] startPoints;
		[SerializeField] Transform[] endPoints;
		// public Transform startPointOne, startPointTwo;
		// public Transform endPointOne, endPointTwo;
		#endregion

#region Inits
		void Awake()
		{
			runStartOfMatchCutscene = RunStartOfMatchCutscene();
			runStartOfRoundCutscene = RunStartOfRoundCutscene();
		}

		void Start()
		{
			// startWait = new WaitForSeconds(GameSettings.Instance.CountDownDuration);
			// endWait = new WaitForSeconds(GameSettings.Instance.)
			InitGame();
			RunStartOfMatchCutscene();
			StartCoroutine(GameLoop());
		}

		private IEnumerator RunStartOfMatchCutscene()
		{
			//Start far away and move toward the player at an angle blah blah blah
			//Pan the crowd blah blah blah
			//Zoom in on the king / lady / princess blah blah blah

			Debug.Log("Running start of match cut scene");

			yield return new WaitForSeconds(3);
		}

		private void InitGame()
		{
			GameSettings.Instance.Reset();
			// PositionPlayersAtStartPoints();		
		}
#endregion

#region MAIN
		private IEnumerator GameLoop()
		{
			//Initiate the pass and round
			GameSettings.Instance.BeginRound();

			//Start the round
			yield return StartCoroutine(StartRound());

			//Play the round
			yield return StartCoroutine(PlayRound());

			//End the round
			yield return StartCoroutine(EndRound());

            ///Declare winner; Switch scenes based on results
            if (GameSettings.Instance.MatchIsOver())
            {
                SceneManager.LoadScene(2);     //Results screen scene
            }
            else
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);    //Main game scene
            }
        }

#region Round Starting
        private IEnumerator StartRound()
        {
            DisablePlayerMovement();

			PositionPlayersAtStartPoints();

			//If it's the first round then run camera sequence 
            if (GameSettings.Instance.Round == 1)
				yield return StartCoroutine(RunStartOfRoundCutscene());

			EnablePlayerCameras();	//(ready player cameras)

            ///Start countdown
            StartCoroutine(StartCountDown());
        }

        private void EnablePlayerCameras()
        {
            playerOne.EnableCamera();
			playerTwo.EnableCamera();
        }

        private void DisablePlayerMovement()
        {
			playerOne.DisableMovement();
			playerTwo.DisableMovement();
            // playerOne.gameObject.GetComponent<PlayerMover>().enabled = false;
            // playerTwo.gameObject.GetComponent<PlayerMover>().enabled = false;
        }

        private IEnumerator RunStartOfRoundCutscene()
        {
			// yield return new WaitForSecondsRealtime(1f);	//Prevent key
			var skippableTime = Time.time + cutSceneUnskippableDuration;

			//If skip button isn't pressed and 
			while (true)
			{
				//If the current time is after the skippable time and a valid key is pressed...
				if (Time.time >= skippableTime)
					if (XCI.GetButtonDown(XboxButton.Start))	//Any controller
						StopCoroutine(RunStartOfRoundCutscene());		//..Stop the cutscene

				////PUT CAMERA CUTSCENE STUFF HERE!!!
				Debug.Log("Camera cutscene...");

				yield return null;
			}
			//Will now continue back where it left off in StartRound()...
        }
        
		private IEnumerator StartCountDown()
        {
			//Enable the countdown canvas
			countDownCanvas.enabled = true;

			//Get the countdown text (should only be one in canvas)
			Text countDownText = countDownCanvas.GetComponentInChildren<Text>();

			//Retrieve countdown duration
			var countDownDuration = GameSettings.Instance.CountDownDuration;
			
			for (int countDownTime = countDownDuration; countDownTime > 0; countDownTime--)
			{
				if (countDownTime <= 0)
				{
					countDownText.text = "GO!";
				}
				else 
				{
					countDownText.text = countDownTime.ToString();
				}

				yield return new WaitForSecondsRealtime(1f);
			}
        }

        private void PositionPlayersAtStartPoints()
        {
			
			//Automatically sets player's position based on even or odd round
			// var isOdd = GameSettings.Instance.Round % 2;
			// GameSettings.Players[isOdd % 2].SetPosition(startPoints[isOdd % 2].position);
			// GameSettings.Players[isOdd].SetPosition(startPoints[isOdd].position);

			//Odd numbered round
            if (GameSettings.Instance.Round % 2 == 1)
			{
				// GameSettings.Players[0].SetPosition(startPoints[0].position);
				// GameSettings.Players[1].SetPosition(startPoints[1].position);
				GameSettings.Instance.PlayerOne.SetPosition(startPoints[0].position);
				GameSettings.Instance.PlayerTwo.SetPosition(startPoints[1].position);
			}
			//Even numbered round
			else 
			{
				GameSettings.Instance.PlayerOne.SetPosition(startPoints[1].position);
				GameSettings.Instance.PlayerTwo.SetPosition(startPoints[0].position);
				// StopCoroutine(PlayRound());
			}
        }
#endregion

#region Round Playing
        private IEnumerator PlayRound()
        {
			EnablePlayerMovement();

			//Run the joust
			StartCoroutine(CheckForJoustCollision());

            throw new NotImplementedException();
        }

        private IEnumerator CheckForJoustCollision()
        {
			//Listen for a joust collision
			

			//OR 

			//Directly check for collisions
			float joustDamage = 100f;
			float slowMotionDamageThreshold = 50f;

			bool collided = false;

			if (Input.GetKeyDown(KeyCode.C))
			{
				collided = true;
				//Insert collision detection here
			}

			//Lance collided - raise event
			if (collided && joustDamage > slowMotionDamageThreshold)
				onLanceCollision.Raise();			

            throw new NotImplementedException();
        }

        private void EnablePlayerMovement()
        {
            playerOne.gameObject.GetComponent<PlayerMover>().enabled = true;
            playerTwo.gameObject.GetComponent<PlayerMover>().enabled = true;
        }

		
#endregion

#region Round Ending
        private IEnumerator EndRound()
        {
            throw new NotImplementedException();
        }
#endregion

#endregion	//MAIN

	}
}