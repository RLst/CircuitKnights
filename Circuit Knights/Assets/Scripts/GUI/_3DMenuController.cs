using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CircuitKnights.Variables;

namespace CircuitKnights.Cameras
{

    public class _3DMenuController : MonoBehaviour
    {

	#region MenuItems

		[Serializable]
        public class MenuItem
        {
            [HideInInspector] public string name;
            public Transform point;
        }
		[SerializeField] List<MenuItem> menuItems;

		int curMenuIndex = 0;	//First camera point should be for "Play"

		[Tooltip("Helps decouple this menu system")]
		[SerializeField] StringVariable menuText;
	#endregion
		
	#region Camera
		float randomNumber;
		[SerializeField] float speed = 2.5f;
		[SerializeField] float noiseSpeed = 0.33f;
		[SerializeField] float noiseMagnitude = 1f;
	#endregion

		void Start()
		{
			//Seed for camera perlin sway
			randomNumber = UnityEngine.Random.Range(0f, 1f);

			//Resets
			curMenuIndex = 0;
			menuText.Value = "";

			//Auto sets the name of each menu item
			foreach (var menuItem in menuItems)
			{
				menuItem.name = menuItem.point.name;
			}
		}

		void Update()
		{
			//Set menu text
			menuText.Value = menuItems[curMenuIndex].name;

			//Select between camera points
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				curMenuIndex--;
				if (curMenuIndex < 0)
					curMenuIndex = 0;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				curMenuIndex++;
				if (curMenuIndex > menuItems.Count - 1)
					curMenuIndex = menuItems.Count - 1;
			}

			//Position and move the camera with lerp
			var dt = Time.deltaTime;	//Cache; probably pointless

			Vector3 noiseOffset = Vector3.zero;
            noiseOffset.x = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed) - 0.5f) * noiseMagnitude;
            noiseOffset.y = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.33f) - 0.5f) * noiseMagnitude;
            noiseOffset.z = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.66f) - 0.5f) * noiseMagnitude;

			transform.position = Vector3.Lerp(transform.position, menuItems[curMenuIndex].point.position + noiseOffset, speed * dt);
			transform.rotation = Quaternion.Lerp(transform.rotation, menuItems[curMenuIndex].point.rotation, speed * dt); 
		}
    }
}


