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
        [Multiline]
        [SerializeField]
        string description =
            "Monolithic class that controls the entirety of the main gameplay.";

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
        [SerializeField] Transform[] startPoints;
        [SerializeField] Transform[] endPoints;

        [Header("Events")]
        [SerializeField] GameEvent onEnablePlayerInput;
        [SerializeField] GameEvent onEnablePlayerMovement;
        [SerializeField] GameEvent onEnablePlayerCameras;
        [SerializeField] GameEvent onDisablePlayerInput;
        [SerializeField] GameEvent onDisablePlayerMovement;
        [SerializeField] GameEvent onDisablePlayerCameras;

        private bool roundIsRunning = false;


        #region Core
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

            Assert.IsNotNull(startPoints);
            Assert.IsNotNull(endPoints);
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

                yield return StartCoroutine(EndRound());
            }

            //Match is over, load results scene
            SceneManager.LoadScene(2);     //TODO Results screen scene

            //SceneManager.LoadScene(1, LoadSceneMode.Single);    //Main game scene
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

        #region Round Starting
        private void BeginNewRound()
        {
            //Initiate the round
            GameSettings.Instance.BeginNewRound();

            //Show round text
            roundText.enabled = true;
            roundText.text = "Round " + GameSettings.Instance.Round;
        }

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

        private void PositionPlayersAtStartPoints()
        {
            var p1 = GameSettings.Instance.PlayerOne;
            var p2 = GameSettings.Instance.PlayerTwo;

            //Odd numbered round
            if (GameSettings.Instance.Round % 2 == 1)
            {
                // playerOne.PlayerMover.
                // p1.SetPositionAndRotation(startPoints[0].position, startPoints[0].rotation);
                // p2.SetPositionAndRotation(startPoints[1].position, startPoints[1].rotation);
            }
            //Even numbered round
            else
            {
                // p1.SetPositionAndRotation(startPoints[1].position, startPoints[1].rotation);
                // p2.SetPositionAndRotation(startPoints[0].position, startPoints[0].rotation);
            }
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
            //Show the go text
            StartCoroutine(ShowGoText());

            //Start the round!
            onEnablePlayerMovement.Raise();
            onEnablePlayerInput.Raise();


            //// MAIN GAME LOOP ///
            roundIsRunning = true;
            while (roundIsRunning)
            {
                ////When does a round/pass end?
                // * When player's have passed each other ie. they're no longer facing each other (vector3.dot < 0)
                //[This also covers the case where if the players have made impact or not]
                CheckPlayersHavePassed();

                // * When a player has reached the end of the track
                //If the players have TriggerEnter'd the end of track colliders
                //Declare round is finished
                //(Triggered from a the reset trigger outside via a GameEvent)
                if (PlayersHaveReachedTheEnds(1f))
                    EndCurrentRound();

                yield return null;
            }
        }

        private void CheckPlayersHavePassed()
        {
            var p1 = GameSettings.Instance.PlayerOne;
            var p2 = GameSettings.Instance.PlayerTwo;
            var p1Facing = p1.Root.TransformDirection(Vector3.forward);
            var directionToP2 = Vector3.Normalize(p2.Root.position - p1.Root.position);
            if (Vector3.Dot(p1Facing, directionToP2) < 0f)
            {
                EndCurrentRound();
                // break;
                // Debug.Log("p1Facing: " + p1Facing);
                // Debug.Log("Dot product: " + Vector3.Dot(p1Facing, directionToP2));
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
            onDisablePlayerInput.Raise();

            CheckAndSetPlayersState();

            ///If the match is not over yet
            if (!GameSettings.Instance.isMatchOver)
            {
                //Disable player input (if applicable) and automatically move player to end points
                //Move players to their end points using PlayerMover.SetDesiredPosition();
                onDisablePlayerInput.Raise();
                // MovePlayersToEndPoints();

                //Move player around the loop ...once they have reached the ends
                // yield return new WaitUntil(() => PlayersHaveReachedTheEnds(1.5f));
                while (!PlayersHaveReachedTheEnds(1.5f))
                {
					yield return null;
				}

                yield return StartCoroutine(SwingPlayersAroundEndsOfTrack(1f));

                //STRECTH GOAL: If player's speed is above a certain number then ragdoll the player off the horse
                //(because he's obviously got too much momentum)

                //Show some kind of results or weapon select screen from the time of impact to the when the players both reached the new start positions

                //Once players have reached end points then "follow" the track around to the new start positions
                //Get the midpoint between the start and end, set this as the "pivot" point and rotate around it while
                //Stop player once they've reached the new start positions

                ////CONTINUE ONTO RESET AND START ROUND
            }
            //Else if there are still rounds left to play out
            // else if (false)
            // {
            // 	Debug.LogError("There are still rounds left to play out!");
            // }
            // //otherwise finish match and  sequences
            // else
            // {
            // 	Debug.LogError("Match Finished!");
            // 	//Slow motion cam looking at loser ragdolling off the horse
            // }

            ////WILL GO BACK TO StartRound() AGAIN...
        }

        private IEnumerator SwingPlayersAroundEndsOfTrack(float speed)
        {
            ////Players follows the track around to the next side

            //Automatically calculate useful and comprehensive variables to do work with
            int zeroIfEven, oneIfOdd;
            int zeroIfOdd, oneIfEven;
            zeroIfEven = oneIfOdd = GameSettings.Instance.Round % 2;   //0 if even, 1 if odd
            zeroIfOdd = oneIfEven = 1 - zeroIfEven;     //Odd: 1 - 1 = 0; Even: 1 - 0 = 1;
                                                        // Debug.Log("Round: " + GameSettings.Instance.Round + ", ZeroIfEven: " + zeroIfEven + ", ZeroIfOdd: " + zeroIfOdd);

            var radius = 1f;
            // var radius = ((startPoints[0].position + endPoints[0].position) / 2f).magnitude;	//MESSY!

            var p1MidPoint = ((startPoints[oneIfOdd].position + endPoints[zeroIfOdd].position) / 2f);
            var p2MidPoint = ((startPoints[zeroIfOdd].position + endPoints[oneIfOdd].position) / 2f);
            // var p1MidPoint = (startPoints[zeroIfOdd].position + endPoints[zeroIfOdd].position) / 2f;
            // var p2MidPoint = (startPoints[oneIfOdd].position + endPoints[zeroIfOdd].position) / 2f;

            for (float angle = 180f; angle > 0f; angle -= speed)
            {
                // Debug.Log("Angle: " + angle);
                ///Arch players around
                //Position
                var p1Offset = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad)) * radius;
                var p2Offset = new Vector3(Mathf.Sin((180f - angle) * Mathf.Deg2Rad), 0f, Mathf.Cos((180f - angle) * Mathf.Deg2Rad)) * radius;
                playerOne.Root.position = p1MidPoint + p1Offset;
                playerTwo.Root.position = p2MidPoint + p2Offset;
                // playerOne.Root.RotateAround(Vector3.zero, Vector3.up, angle);
                // playerTwo.Root.RotateAround(p2MidPoint, Vector3.up, angle);

                //Rotation
                playerOne.Root.Rotate(Vector3.up, angle * Mathf.Deg2Rad);
                playerTwo.Root.Rotate(Vector3.up, (180f - angle) * Mathf.Deg2Rad);

                yield return null;
            }
        }

        private bool PlayersHaveReachedTheEnds(float tolerance)
        {
            //Returns true if both players have reached their respective ends

            //Odd numbered rounds
            if (GameSettings.Instance.Round % 2 == 1)
            {
                //If both players have reached the end
                if (Vector3.Distance(playerOne.Root.position, endPoints[0].position) <= tolerance ||
                    Vector3.Distance(playerTwo.Root.position, endPoints[1].position) <= tolerance)
                {
                    return true;
                }
            }
            //Even numbered round
            else
            {
                if (Vector3.Distance(playerOne.Root.position, endPoints[1].position) <= tolerance ||
                    Vector3.Distance(playerTwo.Root.position, endPoints[0].position) <= tolerance)
                {
                    return true;
                }
            }
            return false;
        }

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

        void CheckAndSetPlayersState()
        {
            ////BETA CRUNCH (CRAP AND MESSY)
            //Maybe make the an array to hold the player references instead
            //Determine the state of the players
            var p1 = GameSettings.Instance.PlayerOne;
            var p2 = GameSettings.Instance.PlayerTwo;

            //Player ONE
            if (p1.isDead)
            {
                onPlayerDied(p1.No);
                GameSettings.Instance.SetMatchOver(true);
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
            if (p2.isDead)
            {
                onPlayerDied(p2.No);
                GameSettings.Instance.SetMatchOver(true);
            }

            if (p2.isHeadless)
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
