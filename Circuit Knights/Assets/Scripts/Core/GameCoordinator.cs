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

        // [Header("Players")]
        // [SerializeField] Player playerOne;
        // [SerializeField] Player playerTwo;

        [Header("GUI")]
        [SerializeField] Text roundNoText;
        [SerializeField] Text centerText;
        [SerializeField] GameObject skipButton;       //Has to be a gameobject because skipbutton wont hide

        [Header("Count Down")]
        [SerializeField] int countDownTextSize = 60;
        [Tooltip("Realtime seconds")][SerializeField] int countDownDuration = 3;

        [Header("Go!")]
        [SerializeField] int goTextSize = 150;
        [SerializeField] float goTextShowDuration = 1.5f;


        [Header("Cutscenes")]
        [Tooltip("Duration after which you can skip cutscenes")][SerializeField] float unskippableDuration = 3.0f;
		[SerializeField] GameObject StartOfMatchCamera;         //General pan around cinematically etc etc
        [SerializeField] GameObject StartOfRoundCamera;		    //Pan around each of the players
        private bool playCutscene;      //Flag to control running of cutscene


		[Header("Positions")]
        [SerializeField] Transform[] startPoints;
        [SerializeField] Transform[] endPoints;

        [Header("Events")]
        [SerializeField] GameEvent onEnablePlayerCameras;
        [SerializeField] GameEvent onDisablePlayerCameras;
        [SerializeField] GameEvent onEnablePlayerMovement;
        [SerializeField] GameEvent onDisablePlayerMovement;


        private void Assertions()
        {
            //Make sure all necessasy components are passed
            Assert.IsNotNull(roundNoText);
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
            roundNoText.enabled = false;
            centerText.enabled = false;
            skipButton.SetActive(false);

            //Setup listener to skip button
            skipButton.gameObject.GetComponent<Button>().onClick.AddListener(OnSkip);
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
            //Initiate the round
            GameSettings.Instance.BeginNewRound();
            
            yield return StartCoroutine(StartRound());

            yield return StartCoroutine(PlayRound());

            yield return StartCoroutine(EndRound());

            ///Declare winner; Switch scenes based on results
            if (GameSettings.Instance.MatchIsOver())
                SceneManager.LoadScene(2);     //Results screen scene
            else
                SceneManager.LoadScene(1, LoadSceneMode.Single);    //Main game scene
        }

        private IEnumerator StartRound()
        {
            //Initialise
            onDisablePlayerCameras.Raise();
            onDisablePlayerMovement.Raise();

            //Only run on the first round
            if (GameSettings.Instance.Round == 1)
                yield return StartCoroutine(RunCutscene(StartOfRoundCamera, false));

            //Continue straight to playing game after count down
            onEnablePlayerCameras.Raise();
            yield return StartCoroutine(StartCountDown());
        }

        private IEnumerator PlayRound()
        {
            //Show the go text
            StartCoroutine(ShowGoText());

            onEnablePlayerMovement.Raise();

            while (true)
            {
                //Gameplay

                ////When does a round/pass end?
                //1. When player's have passed each other (vector3.dot < 0)
                //2. When a player's lance has collided with the opponent
                //3. When a player has reached the end of the track

                yield return null;
            }
        }

        private IEnumerator EndRound()
        {
            throw new NotImplementedException();
        }

    #region Cutscenes
        private IEnumerator RunStartOfMatchCutscene()
        {
            //Initialise
            centerText.enabled = false;
            roundNoText.enabled = false;
            StartOfMatchCamera.SetActive(true);
            var skippableTime = Time.time + unskippableDuration;
            var cameraAnimation = StartOfMatchCamera.GetComponent<Animation>();
            cameraAnimation.Play();

            //Make sure to hide skip button
            skipButton.SetActive(false);

            playCutscene = true;
            while (playCutscene)
            {
                if (Time.time >= skippableTime)
                {
                    //Show skip button
                    skipButton.SetActive(true);

                    //User skip
                    if (XCI.GetButtonDown(XboxButton.Start) ||
                        Input.GetKeyDown(KeyCode.Space))
                    {
                        playCutscene = false;
                    }
                }

                //Exit if animation is finished
                if (!cameraAnimation.isPlaying)
                    playCutscene = false;

                yield return null;
            }

            //Shutdown
            StartOfMatchCamera.SetActive(false);
            skipButton.SetActive(false);
        }

        private IEnumerator RunStartOfRoundCutscene()
        {
            //Initialise
            var skippableTime = Time.time + unskippableDuration;
            StartOfRoundCamera.SetActive(true);
            var camAnim = StartOfRoundCamera.GetComponent<Animation>();
            camAnim.Play();

            //Play cutscene all the way to the end
            while (camAnim.isPlaying)
            {
                yield return null;
            }

            //Shutdown
            StartOfRoundCamera.SetActive(false);
        }

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
            // centerText.enabled = false;
        }

        private void PositionPlayersAtStartPoints()
        {
            var p1root = GameSettings.Instance.PlayerOne.Root;
            var p2root = GameSettings.Instance.PlayerTwo.Root;

            //Odd numbered round
            if (GameSettings.Instance.Round % 2 == 1)
            {
				p1root.position = startPoints[0].position;
                p1root.rotation = startPoints[0].rotation;
                p1root.position = startPoints[1].position;
                p1root.rotation = startPoints[1].rotation;
            }
            //Even numbered round
            else
            {
                p2root.position = startPoints[1].position;
                p2root.rotation = startPoints[1].rotation;
                p2root.position = startPoints[0].position;
                p2root.rotation = startPoints[0].rotation;
            }
        }
	#endregion

	#region Round Playing
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

    #endregion

    #region Other Functions
        public void OnSkip()
        {
            //This function is to allow for externals such as buttons to skip scenes etc
            playCutscene = false;
        }
    #endregion
    }
}
    //Automatically sets player's position based on even or odd round
    // var isOdd = GameSettings.Instance.Round % 2;
    // GameSettings.Players[isOdd % 2].SetPosition(startPoints[isOdd % 2].position);
    // GameSettings.Players[isOdd].SetPosition(startPoints[isOdd].position);