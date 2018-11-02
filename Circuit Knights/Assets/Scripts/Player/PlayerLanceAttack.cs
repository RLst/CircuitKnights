using UnityEngine;

namespace CircuitKnights
{
	public class PlayerLanceAttack : MonoBehaviour
	{
		[TextArea] public string description = "Allows lance to 'attack'";

		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player2")
			{
				this.GetComponent<Rigidbody>().isKinematic = false;
			}
		}


		//Brainstorm:
		/*
		When the lance enters a valid trigger

			if the trigger is opponent.bodypart[]
			{
				this.rb.isKinematic = false;


				if trigger is opponent.head

				if trigger is opponent.torso

				if trigger is opponent.leftArm

			}

			if the trigger is opponenet.shield
			{
				opponent.shield.takedamage(calculateDamage())
			}

			if the trigger is opponent
			{

			}

			//Otherwise don't do anything

		*/

	}

}