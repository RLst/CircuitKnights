using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Jack Dawes
//12th of October,2018

public class ResultsScreen : MonoBehaviour {

    [SerializeField] string LoadingScene = "Jack's Main";

    [SerializeField] GameObject ResultScreen;

    //public Button PlayAgainButton;

    [SerializeField] Button MainMenuButton;

    private void Start()
    {
        //PlayAgainButton.onClick.AddListener();
        MainMenuButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(LoadingScene);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ResultScreen.SetActive(true);
        }
	}
}
