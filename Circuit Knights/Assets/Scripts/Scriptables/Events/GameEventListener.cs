//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using UnityEngine.Events;

namespace CircuitKnights.Events
{

public class GameEventListener : MonoBehaviour {
	[Tooltip("Event ot register with")] public GameEvent Event;
	[Tooltip("Response to invoke when Event is raised")] public UnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised()
	{
		Response.Invoke();
	}
}

}