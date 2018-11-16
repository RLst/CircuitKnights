using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brent D'Auria
//5th of October, 2018

namespace CircuitKnights
{

//     public class PlayMenu : MonoBehaviour
//     {

//         [SerializeField] string loadScene;

//         public void PlayGame ()
//         { 
//             SceneManager.LoadScene(loadScene);
//         }
       
//     }
// }

     public class PlayMenu : MonoBehaviour
     {

         [SerializeField] string loadScene;

         public void PlayGame ()
         { 
             Debug.Log(loadScene);
             SceneManager.LoadScene(loadScene);
         }
       
     }
 }