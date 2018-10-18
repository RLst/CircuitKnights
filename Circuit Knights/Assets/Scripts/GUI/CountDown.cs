using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Jack Dawes and Tony Le
//5th of October, 2018

namespace CircuitKnights
{

    public class CountDown : MonoBehaviour
    {
        //Attach directly to the countdown text object?
        private Text countDownText;         //Don't need to be public

        public float countDownDuration = 3f;

        // Use this for initialization
        public void Start()
        {
            countDownText = GetComponent<Text>();
            //this.countDownLength = GameController.countDownLength;
        }


        // Update is called once per frame
        void Update()
        {
            if (countDownDuration >= -1f)
            {

                countDownDuration -= Time.deltaTime;

                countDownText.text = Mathf.Ceil(countDownDuration).ToString();
                if (countDownDuration <= 0.0f)
                {
                    countDownText.text = "GO!";
                    //Unfreeze game and play
                }
            }
            else
            {
                countDownText.enabled = false;
            }
        }
    }
}

