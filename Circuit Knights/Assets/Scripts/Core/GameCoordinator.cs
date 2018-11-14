//DuckBike
//Tony Le
//1 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using CircuitKnights.Events;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;
using UnityEngine.Assertions;

namespace CircuitKnights
{
	public class GameCoordinator : MonoBehaviour
	{
		[Multiline] [SerializeField] string description = "Controls the passes and rounds";

		[Header("GUI")]
		[SerializeField] Text roundText;
		[SerializeField] Text centerText;
		[SerializeField] GameObject skipButton;       //Has to be a gameobject because skipbutton wont hide

		[Header("Count Down")]
		[SerializeField] int countDownTextSize = 60;
		[Tooltip("Realtime seconds")] [SerializeField] int countDownDuration = 3;

		[Header("Go!")]
		[SerializeField] int goTextSize = 150;
		[SerializeField] float goTextShowDuration = 1.5f;


		[Header("Cutscenes")]
		[Tooltip("Duration after which you can skip cutscenes")] [SerializeField] float unskippableDuration = 3.0f;
		[SerializeField] GameObject StartOfMatchCamera;         //General pan around cinematically etc etc
		[SerializeField] GameObject StartOfRoundCamera;         //Pan around each of the players
		private bool playCutscene;      //Flag to control running of cutscene


		[Header("Positions")]
		[SerializeField] Transform[] startPoints;
		[SerializeField] Transform[] endPoints;

		[Header("Events")]
		[SerializeField] GameEvent onEnablePlayerCameras;
		[SerializeField] GameEvent onDisablePlayerCameras;
		[SerializeField] GameEvent onEnablePlayerMovement;
		[SerializeField] GameEvent onDisablePlayerMovement;

		private bool roundIsRunning;


		#region Core
		private void Assertions()
		{
			//Make sure all necessasy components are passed
			Assert.IsNotNull(roundText);
			Assert.IsNotNull(centerText);
			Assert.IsNotNull(skipButton);

			Assert.IsNotNull(onEnablePlayerCameras);
			Assert.IsNotNull(onDisablePlayerCameras);
			Assert.IsNotNull(onEnablePlayerMovement);
			Assert.IsNotNull(onDisablePlayerMovement);

			Assert.IsNotNull(StartOfMatchCamera);
			Assert.IsNotNull(StartOfRoundCamera);

			Assert.IsNotNull(startPoints);
			Assert.IsNotNull(endPoints);
		}
		private void InitGame()
		{
			//General reset
			GameSettings.Instance.Reset();

			//Prevent players from being able to move
			onDisablePlayerMovement.Raise();

			//Make sure the player
			onDisablePlayerCameras.Raise();

			//Hide all GUI
			roundText.enabled = false;
			centerText.enabled = false;
			skipButton.SetActive(false);

			//Setup listener to skip button
			skipButton.gameObject.GetComponent<Button>().onClick.AddListener(OnSkipCutscene);
		}

		void Start()
		{
			Assertions();
			InitGame();
			StartCoroutine(RunFullGame());
		}

		IEnumerator RunFullGame()
		{
			//Runs coroutines in sequence once
			if (GameSettings.Instance.Round == 0)
				yield return StartCoroutine(RunCutscene(StartOfMatchCamera));
			yield return StartCoroutine(RoundGameLoop());
		}

		private IEnumerator RoundGameLoop()
		{
			BeginNewRound();

			yield return StartCoroutine(StartRound());

			yield return StartCoroutine(PlayRound());

			yield return StartCoroutine(EndRound());

			///Declare winner; Switch scenes based on results
			if (GameSettings.Instance.isMatchOver())
				SceneManager.LoadScene(2);     //Results screen scene
			else
				SceneManager.LoadScene(1, LoadSceneMode.Single);    //Main game scene
		}

		#endregion  //Core

		#region Cutscenes

