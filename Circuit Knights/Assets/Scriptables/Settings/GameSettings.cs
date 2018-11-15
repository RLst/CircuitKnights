//Duckbike
//Tony Le
//26 Oct 2018

using System;
using System.Linq;
using CircuitKnights.Objects;
using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights
{
    [CreateAssetMenu(fileName = "New Game Settings", menuName = "Game Settings", order = 32)]
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
		public PlayerData PlayerOne;
		public PlayerData PlayerTwo;

		public PlayerData[] Players { get; set; }
	#endregion

	#region Game Settings
		[Range(1, 20)][SerializeField] int xNoOfPasses;
		[Range(1,10)][SerializeField] int noOfRounds;
		public int Pass { get; set; }
		public int NoOfPasses { get { return xNoOfPasses; } }
		public int Round { get; set; }
		public int NoOfRounds { get { return noOfRounds; } }
		public bool isMatchOver { get; private set; }


		[SerializeField] BoolVariable gamepadVibrationOn;
	#endregion

		////DIRTY
		internal void SetMatchOver(bool isMatchOver)
		{
			this.isMatchOver = isMatchOver;
		}
        // internal bool isMatchOver()
        // {
		// 	//Check if any or both players are dead and respond accordingly
		// 	if (PlayerOne.isDead)
		// 	{
		// 		return true;
		// 	}
		// 	else if (PlayerTwo.isDead)
		// 	{
		// 		return true;
		// 	}
		// 	return false;
        // }

		////DIRTY
		internal bool isDraw()
		{
			if (PlayerOne.isDead && PlayerTwo.isDead)
			{
				return true;
			}
			return false;
		}

		void Awake()
		{
			Reset();
		}

		public void Reset()
		{
			isMatchOver = false;
			Pass = 0;
			Round = 0;
		}

		public void BeginPass()
		{
			Pass++;
		}

		public void BeginNewRound()
		{
			Round++;
		}
	}
}