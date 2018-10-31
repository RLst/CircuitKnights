using UnityEngine;

public class RagdollToggler : MonoBehaviour {
	//Attach to ragdoll object
	private Animator animator;
	bool isDisabled = true;

	void Awake()
	{
		animator = GetComponent<Animator>();
		animator.enabled = isDisabled;
	}

	void Update()
    {
        ToggleRagdoll();
    }

    public void ToggleRagdoll()
    {
        //Toggle ragdoll
        if (Input.GetKeyDown(KeyCode.R))
        {
            isDisabled = !isDisabled;
            animator.enabled = isDisabled;
        }
    }
}
