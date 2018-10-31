using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{

    public class PauseMenu : MonoBehaviour
    {
        ////Attached to GUI

        [SerializeField] GameObject pauseMenu;

        [SerializeField] string LoadScene = "Jack's Main";

        //[SerializeField] Button ResumeButton;

        //[SerializeField] Button MenuButton;

        bool isPaused = false;

        TimeController timeController;     //Used to disable the time controller when paused

        void Start()
        {
            timeController = GameObject.FindObjectOfType<TimeController>();
            //ResumeButton.onClick.AddListener(ResumeGame);
            //MenuButton.onClick.AddListener(ExitGame);
        }
        void Update()
        {        
            ////Handle Pause    
            //Any controller...
            if (XCI.GetButtonDown(XboxButton.Start) ||
                Input.GetButtonDown("Cancel"))
            {
                TogglePause();
            }
        }


        private void TogglePause()
        {
            //Pause the game
            if (Time.timeScale >= 1f)
            {
                Time.timeScale = 0f;
                timeController.enabled = false;     //Prevent time from slowly reverted back to normal
                pauseMenu.SetActive(true);          //GUI
            }
            //Unpause
            else if (Time.timeScale <= 0f)
            {
                Time.timeScale = 1f;                //Unpause time
                timeController.enabled = true;      //Reenabled slow motion effects
                pauseMenu.SetActive(false);         //Hide pause menu
            }
        }

        public void ResumeGame()
        {
            TogglePause();
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(LoadScene);
            Time.timeScale = 1f;
        }
    }
}
