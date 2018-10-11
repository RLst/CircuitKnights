using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{
    public class MainMenuButton : MonoBehaviour
    {
        public GameObject MainMenu;

        public GameObject PlayerCameraOne;

        public GameObject PlayerCameraTwo;

        public GameObject CountDownCanvas;

        public Button PlayButton;

        public bool MenuActive = true;

        public bool PlayerCamerasActive = false;

        public bool CountDownActive = false;

        private void Start()
        {
            PlayButton.onClick.AddListener(PlayGame);
        }
       
        void PlayGame()
        {
            MenuActive = false;
            PlayerCamerasActive = true;
            CountDownActive = true;
        }

        void OnGUI()
        {
            if (MenuActive == true)
            {
                MainMenu.SetActive(true);
            }
            else if (MenuActive == false)
            {
                MainMenu.SetActive(false);
            }

            if (PlayerCamerasActive == true)
            {
                PlayerCameraOne.SetActive(true);
                PlayerCameraTwo.SetActive(true);
            }
            else if (PlayerCamerasActive == false)
            {
                PlayerCameraOne.SetActive(false);
                PlayerCameraTwo.SetActive(false);   
            }

            if (CountDownActive == true)
            {
                CountDownCanvas.SetActive(true);
            }
            else if (CountDownActive == false)
            {
                CountDownCanvas.SetActive(false);
            }
        }
    }
}
