using UnityEngine;
using UnityEngine.UI;
using CircuitKnights.Players;

namespace CircuitKnights.UI
{
    public class HUD : MonoBehaviour 
	{
        public Player playerOne;
        public Player playerTwo;

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

            headOne.text = "Head: " + (int)playerOne.HeadHP;
            torsoOne.text = "Torso: " + (int)playerOne.TorsoHP;
            leftArmOne.text = "LeftArm: " + (int)playerOne.LeftArmHP;
            rightArmOne.text = "RightArm: " + (int)playerOne.RightArmHP;
            shieldOne.text = "Shield: " + (int)playerOne.Shield.HP;

            headTwo.text = "Head: " + (int)playerTwo.HeadHP;
            torsoTwo.text = "Torso: " + (int)playerTwo.TorsoHP;
            leftArmTwo.text = "LeftArm: " + (int)playerTwo.LeftArmHP;
            rightArmTwo.text = "RightArm: " + (int)playerTwo.RightArmHP;
            shieldTwo.text = "Shield: " + (int)playerTwo.Shield.HP;
        }
    }

}