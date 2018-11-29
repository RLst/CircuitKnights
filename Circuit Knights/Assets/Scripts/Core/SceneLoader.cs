using UnityEngine;
using UnityEngine.SceneManagement;

//DuckBike

//Brent D'Auria
//5th of October, 2018

//Tony Le
//29 Nov 2018

namespace CircuitKnights
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] string sceneName;
        [SerializeField] int sceneNo;
        [SerializeField] LoadSceneMode loadSceneMode = LoadSceneMode.Single;

        public void LoadScene()
        //Loads the default scene
        {
            //Loads the string referenced scene first
            if (sceneName != "")
            {
                SceneManager.LoadScene(sceneName, loadSceneMode);
            }
            else //Otherwise loads scene number
            {
                SceneManager.LoadScene(sceneNo, loadSceneMode);
            }
        }

        // public void LoadScene(string sceneName, LoadSceneMode sceneMode)     //Load in single mode by default
        // {
        //     SceneManager.LoadScene(sceneName, sceneMode);
        // }

        // public void LoadScene(int sceneNo, LoadSceneMode sceneMode)
        // {
        //     SceneManager.LoadScene(sceneNo, sceneMode);
        // }
    }
}