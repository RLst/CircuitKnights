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


        [Header("GUI")]
        public Text countDownText;
        public GameObject skipButton;


        [Header("Events")]
		[SerializeField] GameEvent onEnablePlayerCameras;
		[SerializeField] GameEvent onDisablePlayerCameras;
		[SerializeField] GameEvent onEnablePlayerMovement;
		[SerializeField] GameEvent onDisablePlayerMovement;


        [Header("Cutscenes")]
		[SerializeField] GameObject StartOfMatchCamera;
			//General pan around cinematically etc etc
		[SerializeField] GameObject StartOfRoundCamera;
			//Pan around each of the players

        [Tooltip("Duration after which you can skip cutscenes")][SerializeField] float unskippableDuration = 3.0f;


        // [Header("IEnumerators")]
        // IEnumerator runStartOfRoundCutscene;
        // IEnumerator runStartOfMatchCutscene;


		[Header("Positions")]
        [SerializeField] Transform[] startPoints;
        [SerializeField] Transform[] endPoints;


	#region Inits
        void Awake()
        {
        }

        void Start()
        {
            // startWait = new WaitForSeconds(GameSettings.Instance.CountDownDuration);
            // endWait = new WaitForSeconds(GameSettings.Instance.)
            InitGame();
            StartCoroutine(RunFullGame());
        }

        private void InitGame()
        {
            //General reset
            GameSettings.Instance.Reset();

            //Prevent players from being able to move
            onDisablePlayerMovement.Raise();

            //Make sure the player
            onDisablePlayerCameras.Raise();

            PositionPlayersAtStartPoints();

            //Hide all GUI
            skipButton.SetActive(false);
            countDownText.enabled = false;
        }

        IEnumerator RunFullGame()  //pregame match camera stuff
        {
            //Runs coroutines in sequence once
            yield return StartCoroutine(RunStartOfMatchCutscene());
            yield return StartCoroutine(MainGameLoop());
        }
        private IEnumerator RunStartOfMatchCutscene()
        {
            //Start far away and move toward the player at an angle blah blah blah
            //Pan the crowd blah blah blah
            //Zoom in on the king / lady / princess blah blah blah
            Debug.Log("Start of Match Cutscene!");

            //Skip setup
            var skippableTime = Time.time + unskippableDuration;

            //Activate the cutscene camera
            StartOfMatchCamera.SetActive(true);
            var camAnim = StartOfMatchCamera.GetComponent<Animation>();
            camAnim.Play();

            //Hide skip button
            skipButton.SetActive(false);

            //Check for escape
            while (true)
            {
                if (Time.time >= skippableTime)
                {
                    //Show skip button
                    skipButton.SetActive(true);

                    //User skip
                    if (XCI.GetButtonDown(XboxButton.Start) || Input.GetKeyDown(KeyCode.Space))
					{
						break;
					}
				}

                //Exit if animation is finished
                if (!camAnim.isPlaying)
                    break;

                yield return null;
            }

            //Turn everything off
            StartOfMatchCamera.SetActive(false);
            countDownText.enabled = false;
            skipButton.SetActive(false);

            Debug.LogError("End of match cutscene!");
        }

	#endregion

#region MAIN
        private IEnumerator MainGameLoop()
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
            if (GameSettings.Instance.MatchIsOver()) {
                SceneManager.LoadScene(2);     //Results screen scene
            }
            else {
                SceneManager.LoadScene(1, LoadSceneMode.Single);    //Main game scene
            }
        }

	#region Round Starting
        private IEnumerator StartRound()
        {
            onDisablePlayerCameras.Raise();
            onDisablePlayerMovement.Raise();

            //If it's the first round then run camera sequence
            if (GameSettings.Instance.Round == 1)
                yield return StartCoroutine(RunStartOfRoundCutscene());

            onEnablePlayerCameras.Raise();

            ///Start countdown
            yield return StartCoroutine(StartCountDown());
        }

        private IEnumerator RunStartOfRoundCutscene()
        {
            Debug.Log("Start Of Round Cutscene!");

            var skippableTime = Time.time + unskippableDuration;

			StartOfRoundCamera.SetActive(true);
            var camAnim = StartOfRoundCamera.GetComponent<Animation>();
            camAnim.Play();

            //Play cutscene all the way to the end
            while (camAnim.isPlaying)
            {
                yield return null;
            }

            //Start Round!
            onEnablePlayerCameras.Raise();
            StartOfRoundCamera.SetActive(false);

            Debug.Log("End Of Round Cutscene!");
        }

        private IEnumerator StartCountDown()
        {
            //Enable the countdown canvas
            // this.countDownText.SetActive(true);
            countDownText.enabled = true;

            //Get the countdown text (should only be one in canvas)
            // Text countDownText = countDownText.GetComponentInChildren<Text>();

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
				playerOne.root.position = startPoints[0].position;
                playerOne.root.rotation = startPoints[0].rotation;
            	playerTwo.root.position = startPoints[1].position;
                playerTwo.root.rotation = startPoints[1].rotation;
            }
            //Even numbered round
            else
            {
				playerOne.root.position = startPoints[1].position;
                playerOne.root.rotation = startPoints[1].rotation;
				playerTwo.root.position = startPoints[0].position;
                playerTwo.root.rotation = startPoints[0].rotation;
            }
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
            //Set text big etc
			countDownText.text = "GO!";
			countDownText.fontSize += 10;

			yield return new WaitForSecondsRealtime(showDuration);

			//Hide and disable the canvas
			countDownText.enabled = false;
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


        // playerOnePrefab.transform.position = startPoints[0].position;
        // playerTwoPrefab.transform.position = startPoints[1].position;
        // GameSettings.Players[0].SetPosition(startPoints[0].position);
        // GameSettings.Players[1].SetPosition(startPoints[1].position);
        // GameSettings.Instance.PlayerOne.SetPosition(startPoints[0].position);
        // GameSettings.Instance.PlayerTwo.SetPosition(startPoints[1].position);
        // playerOnePrefab.transform.position = startPoints[1].position;
        // playerTwoPrefab.transform.position = startPoints[0].position;
        // GameSettings.Instance.PlayerOne.SetPosition(startPoints[1].position);
        // GameSettings.Instance.PlayerTwo.SetPosition(startPoints[0].position);
        // StopCoroutine(PlayRound());


    //Automatically sets player's position based on even or odd round
    // var isOdd = GameSettings.Instance.Round % 2;
    // GameSettings.Players[isOdd % 2].SetPosition(startPoints[isOdd % 2].position);
    // GameSettings.Players[isOdd].SetPosition(startPoints[isOdd].position);