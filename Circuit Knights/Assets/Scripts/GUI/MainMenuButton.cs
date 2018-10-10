using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{

    public class MainMenuButton : MonoBehaviour
    {
        public void MainMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
