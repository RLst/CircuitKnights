//Tony Le
//5 Oct 2018

using System;
using UnityEngine.UI;
using UnityEngine;


namespace CircuitKnights
{

public class GameController : MonoBehaviour 
{

	[SerializeField] float timeBeforeCountdown = 2f; 		//Seconds
	[SerializeField] float countDownLength = 3f;			//Seconds
	[SerializeField] Text countDownText;
	[SerializeField] Vector3[] playerStartPositions;


	void Update()
	{
		//Run GUI stuff?

		//Cinematic camera pans around the stadium waiting for players to get ready

		///Start the game
		//Move players into position

		//Slight delay
		if (Time.time > timeBeforeCountdown) {

			//Start the actual countdown
			StartCountDown();
		}


		//Players are able to start joust run once countdown is off
		

		// RunCinematicCameras();
	}

	private void StartCountDown()
	{
		////NOT FINISHED!!!
		// countDownText.Text =
		throw new NotImplementedException();
	}

	private void RunCinematicCameras()
	{
		throw new NotImplementedException();
	}
}

}