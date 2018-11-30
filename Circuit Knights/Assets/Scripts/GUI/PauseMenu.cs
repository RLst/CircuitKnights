using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;
using CircuitKnights.Controllers;

//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{

    public class PauseMenu : MonoBehaviour
    {
        ////Attached to GUI

        [SerializeField] GameObject pauseMenu;

        [SerializeField] string LoadMenuScene = "Jack's Menu";

        [SerializeField] string LoadMainScene = "Jack's Main";

        [SerializeField] Button ResumeButton;

        [SerializeField] Button RestartButton;

        [SerializeField] Button MenuButton;

        //bool isPaused = false;

        SlowMotionController SlowMotionController;     //Used to disable the time controller when paused

        void Start()
        {
            SlowMotionController = GameObject.FindObjectOfType<SlowMotionController>();
            ResumeButton.onClick.AddListener(ResumeGame);
            RestartButton.onClick.AddListener(RestartGame);
            MenuButton.onClick.AddListener(ExitGame);
        }
        void Update()
        {        
            ////Handle Pause    
            //Any controller...
            if (XCI.GetButtonDown(XboxButton.Start, XboxController.First) || XCI.GetButtonDown(XboxButton.Start, XboxController.Second) || Input.GetButtonDown("Cancel"))
            {
                TogglePause();
            }
        }


        public void TogglePause()
        {
            //Pause the game
            if (Time.timeScale >= 1f)
            {
                pauseMenu.SetActive(true);          //GUI
                Time.timeScale = 0f;
                SlowMotionController.enabled = false;     //Prevent time from slowly reverted back to normal
            }
            //Unpause
            else if (Time.timeScale <= 0f)
            {
                pauseMenu.SetActive(false);         //Hide pause menu
                Time.timeScale = 1f;                //Unpause time
                SlowMotionController.enabled = true;      //Reenabled slow motion effects
            }
        }

        public void ResumeGame()
        {
            TogglePause();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(LoadMainScene);
            Time.timeScale = 1f;
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(LoadMenuScene);
            Time.timeScale = 1f;
        }
    }
}
