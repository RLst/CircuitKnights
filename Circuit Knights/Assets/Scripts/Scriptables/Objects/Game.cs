//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Objects
{

	[CreateAssetMenu(fileName = "New Game Settings", menuName = "Game", order = 50)]
	public class Game : ScriptableObject
	{
		[Multiline] [SerializeField] string description = "Holds the game settings";
		[SerializeField] int noOfPasses = 10;
		[SerializeField] int noOfRounds = 1;


		public int Pass { get; set; }
		public int NoOfPasses { get { return noOfPasses; } }
		public int Round { get; set; }
		public int NoOfRounds { get { return noOfRounds; } }

		public int xWinner { get; set; }
		// public int Match { get; set; }

		void Awake()
		{
			Reset();
		}

		public void Reset()
		{
			Pass = 0;
			Round = 0;
		}

	}
}