using UnityEngine;
using UnityEngine.UI;
using CircuitKnights.Variables;

//Jack Dawes and Tony Le
//5th of October, 2018

namespace CircuitKnights
{

	public class CountDown : MonoBehaviour
    {
        //Attach directly to the countdown text object?
        private Text thisText;         //Don't need to be public

        [SerializeField] FloatReference countDownDuration;

        // Use this for initialization
        public void Start()
        {
            thisText = GetComponent<Text>();
            //this.countDownLength = GameController.countDownLength;
        }


        // Update is called once per frame
        void Update()
        {
            if (countDownDuration.Value >= -1f)
            {
                countDownDuration.Value -= Time.deltaTime;

                thisText.text = Mathf.Ceil(countDownDuration.Value).ToString();
                if (countDownDuration <= 0.0f)
                {
                    thisText.text = "GO!";
                    //Unfreeze game and play
                }
            }
            else
            {
                thisText.enabled = false;
                this.enabled = false;       //Also disable this script
            }
        }
    }
}

