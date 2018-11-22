using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Jack Dawes
//12th of October,2018

namespace CircuitKnights
{
    public class ResultsScreen : MonoBehaviour {

        [SerializeField] string LoadingScene = "Jack's Main";

        [SerializeField] GameObject ResultScreen;

        [SerializeField] GameObject ResultCamera;

        [SerializeField] Button MenuButton;

        private int PlayerOneScore = 0;

        private int PlayerTwoScore = 0;

        public static bool ResultCameraActive = false;

        private void Start()
        {
            MenuButton.onClick.AddListener(LoadScene);
        }

        void LoadScene()
        {
            ResultCamera.SetActive(false);
            SceneManager.LoadScene(LoadingScene);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.V))
            {
                ResultScreen.SetActive(true);
                //MainMenuButton.PlayerCamerasActive = false;
                ResultCameraActive = true;
            }

            if (ResultCameraActive == true)
            {
                ResultCamera.SetActive(true);
            }
            else if (ResultCameraActive == false)
            {
                ResultCamera.SetActive(false);
            }

            if (PlayerOneScore > PlayerTwoScore)
            {
                //Display 'Win' for Player One and 'Lose' for Player Two 
            }
            else if (PlayerOneScore < PlayerTwoScore)
            {
                //Display 'Win' for Player Two and 'Lose' for Player One
            }
            else if (PlayerOneScore == PlayerTwoScore)
            {
                //Display 'Draw' for both Players
            }

        }
    }
}
