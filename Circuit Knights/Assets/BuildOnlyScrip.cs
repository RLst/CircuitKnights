//Tony Le
//30 Nov 2018

using CircuitKnights;
using UnityEngine;

public class BuildOnlyScrip : MonoBehaviour
{
	//Keep the game coordinator active no matter what
	public GameCoordinator gameCoordinator;


	void Awake()
	{
		gameCoordinator = FindObjectOfType<GameCoordinator>();
	}

	void Start()
	{
		gameCoordinator = FindObjectOfType<GameCoordinator>();
	}

	void Update()
	{
		if (gameCoordinator.enabled == false)
			gameCoordinator.enabled = true;

	}
}
