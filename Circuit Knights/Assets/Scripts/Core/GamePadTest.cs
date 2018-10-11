using UnityEngine;
using XInputDotNetPure;

namespace CircuitKnights {

public class GamePadTest : MonoBehaviour {
	//This only tests the vibration
	//Code just copied from XInputTestCS.cs

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	void Update()
	{
		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int i = 0; i < 4; i++)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)0;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}

			}
		}

        prevState = state;
        state = GamePad.GetState(playerIndex);

		GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
	}

	void FixedUpdate () 
	{
		//Vibrate gamepad 0 based on the triggers
		//GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
	}
}

}