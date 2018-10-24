using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Jack Dawes
//10th of October, 2018

namespace CircuitKnights
{

    public class RematchButton : MonoBehaviour
    {
        [SerializeField] Button rematchButton1;

        [SerializeField] Button rematchButton2;

        [SerializeField] string LoadScene = "Jack's Main";

        
        void Start()
        {
            rematchButton1.onClick.AddListener(Rematch);
            rematchButton2.onClick.AddListener(Rematch);
        }

        void Rematch()
        {
            MainMenuButton.Rematch = true;
            ResultsScreen.ResultCameraActive = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(LoadScene);
        }
    }
}
