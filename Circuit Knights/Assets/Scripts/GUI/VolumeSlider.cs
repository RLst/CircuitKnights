using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


namespace CircuitKnights
{
    public class VolumeSlider : MonoBehaviour
    {
        public Slider inGameUISlider;
        //public AudioListener listen;

        private void Start()
        {
            ChangeVolume();
        }

        public void ChangeVolume()
        {
            //AudioListener.volume = inGameUISlider.value;
        }
    }
}