//Tony Le
//6 Dec 2018

using System;
using System.Collections;
using CircuitKnights.Players;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

namespace CircuitKnights.Controllers
{
    public class Game : MonoBehaviour
    {
    #region Init stuff

		////Singleton

		////Players
        [SerializeField] Player p1;
        [SerializeField] Player p2;
        public Player P1 { get { return p1; } }
        public Player P2 { get { return p2; } }

		////Rounds
        [Range(1, 20)] [SerializeField] int noOfRounds;
        public int Round { get; set; }
        public int NoOfRounds { get { return noOfRounds; } }

		////Settings
        public bool isMatchOver { get; private set; }

		////Cutscenes
		[Tooltip("Duration after which you can skip cutscenes")] [SerializeField] float unskippableDuration = 3.0f;
		[SerializeField] GameObject StartOfMatchCamera;
		[SerializeField] GameObject StartOfRoundCamera;
		private bool cutscenePlaying;
        Animation cameraAnimation;
        // private bool playCutscene;
		bool skipCutscene = false;

		////Horse Arrival
		public float ArrivalDistance = 75f;
		public float ArrivalThreshold = 0.3f;
		public float ArrivalBrakingFineTuneFactor = 1.25f;

        [Header("GUI")]
        [SerializeField] Text roundText;
        [SerializeField] Text centerText;
		[SerializeField] GameObject skipButton;
        private bool isPlaying;
        private readonly int playerCount = 1;   //Just 2 players

        ////Other

        #endregion


        void Awake()
        {
            ////MORE OVERCOMPLICATIONS!
            // //Retrieve players using FindObject
            // var players = Resources.FindObjectsOfTypeAll(typeof(Player)) as Player[];
            // foreach (var player in players)
            // {
            //     if (player.No == Player.Number.One)
            //         P1 = player;
            //     else if (player.No == Player.Number.Two)
            //         P2 = player;
            //     else
            //         Debug.LogError("Invalid")
            // }
            //Verify that both players were found
        }


        void Start()
        {
            InitializeGame();

            //Run intro
            StartCoroutine(RunIntro());

            //Begin match
            BeginNewRound();
        }

        public static event Action<Player.Number, bool> OnSetPlayerInput = delegate {};
        public static event Action<Player.Number, bool> OnSetPlayerMovement = delegate {};
        public static event Action<Player.Number, bool> OnSetPlayerCamera = delegate {};

        private void InitializeGame()
        {
            Reset();

            //Disable movement and cameras, but let player move shield and lance for all players
            SetPlayersInput(true);
            SetPlayersMovement(false);
            SetPlayersCamera(false);

            //Hide all GUI
            roundText.enabled = false;
            centerText.enabled = false;
            skipButton.SetActive(false);
        }

        private IEnumerator RunIntro()
        {
            yield return StartCoroutine(RunCutscene(StartOfMatchCamera));
            yield return StartCoroutine(RunCutscene(StartOfRoundCamera, false));    //Can't be skipped
        }

        void Update()
        {
            if (isPlaying)
            {
                //
            }

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
            cutscenePlaying = true;
            while (cutscenePlaying)
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
                            cutscenePlaying = false;
                        }
                    }
                }

                //Exit if animation is finished
                if (!cameraAnimation.isPlaying)
                    cutscenePlaying = false;

                yield return null;
            }

            //Shutdown
            skipButton.SetActive(false);
            cutSceneCamera.SetActive(false);
        }


        private void BeginNewRound()
        {
            //Game settings
			Round++;
            isPlaying = true;

            //Enable player movement and cameras
            SetPlayersMovement(true);
            SetPlayersCamera(true);
            SetPlayersInput(true);
        }


        void SetPlayersMovement(bool enabled)
        {
            for (int i = 0; i < playerCount; i++)
            {
                OnSetPlayerMovement((Player.Number)i, enabled);
            }
        }
        void SetPlayersInput(bool enabled)
        {
            for (int i = 0; i < playerCount; i++)
            {
                OnSetPlayerInput((Player.Number)i, enabled);
            }
        }            
        void SetPlayersCamera(bool enabled)
        {
            for (int i = 0; i < playerCount; i++)
            {
                OnSetPlayerCamera((Player.Number)i, enabled);
            }
        }

        void Reset()
		{
			isMatchOver = false;
			Round = 0;
		}
    }
}