using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights {
public class RandomClashSound : MonoBehaviour {

	public AudioSource _as;
	public AudioClip[] audioClipArray;

	void Awake () {
		_as = GetComponent<AudioSource> ();
	}
	
	public void PlayHitSound () {
		_as.clip = audioClipArray[Random.Range(0,audioClipArray.Length)];
		_as.PlayOneShot (_as.clip);
	}
}
}