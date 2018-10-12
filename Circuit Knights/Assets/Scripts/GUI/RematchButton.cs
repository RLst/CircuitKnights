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
        public Button rematchButton1;

        public Button rematchButton2;

        public string LoadScene = "Jack's Main";

        
        void Start()
        {
            rematchButton1.onClick.AddListener(Rematch);
            rematchButton2.onClick.AddListener(Rematch);
        }

        void Rematch()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(LoadScene);
        }
    }
}
