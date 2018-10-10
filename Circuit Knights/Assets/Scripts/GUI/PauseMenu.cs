using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{

    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;

        bool Paused = false;

        void Update()
        {
            if (Input.GetKeyDown("joystick button 7"))
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
