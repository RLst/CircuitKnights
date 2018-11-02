using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

namespace CircuitKnights
{
    public class TestBuildReset : MonoBehaviour
    {
        private void Update()
        {
            if (XCI.GetButtonDown(XboxButton.Back))
            {
                //MainMenuButton.Play
                //SceneManager.LoadScene("Main");
            }
        }

    }
}
