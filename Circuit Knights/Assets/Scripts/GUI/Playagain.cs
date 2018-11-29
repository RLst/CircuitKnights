using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playagain : MonoBehaviour {

    public string GameScene;
    public string MenuScene;


    public void PlayAgain()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }

}
