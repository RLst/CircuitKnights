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

        [SerializeField] string LoadMenuScene = "Jack's Menu";

        [SerializeField] string LoadMainScene = "Jack's Main";

        //[SerializeField] Button ResumeButton;

        //[SerializeField] Button MenuButton;

        bool isPaused = false;

        SlowMotionController SlowMotionController;     //Used to disable the time controller when paused

        void Start()
        {
            SlowMotionController = GameObject.FindObjectOfType<SlowMotionController>();
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


        public void TogglePause()
        {
            //Pause the game
            if (Time.timeScale >= 1f)
            {
                Time.timeScale = 0f;
                SlowMotionController.enabled = false;     //Prevent time from slowly reverted back to normal
                pauseMenu.SetActive(true);          //GUI
            }
            //Unpause
            else if (Time.timeScale <= 0f)
            {
                Time.timeScale = 1f;                //Unpause time
                SlowMotionController.enabled = true;      //Reenabled slow motion effects
                pauseMenu.SetActive(false);         //Hide pause menu
            }
        }

        public void ResumeGame()
        {
            TogglePause();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(LoadMainScene);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(LoadMenuScene);
            Time.timeScale = 1f;
        }
    }
}
