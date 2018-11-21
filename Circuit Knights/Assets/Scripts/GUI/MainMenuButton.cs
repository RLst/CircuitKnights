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
        [SerializeField] GameObject MainMenu;

        [SerializeField] GameObject PlayerCameraOne;

        [SerializeField] GameObject PlayerCameraTwo;

        [SerializeField] GameObject CountDownCanvas;

        [SerializeField] GameObject SpinningCamera;

        [SerializeField] GameObject EventSystemOne;

        [SerializeField] Button PlayButton;

        bool MenuActive = true;

        bool CountDownActive = false;

        bool SpinCamera = true;

        public static bool Rematch = false;

        public static bool PlayerCamerasActive = false;
        
        private void Start()
        {
            MenuActive = true;
            CountDownActive = false;
            SpinCamera = true;
            PlayerCamerasActive = false;

            PlayButton.onClick.AddListener(PlayGame);
            if (Rematch)
            {
                PlayGame();
            }
        }
       
        public void PlayGame()
        {
            //MenuActive = false;
            //PlayerCamerasActive = true;
            //CountDownActive = true;
            Rematch = false;
            //SpinCamera = false;
            ResultsScreen.ResultCameraActive = false;
        }

        void Update()
        {



            if (MenuActive == true)
            {
                MainMenu.SetActive(true);
                EventSystemOne.SetActive(true);
                ResultsScreen.ResultCameraActive = false;
            }
            else if (MenuActive == false)
            {
                EventSystemOne.SetActive(false);
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

            if (SpinCamera == true)
            {
                SpinningCamera.SetActive(true);
            }
            else if (SpinCamera == false)
            {
                SpinningCamera.SetActive(false);
            }
        }
    }
}


