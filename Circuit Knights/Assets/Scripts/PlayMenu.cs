using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brent D'Auria
//5th of October, 2018

namespace CircuitKnights
{



    public class PlayMenu : MonoBehaviour
    {
        public void PlayGame ()
        {
            SceneManager.LoadScene("Brents_main");
        }
       
    }
}