//Duckbike
//Tony Le
//26 Oct 2018

using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights.Events
{

	[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 32)]
	public class GameEvent : ScriptableObject {

		private List<GameEventListener> listeners = new List<GameEventListener>();

		[SerializeField][Multiline] string Description = 
			"The event object that can be raised to trigger responses from listeners.";

		public void Raise()
		{
			for (int i = listeners.Count-1; i >= 0; i--)
			{
				listeners[i].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			if (!listeners.Contains(listener))
				listeners.Add(listener);
			else
				Debug.LogWarning("Listener re-registered to event.");
		}

		public void UnregisterListener(GameEventListener listener)
		{
			listeners.Remove(listener);
		}

	}

}