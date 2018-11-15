using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Brent D'Auria
public class Playagain : MonoBehaviour {

    public string GameScene;
    public string MenueScene;


    public void PlayAgain()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(MenueScene);
    }

}
