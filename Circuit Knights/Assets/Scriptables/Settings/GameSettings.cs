//Duckbike
//Tony Le
//26 Oct 2018

using CircuitKnights.Players;
using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights
{
    [CreateAssetMenu(fileName = "New Game Settings", menuName = "Game Settings", order = 32)]
    public class GameSettings : MonoBehaviour
    {
        //[Multiline] [SerializeField] string description = "Holds the game settings";

        #region Singleton
        public static GameSettings Instance { get; private set; }
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else 
                Destroy(gameObject);

            Reset();
        }
        #endregion

        #region Players
        public Player PlayerOne;
        public Player PlayerTwo;

        // public PlayerData[] Players { get; set; }
        #endregion

        #region Game Settings
        [Range(1, 10)] [SerializeField] int noOfRounds;
        public int Round { get; set; }
        public int NoOfRounds { get { return noOfRounds; } }
        public bool isMatchOver { get; private set; }

		[Header("Horse Arrival")]
		public float ArrivalDistance = 75f;
		public float ArrivalThreshold = 0.3f;
		public float ArrivalBrakingFineTuneFactor = 1.25f;

        [SerializeField] BoolVariable gamepadVibrationOn;
        public BoolVariable isVibrationOn { get { return gamepadVibrationOn; } }
		#endregion

		////DIRTY
		internal void SetMatchOver(bool isMatchOver)
		{
			this.isMatchOver = isMatchOver;
		}

		////DIRTY
		internal bool isDraw()
		{
			if (PlayerOne.isDead && PlayerTwo.isDead)
			{
				return true;
			}
			return false;
		}

		public void Reset()
		{
            ////Reset everything back to zero
            //Game
			isMatchOver = false;
			Round = 0;

            //Players and Shields
            // PlayerOne.ResetStats();
            // PlayerTwo.ResetStats();
            // PlayerOne.Shield.ResetHP();
            // PlayerTwo.Shield.ResetHP();
		}

		public void BeginNewRound()
		{
			Round++;
		}
	}
}