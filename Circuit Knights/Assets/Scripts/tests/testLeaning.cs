using UnityEngine;

public class testLeaning : MonoBehaviour
{
	Animator animator;

	void Awake()
	{
		animator = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		var lean = Input.GetAxis("Horizontal");
		animator.SetFloat("LeanAxisX", lean);
	}
}
