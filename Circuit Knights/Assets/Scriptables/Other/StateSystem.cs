using UnityEngine;
using CircuitKnights.Events;

namespace CircuitKnights.States
{

	[CreateAssetMenu(fileName = "New State System", menuName = "State System", order = 33)]
	public class StateSystem : ScriptableObject
	{
		[SerializeField] GameState mainMenu;
		[SerializeField] GameState pauseMenu;
		[SerializeField] GameState gameplay;
		[SerializeField] GameState currentState;
		[SerializeField] GameState previousState;
		// [SerializeField] GameState 	

        public GameEvent[] enterMainMenu;
        public GameEvent[] exitMainMenu;
        public GameEvent[] enterPauseMenu;
        public GameEvent[] exitPauseMenu;
        public GameEvent[] enterGameplay;
        public GameEvent[] exitGameplay;

	}

}