		private IEnumerator RunCutscene(GameObject cutSceneCamera, bool skippable = true)
		{
			//Note: Camera must be setup in legacy mode with an animation (NOT ANIMATOR)

			///Initialise
			skipButton.SetActive(false);
			var cameraAnimation = cutSceneCamera.GetComponent<Animation>();

			//Set up skipabilitiy
			var skippableTime = Time.time + unskippableDuration;

			//Set up camera
			cutSceneCamera.SetActive(true);
			cameraAnimation.Play();

			//Play the camera
			playCutscene = true;
			while (playCutscene)
			{
				if (skippable)
				{
					if (Time.time >= skippableTime)
					{
						//Show skip button
						skipButton.SetActive(true);

						//Manual skip
						if (XCI.GetButtonDown(XboxButton.Start) ||
							Input.GetKeyDown(KeyCode.Space))
						{
							playCutscene = false;
						}
					}
				}

				//Exit if animation is finished
				if (!cameraAnimation.isPlaying)
					playCutscene = false;

				yield return null;
			}

			//Shutdown
			skipButton.SetActive(false);
			cutSceneCamera.SetActive(false);
		}
		#endregion

		#region Round Starting

		private IEnumerator StartRound()
		{
			//Initialise
			PositionPlayersAtStartPoints();
			onDisablePlayerCameras.Raise();
			onDisablePlayerMovement.Raise();

			//Only run on the first round
			if (GameSettings.Instance.Round == 1)
				yield return StartCoroutine(RunCutscene(StartOfRoundCamera, false));

			//Continue straight to playing game after count down
			onEnablePlayerCameras.Raise();
			yield return StartCoroutine(StartCountDown());
		}

		private void BeginNewRound()
		{
			//Initiate the round
			GameSettings.Instance.BeginNewRound();

			//Show round text
			roundText.enabled = true;
			roundText.text = "Round " + GameSettings.Instance.Round;
		}

		private IEnumerator StartCountDown()
		{
			//Initialise
			centerText.enabled = true;
			centerText.fontSize = countDownTextSize;

			for (int countDownTime = countDownDuration; countDownTime > 0; countDownTime--)
			{
				centerText.text = countDownTime.ToString();
				yield return new WaitForSecondsRealtime(1f);    //How long is a second?
			}

			//Shutdown
			centerText.enabled = false;
		}

		private void PositionPlayersAtStartPoints()
		{
			var p1 = GameSettings.Instance.PlayerOne;
			var p2 = GameSettings.Instance.PlayerTwo;

			//Odd numbered round
			if (GameSettings.Instance.Round % 2 == 1)
			{
				p1.SetPositionAndRotation(startPoints[0].position, startPoints[0].rotation);
				p2.SetPositionAndRotation(startPoints[1].position, startPoints[1].rotation);
			}
			//Even numbered round
			else
			{
				p1.SetPositionAndRotation(startPoints[1].position, startPoints[1].rotation);
				p2.SetPositionAndRotation(startPoints[0].position, startPoints[0].rotation);
			}
		}
		#endregion

		#region Round Playing
		private IEnumerator PlayRound()
		{
			//Show the go text
			StartCoroutine(ShowGoText());

			//Start the round!
			onEnablePlayerMovement.Raise();

			//Caches
			var p1 = GameSettings.Instance.PlayerOne;
			var p2 = GameSettings.Instance.PlayerTwo;

			//Brainstorms: roundNotFinished, roundIsRunning, roundIsNotFinished, roundIsPlaying, playingRound
			roundIsRunning = true;
			while (roundIsRunning)
			{
				//Gameplay

				////When does a round/pass end?
				/// * When player's have passed each other ie. they're no longer facing each other (vector3.dot < 0)
				//[This also covers the case where if the players have made impact or not]
				//Get players facing
				// var p1Facing = p1.Root.TransformDirection(Vector3.forward);
				// var directionToP2 = Vector3.Normalize(p2.Root.position - p1.Root.position);
				// if (Vector3.Dot(p1Facing, directionToP2) < 0f)
				// {
				// 	// Debug.Log("p1Facing: " + p1Facing);
				// 	// Debug.Log("Dot product: " + Vector3.Dot(p1Facing, directionToP2));
				// 	EndCurrentRound();
				// 	break;
				// }

				/// * When a player has reached the end of the track
				//If the players have TriggerEnter'd the end of track colliders
				//Declare round is finished
				//(Triggered from a the reset trigger outside via a GameEvent)

				yield return null;
			}
		}
		IEnumerator ShowGoText()
		{
			//Initialise
			centerText.enabled = true;
			centerText.text = "GO!";
			centerText.fontSize = goTextSize;

			//Run
			yield return new WaitForSecondsRealtime(goTextShowDuration);

			//Shutdown
			centerText.enabled = false;
		}
		#endregion

