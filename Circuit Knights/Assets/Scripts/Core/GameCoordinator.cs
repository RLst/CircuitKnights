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
        [Multiline] [SerializeField] string description = "Controls the passes and rounds";

        [Header("Players")]
        [SerializeField] Player playerOne;
        [SerializeField] Player playerTwo;
        // [SerializeField] GameObject playerOnePrefab;
        // [SerializeField] GameObject playerTwoPrefab;


        [Header("GUI")]
        public Canvas countDownCanvas;


        [Header("Events")]
        // [SerializeField] GameEvent startCountDown;      //TODO Might not need this
        // [SerializeField] GameEvent onLanceCollision;
        // [SerializeField] GameEvent onJoustCollision;
		// [SerializeField] GameEvent onPlayStartOfMatchCutscene;
		// [SerializeField] GameEvent onPlayStartOfRoundCutScene;
		[SerializeField] GameEvent onEnablePlayerCameras;
		[SerializeField] GameEvent onDisablePlayerCameras;
		[SerializeField] GameEvent onEnablePlayerMovement;
		[SerializeField] GameEvent onDisablePlayerMovement;


        [Header("Cinematic Cameras")]
		[SerializeField] GameObject StartOfMatchCamera;
			//General pan around cinematically etc etc
		[SerializeField] GameObject StartOfRoundCamera;
			//Pan around each of the players

        [Tooltip("The time after which you can skip the cutscene")] 
			[SerializeField] float cutSceneUnskippableDuration = 3.0f;


        [Header("IEnumerators")]
        IEnumerator runStartOfRoundCutscene;
        IEnumerator runStartOfMatchCutscene;


		[Header("Positions")]
        [SerializeField] Transform[] startPoints;
        [SerializeField] Transform[] endPoints;
        // public Transform startPointOne, startPointTwo;
        // public Transform endPointOne, endPointTwo;

	#region Inits
        void Awake()
        {
            // runStartOfMatchCutscene = RunStartOfMatchCutscene();
            // runStartOfRoundCutscene = RunStartOfRoundCutscene();
        }

        void Start()
        {
            // startWait = new WaitForSeconds(GameSettings.Instance.CountDownDuration);
            // endWait = new WaitForSeconds(GameSettings.Instance.)
            InitGame();
            StartCoroutine(RunIntro());
            StartCoroutine(GameLoop());
        }

        private void InitGame()
        {
            //General reset
            GameSettings.Instance.Reset();

            //Prevent players from being able to move
            onDisablePlayerMovement.Raise();

            onDisablePlayerCameras.Raise();

            PositionPlayersAtStartPoints();	
        }
        IEnumerator RunIntro()  //pregame match camera stuff
        {
            yield return StartCoroutine(RunStartOfMatchCutscene());
        }
        private IEnumerator RunStartOfMatchCutscene()
        {
            //Start far away and move toward the player at an angle blah blah blah
            //Pan the crowd blah blah blah
            //Zoom in on the king / lady / princess blah blah blah
            StartOfMatchCamera.SetActive(true);
            var camAnim = StartOfMatchCamera.GetComponent<Animation>();
            var skippableTime = Time.time + cutSceneUnskippableDuration;

			camAnim.Play();	//Play once only

            while (true)
            {
                //Exit if user skips
                if (Time.time >= skippableTime)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        yield return true;
                        break;
                    }
                }
                //Exit if animation is finished
                if (!camAnim.isPlaying)
                    break;
                yield return null;
            }

            //Switch to player cameras
            StartOfMatchCamera.SetActive(false);
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
			//Switch to player cameras
            EnablePlayerCameras();

            DisablePlayerMovement();

            //If it's the first round then run camera sequence 
            if (GameSettings.Instance.Round == 1)
                yield return StartCoroutine(RunStartOfRoundCutscene());

			EnablePlayerMovement();
            EnablePlayerCameras();	//(ready player cameras)

            ///Start countdown
            yield return StartCoroutine(StartCountDown());
        }

        private IEnumerator RunStartOfRoundCutscene()
        {
            var skippableTime = Time.time + cutSceneUnskippableDuration;

            //If skip button isn't pressed and 
            while (true)
            {
                //If the current time is after the skippable time and a valid key is pressed...
                if (Time.time >= skippableTime)
                {
                    if (XCI.GetButtonDown(XboxButton.Start) || Input.GetKeyDown(KeyCode.Space))     //Any controller; Not very responsive
                    {
                        break;      //Break out of while loop and hence stop this coroutine
                    }
                }

                ////PUT CAMERA CUTSCENE STUFF HERE!!!
				StartOfRoundCamera.SetActive(true);
                // Debug.Log("Camera cutscene...");

                yield return null;
            }
            //Will now continue back where it left off in StartRound()...
        }
        private void DisablePlayerCameras()
        {
            onDisablePlayerCameras.Raise();
        }
        private void EnablePlayerCameras()
        {
			onEnablePlayerCameras.Raise();
            // playerOne.EnableCamera();
            // playerTwo.EnableCamera();
        }
        private void DisablePlayerMovement()
        {
			onDisablePlayerMovement.Raise();
            // playerOne.DisableMovement();
            // playerTwo.DisableMovement();
            // playerOne.gameObject.GetComponent<PlayerMover>().enabled = false;
            // playerTwo.gameObject.GetComponent<PlayerMover>().enabled = false;
        }


        private IEnumerator StartCountDown()
        {
            //Enable the countdown canvas
            countDownCanvas.enabled = true;

            //Get the countdown text (should only be one in canvas)
            Text countDownText = countDownCanvas.GetComponentInChildren<Text>();

            for (int countDownTime = GameSettings.Instance.CountDownDuration; countDownTime > 0; countDownTime--)
            {
                countDownText.text = countDownTime.ToString();
                yield return new WaitForSecondsRealtime(1f);	//The duration between the seconds
            }
        }

        private void PositionPlayersAtStartPoints()
        {
            ////Can't really set the player's position because the player in this
            // case is the actual root object of the player's mesh.
            //BUT What if the Player.gameObject was actually set to the root of the player object?
            //The root object can use GetComponent to reference player's object etc.

            //Odd numbered round
            if (GameSettings.Instance.Round % 2 == 1)
            {
				playerOne.Root.position = startPoints[0].position;
				playerTwo.Root.position = startPoints[1].position;
                // playerOnePrefab.transform.position = startPoints[0].position;
                // playerTwoPrefab.transform.position = startPoints[1].position;
                // GameSettings.Players[0].SetPosition(startPoints[0].position);
                // GameSettings.Players[1].SetPosition(startPoints[1].position);
                // GameSettings.Instance.PlayerOne.SetPosition(startPoints[0].position);
                // GameSettings.Instance.PlayerTwo.SetPosition(startPoints[1].position);
            }
            //Even numbered round
            else
            {
				playerOne.Root.position = startPoints[1].position;
				playerTwo.Root.position = startPoints[0].position;
                // playerOnePrefab.transform.position = startPoints[1].position;
                // playerTwoPrefab.transform.position = startPoints[0].position;
                // GameSettings.Instance.PlayerOne.SetPosition(startPoints[1].position);
                // GameSettings.Instance.PlayerTwo.SetPosition(startPoints[0].position);
                // StopCoroutine(PlayRound());
            }

            //Automatically sets player's position based on even or odd round
            // var isOdd = GameSettings.Instance.Round % 2;
            // GameSettings.Players[isOdd % 2].SetPosition(startPoints[isOdd % 2].position);
            // GameSettings.Players[isOdd].SetPosition(startPoints[isOdd].position);
        }
	#endregion

	#region Round Playing
        private IEnumerator PlayRound()
        {
            EnablePlayerMovement();

			//Show the go text 
			StartCoroutine(ShowGoText(1.5f));

			while (true)
			{
				//Gameplay
				yield return null; 
			}
        }
        IEnumerator ShowGoText(float showDuration)
        {
            var text = countDownCanvas.GetComponentInChildren<Text>();

			//Set text big etc
			text.text = "GO!";
			text.fontSize += 10;

			yield return new WaitForSecondsRealtime(showDuration);

			//Hide and disable the canvas
			countDownCanvas.enabled = false;
        }

        private void EnablePlayerMovement()
        {
			playerOne.playerMover.enabled = true;
			playerTwo.playerMover.enabled = true;
        }
	#endregion

	#region Round Ending
        private IEnumerator EndRound()
        {
            throw new NotImplementedException();
        }
	#endregion

#endregion //MAIN

    }
}