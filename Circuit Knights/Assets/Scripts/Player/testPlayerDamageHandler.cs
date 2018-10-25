using UnityEngine;

namespace CircuitKnights {

public class testPlayerDamageHandler : MonoBehaviour {
	public int playerHealth;
	public int playerNumber;
	public int kineticEnergyFactor;		//Multiply with collision

	int damage;

	void Start() {
		


		//Debug
		print(playerHealth);
	}

	//Take normal lance damage
	void OnCollisionEnter(Collision collision)
	{
		//If this player has collided with a lance (this assumes the player should never collide with one own's lance)
		if (collision.transform.tag == "Lance") {

			//Take damage based on kinetic energy (KE = 1/2mv2)
			// var lance = collision.transform.GetComponent<Player>().;
			// var damageFromCollision = 0.5f * collision.transform.GetComponent<Lance>().mass
		}



	}

	//Take auxilliary lance damage (ie. from lance machine gun bullets etc)
	void OnLanceAuxillaryDamage() {
		//Lance.cs has to SendMessage("OnLanceAuxillaryDamage())
	}

}

}