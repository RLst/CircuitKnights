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
        //[Multiline]
        //[SerializeField]
        //string description =
        //    "Monolithic class that controls the entirety of the main gameplay.";

        #region Player References
        PlayerData playerOne;
        PlayerData playerTwo;
        #endregion

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
        private bool playCutscene = false;      //Flag to control running of cutscene


        [Header("Positions")]
        public Transform[] StartPoints;
        public Transform[] EndPoints;

        [Header("Events")]
        [SerializeField] GameEvent onStartNextPass;
        [SerializeField] GameEvent onEnablePlayerInput;
        [SerializeField] GameEvent onEnablePlayerMovement;
        [SerializeField] GameEvent onEnablePlayerCameras;
        [SerializeField] GameEvent onDisablePlayerInput;
        [SerializeField] GameEvent onDisablePlayerMovement;
        [SerializeField] GameEvent onDisablePlayerCameras;
        // public static event Action<PlayerData.PlayerNumber> onPlayerDied = delegate { };     //Torso death()
        // public static event Action<PlayerData.PlayerNumber> onPlayerHeadKnockedOff = delegate { };   //Head death()
        // public static event Action<PlayerData.PlayerNumber> onPlayerLeftArmKnockedOff = delegate { };
        // public static event Action<PlayerData.PlayerNumber> onPlayerRightArmKnockedOff = delegate { };
        // public static event Action<PlayerData.PlayerNumber> onPlayerShieldDestroyed = delegate { };


        ////REALLY BAD CODE :P
        int playersThatHaveReachedTheEnds = 0;
        private bool roundIsRunning = false;


        #region Core        
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

            while (!GameSettings.Instance.isMatchOver)
            {
                BeginNewRound();

                yield return StartCoroutine(StartRound());

                yield return StartCoroutine(PlayRound());

                EndRound();
                // yield return StartCoroutine(EndRound());
            }

            ////Match is over, load the correct scene based on the result
            var p1 = GameSettings.Instance.PlayerOne;
            var p2 = GameSettings.Instance.PlayerTwo;

            //Draw
            if (p1.isDead && p2.isDead)
            {
                SceneManager.LoadScene(2);     //TODO Results screen scene
            }
            //Player One Wins
            else if (p2.isDead)
            {
                SceneManager.LoadScene(3);
            }
            //Player Two Wins
            else if (p1.isDead)
            {
                SceneManager.LoadScene(4);
            }

            ////END OF GAME
        }
        private void BeginNewRound()
        {
            //Initiate the round
            GameSettings.Instance.BeginNewRound();

            //Show round text
            roundText.enabled = true;
            roundText.text = "Round " + GameSettings.Instance.Round;
        }
        private void Assertions()
        {
            //Make sure all necessasy components are passed
            Assert.IsNotNull(roundText);
            Assert.IsNotNull(centerText);
            Assert.IsNotNull(skipButton);

            Assert.IsNotNull(onEnablePlayerInput);
            Assert.IsNotNull(onEnablePlayerMovement);
            Assert.IsNotNull(onEnablePlayerCameras);
            Assert.IsNotNull(onDisablePlayerInput);
            Assert.IsNotNull(onDisablePlayerCameras);
            Assert.IsNotNull(onDisablePlayerMovement);

            Assert.IsNotNull(StartOfMatchCamera);
            Assert.IsNotNull(StartOfRoundCamera);

            Assert.IsNotNull(StartPoints);
            Assert.IsNotNull(EndPoints);
        }
        private void InitGame()
        {
            //General reset
            GameSettings.Instance.Reset();

            //Players
            playerOne = GameSettings.Instance.PlayerOne;
            playerTwo = GameSettings.Instance.PlayerTwo;

            //Disable everything by default
            // onDisablePlayerInput.Raise();
            onDisablePlayerMovement.Raise();
            onDisablePlayerCameras.Raise();

            //Hide all GUI
            roundText.enabled = false;
            centerText.enabled = false;
            skipButton.SetActive(false);
        }
        #endregion  //Core

        #region Round Starting
        private IEnumerator StartRound()
        {
            //Initialise
            // PositionPlayersAtStartPoints();
            onDisablePlayerCameras.Raise();

            //Only run cutscene on the first round
            if (GameSettings.Instance.Round == 1)
                yield return StartCoroutine(RunCutscene(StartOfRoundCamera, false));

            //Continue straight to playing game after count down
            onEnablePlayerCameras.Raise();
            yield return StartCoroutine(StartCountDown());
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
        #endregion

        #region Round Playing
        private IEnumerator PlayRound()
        {
            //Start the round!
            onEnablePlayerMovement.Raise();
            onEnablePlayerInput.Raise();
            onStartNextPass.Raise();
            //Show the go text
            StartCoroutine(ShowGoText());

            //// PLAY ROUND LOOP ////
            //Resets
            playersThatHaveReachedTheEnds = 0;
            roundIsRunning = true;

            while (roundIsRunning)
            {
                ////Wait until both players are have finished their passes
                if (playersThatHaveReachedTheEnds == 2)
                    EndCurrentRound();  //End current round once both players have hit the end

                ////Swing and a miss situation
                // if (CheckPlayersHavePassed )

                yield return null;
            }
            //// PLAY ROUND LOOP ////

            ////GOES TO EndRound()
        }

        private bool CheckPlayersHavePassed()
        {
            var p1 = GameSettings.Instance.PlayerOne;
            var p2 = GameSettings.Instance.PlayerTwo;
            var p1Facing = p1.Root.TransformDirection(Vector3.forward);
            var directionToP2 = Vector3.Normalize(p2.Root.position - p1.Root.position);
            if (Vector3.Dot(p1Facing, directionToP2) < 0f)
            {
                return true;    //Players have passed
            }
            return false;   //Players have not passed yet
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

        private void EndRound()
        {
            onDisablePlayerInput.Raise();

            CheckAndSetIfMatchIsOver();

            ///If the match is not over yet
            if (!GameSettings.Instance.isMatchOver)
            {
                onDisablePlayerInput.Raise();
            }
        }

        void CheckAndSetIfMatchIsOver()
        {
            ////BETA CRUNCH (CRAP AND MESSY)
            //Maybe make the an array to hold the player references instead
            //Determine the state of the players
            var p1 = GameSettings.Instance.PlayerOne;
            var p2 = GameSettings.Instance.PlayerTwo;

            //Set match to over if one of the players have died
            if (p1.isDead || p2.isDead)
            {
                GameSettings.Instance.SetMatchOver(true);
            }
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
        public void OnPlayerReachedTheEnd()
        {
            playersThatHaveReachedTheEnds++;
        }
        #endregion

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
                        if (XCI.GetButtonDown(XboxButton.A, XboxController.First) ||
                            XCI.GetButtonDown(XboxButton.A, XboxController.Second) ||
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
    }
}












        // private bool PlayersHaveReachedTheEnds(float tolerance)
        // {
        //     //Returns true if both players have reached their respective ends

        //     //Odd numbered rounds
        //     if (GameSettings.Instance.Round % 2 == 1)
        //     {
        //         //If both players have reached the end
        //         if (Vector3.Distance(playerOne.Root.position, EndPoints[0].position) <= tolerance ||
        //             Vector3.Distance(playerTwo.Root.position, EndPoints[1].position) <= tolerance)
        //         {
        //             return true;
        //         }
        //     }
        //     //Even numbered round
        //     else
        //     {
        //         if (Vector3.Distance(playerOne.Root.position, EndPoints[1].position) <= tolerance ||
        //             Vector3.Distance(playerTwo.Root.position, EndPoints[0].position) <= tolerance)
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }

//Automatically sets player's position based on even or odd round
// var isOdd = GameSettings.Instance.Round % 2;
// GameSettings.Players[isOdd % 2].SetPosition(startPoints[isOdd % 2].position);
// GameSettings.Players[isOdd].SetPosition(startPoints[isOdd].position);

/*
PSEUDOCODE: SEQUENCE OF EVENTS
Round = 0

If it’s before the round has begun(Round = 0) then run match cutscene

BeginNewRound
	Increment the round number

StartRound
	PositionPlayersAtStartPoints
	DisablePlayerCameras
	DisablePlayerMovement

	If its the first round (Round = 1) then run round cutscene

	Enable player cameras after the cutscene has ran

	Start countdown

PlayRound
	Show the go text
	enable player movement
	enable player controls

	while the round is running
		check the players have passed
			if so then end round


EndRound
	Check the status of the players
		If one of them has died then set match to over

	if the match is not over
		move players to the end points

		when they have reached the end point
			loop around to the next starting points
			break out and start a new round
	else if the matc

	else match is over

*/


// private void MovePlayersToEndPoints()
// {
//     Debug.Log("Players moving to end points");
//     var p1 = GameSettings.Instance.PlayerOne;
//     var p2 = GameSettings.Instance.PlayerTwo;

//     //Odd numbered round
//     if (GameSettings.Instance.Round % 2 == 1)
//     {
//         p1.SetPositionAndRotation(endPoints[0].position, endPoints[0].rotation);
//         p2.SetPositionAndRotation(endPoints[1].position, endPoints[1].rotation);
//         // p1.PlayerMover.SetDesiredPosition(endPoints[0].position);
//         // p2.PlayerMover.SetDesiredPosition(endPoints[1].position);
//     }
//     //Even numbered round
//     else
//     {
//         p1.SetPositionAndRotation(endPoints[1].position, endPoints[1].rotation);
//         p2.SetPositionAndRotation(endPoints[0].position, endPoints[0].rotation);
//         // p1.PlayerMover.SetDesiredPosition(endPoints[1].position);
//         // p2.PlayerMover.SetDesiredPosition(endPoints[0].position);
//     }
// }