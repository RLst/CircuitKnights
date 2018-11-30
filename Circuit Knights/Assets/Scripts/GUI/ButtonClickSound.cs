using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CircuitKnights
{

	[RequireComponent(typeof(Button))]
	public class ButtonClickSound : MonoBehaviour {

		public AudioClip clickSound;

		public AudioClip hoverSound;

		private Button button { get {return GetComponent<Button>(); } }
		private AudioSource source { get {return GetComponent<AudioSource>(); } }

		// Use this for initialization
		void Start () 
		{
		gameObject.AddComponent<AudioSource>();
		source.clip = clickSound;
		source.playOnAwake = false;

		gameObject.AddComponent<AudioSource>();
		source.clip = hoverSound;
		source.playOnAwake = false;

		button.onClick.AddListener(() => PlayClickSound());
		}
	
		public void PlayClickSound()
		{
			source.PlayOneShot(clickSound);
		}

		public void PlayHoverSound()
		{
			//source.PlayOneShot(hoverSound);
		}

	}
}