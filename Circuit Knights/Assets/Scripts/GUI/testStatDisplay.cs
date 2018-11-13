using UnityEngine;
using UnityEngine.UI;
using CircuitKnights;
using CircuitKnights.Objects;

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
            headOne.text = "HeadHP: " + playerOne.HeadHP.ToString();
            torsoOne.text = "TorsoHP: " + playerOne.TorsoHP.ToString();
            leftArmOne.text = "LeftArmHP: " + playerOne.LeftArmHP.ToString();
            rightArmOne.text = "RightArmHP: " + playerOne.RightArmHP.ToString();
            shieldOne.text = "ShieldHP: " + playerOne.ShieldData.HP.ToString();

            headTwo.text = "HeadHP: " + playerTwo.HeadHP.ToString();
            torsoTwo.text = "TorsoHP: " + playerTwo.TorsoHP.ToString();
            leftArmTwo.text = "LeftArmHP: " + playerTwo.LeftArmHP.ToString();
            rightArmTwo.text = "RightArmHP: " + playerTwo.RightArmHP.ToString();
            shieldTwo.text = "ShieldHP: " + playerTwo.ShieldData.HP.ToString();
        }
    }

}