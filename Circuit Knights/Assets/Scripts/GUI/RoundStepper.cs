using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Jack Dawes
//25th of October, 2018

namespace CircuitKnights
{
    public class RoundStepper : MonoBehaviour
    {
        [SerializeField] int NumberOfRounds = 5;

        [SerializeField] int MinimumRounds = 1;

        [SerializeField] int MaximumRounds = 10;

        [SerializeField] int StepIntervals = 1;

        [SerializeField] Button IncrementButton;

        [SerializeField] Button DecrementButton;

        [SerializeField] Text RoundDisplay;

        private void Start()
        {
            IncrementButton.onClick.AddListener(Increment);
            DecrementButton.onClick.AddListener(Decrement);
        }

        void Update()
        {
            RoundDisplay.text = Mathf.Ceil(NumberOfRounds).ToString();

            if (NumberOfRounds < MinimumRounds)
            {
                NumberOfRounds = MaximumRounds;
            }
            else if (NumberOfRounds > MaximumRounds)
            {
                NumberOfRounds = MinimumRounds;
            }
        }

        void Increment()
        {
            NumberOfRounds += StepIntervals;
        }

        void Decrement()
        {
            NumberOfRounds -= StepIntervals;
        }

    }
}
