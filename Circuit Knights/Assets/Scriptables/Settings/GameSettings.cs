//Duckbike
//Tony Le
//26 Oct 2018

using System;
using System.Linq;
using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights.Objects
{
    // [CreateAssetMenu(fileName = "New Game Settings", menuName = "Game", order = 50)]
    public class GameSettings : ScriptableObject
	{
		[Multiline] [SerializeField] string description = "Holds the game settings";

	#region Singleton
		private static GameSettings _instance;
		public static GameSettings Instance
		{
			get {
				//If an instance of 
				if (!_instance)
					_instance = Resources.FindObjectsOfTypeAll<GameSettings>().FirstOrDefault();
	#if UNITY_EDITOR
				if (!_instance)
					InitializeFromDefault(UnityEditor.AssetDatabase.LoadAssetAtPath<GameSettings>("Assets/Resources/GameSettings/DefaultGameSettings.asset"));
	#endif
				return _instance;
			}
		}
        public static void InitializeFromDefault(GameSettings settings)
        {
            if (_instance) DestroyImmediate(_instance);
            _instance = Instantiate(settings);
            _instance.hideFlags = HideFlags.HideAndDontSave;
        }
	#endregion

	#region Players
		public Player PlayerOne;
		public Player PlayerTwo;

		// public static Player[] players;
		// public static Player[] Players { get { return players; } }
	// 	private static Player[] players;	//Index 0 is Player 1, index 1 is Player 2
		// public static Player playerOne;
		// public static Player PlayerOne {
		// 	get { return playerOne; }
		// 	private set { playerOne = value; }
		// }
		// [SerializeField] Player playerTwo;
		// public static Player PlayerTwo {
		// 	get { return playerTwo; }
		// 	private set { playerTwo = value; }
		// }
	#endregion

	#region Game Settings
		[SerializeField] int noOfPasses = 10;
		[SerializeField] int noOfRounds = 1;
		public int Pass { get; set; }
		public int NoOfPasses { get { return noOfPasses; } }
		public int Round { get; set; }
		public int NoOfRounds { get { return noOfRounds; } }

		[Tooltip("In integer seconds")][SerializeField][Range(0,20)] int countDownDuration = 5;
		public int CountDownDuration { get { return countDownDuration; } }
		[SerializeField] BoolVariable gamepadVibrationOn;
	#endregion 

        internal bool MatchIsOver()
        {
            throw new NotImplementedException();
        }

		void Awake()
		{
			Reset();
		}

		public void Reset()
		{
			Pass = 0;
			Round = 0;
		}

		public void BeginPass()
		{
			Pass++;
		}

		public void BeginRound()
		{
			Round++;
		}


	}
}