		#region Round Ending

		////Put up top later
		public static event Action<PlayerData.PlayerNumber> onPlayerDied = delegate { };     //Torso death()
		public static event Action<PlayerData.PlayerNumber> onPlayerHeadKnockedOff = delegate { };   //Head death()
		public static event Action<PlayerData.PlayerNumber> onPlayerLeftArmKnockedOff = delegate { };
		public static event Action<PlayerData.PlayerNumber> onPlayerRightArmKnockedOff = delegate { };
		public static event Action<PlayerData.PlayerNumber> onPlayerShieldDestroyed = delegate { };
		////
		private IEnumerator EndRound()
		{
			onDisablePlayerMovement.Raise();

			CheckAndSetPlayersState();

			////If atleast one player is still alive
            if (!GameSettings.Instance.isMatchOver())
            {
                onDisablePlayerMovement.Raise();

                //Move players to their end points using PlayerMover.SetDesiredPosition();
                PositionPlayersAtStartPoints();

                //Disable player input (if applicable) and automatically move player to end points


                //STRECTH GOAL: If player's speed is above a certain number then ragdoll the player off the horse
                //(because he's obviously got too much momentum)

                //Show some kind of results or weapon select screen from the time of impact to the when the players both reached the new start positions

                //

                //Once players have reached end points then "follow" the track around to the new start positions
                //Get the midpoint between the start and end, set this as the "pivot" point and rotate around it while
                //Stop player once they've reached the new start positions

                ////CONTINUE ONTO RESET AND START ROUND
            }
			//Else if there are still rounds left to play out



			//otherwise finish match and  sequences
			//Slow motion cam looking at loser ragdolling off the horse


			//Start countdown again...
			//^^^^ maybe some of these should be implemented in EndRound()

			throw new NotImplementedException();
		}

		private static void CheckAndSetPlayersState()
		{
			////1ST ITERATION (CRAP AND MESSY)
			//Maybe make the an array to hold the player references instead
			//Determine the state of the players
			var p1 = GameSettings.Instance.PlayerOne;
			var p2 = GameSettings.Instance.PlayerTwo;

			//Player ONE
			if (p1.isDead)
			{
				onPlayerDied(p1.No);
			}

			if (p1.isHeadless)
				onPlayerHeadKnockedOff(p1.No);

			if (p1.isLeftArmDestroyed)
				onPlayerLeftArmKnockedOff(p1.No);

			if (p1.isRightArmDestroyed)
				onPlayerRightArmKnockedOff(p1.No);

			if (p1.ShieldData.IsDead)
				onPlayerShieldDestroyed(p1.No);

			//Player TWO
			if (p2.isHeadless)
				onPlayerDied(p2.No);

			if (p2.isDead)
				onPlayerHeadKnockedOff(p2.No);

			if (p2.isLeftArmDestroyed)
				onPlayerLeftArmKnockedOff(p2.No);

			if (p2.isRightArmDestroyed)
				onPlayerRightArmKnockedOff(p2.No);

			if (p2.ShieldData.IsDead)
				onPlayerShieldDestroyed(p2.No);
		}
		#endregion

		#region Public accessible methods
		public void OnSkipCutscene()
		{
			//This function is to allow for externals such as buttons to skip scenes etc
			playCutscene = false;
		}
		public void EndCurrentRound()
		{
			//This can be accessed from outside
			roundIsRunning = false;
		}
		#endregion
	}
}

//Automatically sets player's position based on even or odd round
// var isOdd = GameSettings.Instance.Round % 2;
// GameSettings.Players[isOdd % 2].SetPosition(startPoints[isOdd % 2].position);
// GameSettings.Players[isOdd].SetPosition(startPoints[isOdd].position);