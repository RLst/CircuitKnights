//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;

namespace CircuitKnights
{
    public class CinematicCamera : MonoBehaviour
    {
		// [SerializeField] 
		new Camera camera;
		[SerializeField] new Animation animation;

		void Awake()
		{
			camera = GetComponent<Camera>();
			animation.playAutomatically = true;
		}

		void Start()
		{
			//Run the animation once
			animation.Play();
		}

    }

}