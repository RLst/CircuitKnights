using UnityEngine;
using UnityEngine.UI;
using CircuitKnights;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights.Tests
{
    public class testStatDisplay : MonoBehaviour 
	{
        public PlayerData playerOne;
        public PlayerData playerTwo;

		[Header("Player 1")]
        public Text headOne;
        public Text torsoOne;
        public Text leftArmOne;
        public Text rightArmOne;
        public Text shieldOne;

        [Header("Player 2")]
        public Text headTwo;
        public Text torsoTwo;
        public Text leftArmTwo;
        public Text rightArmTwo;
		public Text shieldTwo;


		void Start()
		{
            playerOne = GameSettings.Instance.PlayerOne;
            playerTwo = GameSettings.Instance.PlayerTwo;
        }

        void Update()
		{

            headOne.text = "HeadHP: " + (int)playerOne.HeadHP;
            torsoOne.text = "TorsoHP: " + (int)playerOne.TorsoHP;
            leftArmOne.text = "LeftArmHP: " + (int)playerOne.LeftArmHP;
            rightArmOne.text = "RightArmHP: " + (int)playerOne.RightArmHP;
            shieldOne.text = "ShieldHP: " + (int)playerOne.ShieldData.HP;

            headTwo.text = "HeadHP: " + (int)playerTwo.HeadHP;
            torsoTwo.text = "TorsoHP: " + (int)playerTwo.TorsoHP;
            leftArmTwo.text = "LeftArmHP: " + (int)playerTwo.LeftArmHP;
            rightArmTwo.text = "RightArmHP: " + (int)playerTwo.RightArmHP;
            shieldTwo.text = "ShieldHP: " + (int)playerTwo.ShieldData.HP;
        }
    }

}