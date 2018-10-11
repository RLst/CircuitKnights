using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{

    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;

        public Button ResumeButton;

        public Button MenuButton;

        bool Paused = false;

        MainMenuButton MainMenu;

        void Start()
        {
            ResumeButton.onClick.AddListener(ResumeGame);
            MenuButton.onClick.AddListener(ExitGame);
        }

        void ResumeGame()
        {
            Paused = false;
            Time.timeScale = 1f;
        }

        void ExitGame()
        {
            SceneManager.LoadScene("Jack's Main");
            Time.timeScale = 1f;
        }

        void Update()
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                 Paused = togglePause();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused = togglePause();
            }
        }

        void OnGUI()
        {
            if (Paused == true)
            {
                pauseMenu.SetActive(true);
            }

            if (Paused == false)
            {
                pauseMenu.SetActive(false);
            }

        }

        bool togglePause()
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                return(false);
            }
            else
            {
                Time.timeScale = 0f;
                return (true);
            }

        }
    }
}
