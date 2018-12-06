using System;
using System.Collections;
using System.Collections.Generic;
using CircuitKnights.Players;
using UnityEngine;

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
        // private bool playCutscene;
		bool skipCutscene = false;

		////Horse Arrival
		public float ArrivalDistance = 75f;
		public float ArrivalThreshold = 0.3f;
		public float ArrivalBrakingFineTuneFactor = 1.25f;

		////GUI
		[SerializeField] GameObject skipButton;

		////Other

        #endregion




        void Start()
        {
			Reset();
			cutscenePlaying = false;
        }

        void Update()
        {
			//Run start of match cutscene
			if (Round == 0)
			{
				skipCutscene = false;
            	// cutscenePlaying = RunCutscene();
			}

            //Begin the match
            BeginNewRound();

            //Run start of round cutscene


        }

        // private bool RunCutscene(GameObject cutSceneCamera, bool skippable = true)
        // {
        //     //Note: Camera must be setup in legacy mode with an animation (NOT ANIMATOR)

        //     ///Initialise
        //     skipButton.SetActive(false);
        //     var cameraAnimation = cutSceneCamera.GetComponent<Animation>();

        //     //Set up skipabilitiy
        //     var skippableTime = Time.time + unskippableDuration;

        //     //Set up camera
        //     cutSceneCamera.SetActive(true);

        //     //Play the camera
        //     cameraAnimation.Play();

		// 	//Stop cutscene

        //     playCutscene = true;
        //     while (playCutscene)
        //     {
        //         if (skippable)
        //         {
        //             if (Time.time >= skippableTime)
        //             {
        //                 //Show skip button
        //                 skipButton.SetActive(true);

        //                 //Manual skip
        //                 if (XCI.GetButtonDown(XboxButton.A, XboxController.First) ||
        //                     XCI.GetButtonDown(XboxButton.A, XboxController.Second) ||
        //                     Input.GetKeyDown(KeyCode.Space))
        //                 {
        //                     playCutscene = false;
        //                 }
        //             }
        //         }

        //         //Exit if animation is finished
        //         if (!cameraAnimation.isPlaying)
        //             playCutscene = false;

        //         // yield return null;
        //     }

        //     //Shutdown
        //     skipButton.SetActive(false);
        //     cutSceneCamera.SetActive(false);
        // }

        private void BeginNewRound()
        {
			Round++;
        }

        void Reset()
		{
			isMatchOver = false;
			Round = 0;
		}
    }
}