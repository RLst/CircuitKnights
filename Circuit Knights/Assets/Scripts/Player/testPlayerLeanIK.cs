using UnityEngine;

public class testPlayerLeanIK : MonoBehaviour {

	[SerializeField] Transform leanTarget;
	[SerializeField] Vector3 torsoOffset = new Vector3(0,0,0);
	[SerializeField] Vector3 torsoAngOffset;

	[SerializeField] float leanFactor = 180f;
	[Tooltip("Percentage of movement of chest ")][SerializeField] float abdomenFactor = 0.5f;

	//Core
	Animator anim;
	Transform chest;
	Transform spine;

	void Start () {
		//Get core objects
		anim = GetComponent<Animator>();
		chest = anim.GetBoneTransform(HumanBodyBones.Chest);
		spine = anim.GetBoneTransform(HumanBodyBones.Spine);
	}
	
	void LateUpdate () {
		//torso = leanTarget;	///?
		//torso.LookAt(leanTarget.position);
		chest.position = chest.position + leanTarget.localPosition;
		chest.rotation = chest.rotation * Quaternion.Euler(0f, leanTarget.localPosition.x * leanFactor, 0f);
		spine.position += leanTarget.localPosition * 0.5f;
		spine.rotation *= Quaternion.Euler(0f, leanTarget.localPosition.x * leanFactor * 0.5f, 0f);

		// torso.rotation = torso.rotation * Quaternion.Euler(leanTarget.localRotation.x, leanTarget.localRotation.eulerAngles.y * leanTarget.localPosition.x * leanFactor, leanTarget.localRotation.z);
		// torso.rotation = torso.rotation * Quaternion.Euler(torsoAngOffset);
	}
}
