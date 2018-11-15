using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRagdoll : MonoBehaviour
{
	private Rigidbody[] rigidbodies;
	private Animator animator;
	public Collider opponentsLanceCollider;
	public Transform lance;
	public Transform shield;

	void Start()
	{
		rigidbodies = GetComponentsInChildren<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
		// foreach (var rb in rigidbodies)
		// {
		// 	rb.isKinematic = false;
		// }
		if (other == opponentsLanceCollider)
		{
			Debug.Log("JOUSTED!");

			other.GetComponent<Rigidbody>().isKinematic = false;

			animator.enabled = false;

			//Disconnect player from everything
			//but keep lance and shield connected???
			transform.SetParent(null);
			lance.SetParent(this.transform);
			shield.SetParent(this.transform);

		}


	}
}
