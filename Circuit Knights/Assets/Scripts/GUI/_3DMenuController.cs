using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CircuitKnights.Variables;
using UnityEngine.EventSystems;

namespace CircuitKnights.Cameras
{

    public class _3DMenuController : MonoBehaviour
    {

    	// [Header("Clever Menu Items")]
        // [Serializable]
        // public class MenuItem
        // {
        //     [HideInInspector] public string name;
        //     public Transform point;
        // }
        // [SerializeField] List<MenuItem> menuItems;

        // int curMenuIndex = 0;	//First camera point should be for "Play"

        // [Tooltip("Helps decouple this menu system")]
        // [SerializeField] StringVariable menuText;

		[Header("EventSystem Menu Items")]
        EventSystem eventSystem;
        [SerializeField] List<_3DMenuItem> menuItems;
        _3DMenuItem currentItem = null;
        _3DMenuItem lastItem = null;


        [Header("Camera")]
        float randomNumber;
		[SerializeField] float speed = 2.5f;
		[SerializeField] float noiseSpeed = 0.33f;
		[SerializeField] float noiseMagnitude = 1f;

		void Awake()
		{
            eventSystem = FindObjectOfType<EventSystem>();
            currentItem = eventSystem.firstSelectedGameObject.GetComponent<_3DMenuItem>();
        }

		void Update() 
		{
            //Get the current 3D menu item
            currentItem = eventSystem.currentSelectedGameObject.GetComponent<_3DMenuItem>();
            
            //Save the last item in case current item becomes null
            if (currentItem != null) lastItem = currentItem;

            if (currentItem != null)
			{
				//Move camera to the currently selected item
				SetCameraPosition(currentItem.CamTransform);
			}
			else
			{
                //Otherwise go to the last used item before current item went null
                SetCameraPosition(lastItem.CamTransform);
            }
        }

        void SetCameraPosition(Transform camTransform)
        {
            //Position and move the camera with lerp
            var dt = Time.deltaTime;    //Cache; probably pointless

            Vector3 noiseOffset = Vector3.zero;
            noiseOffset.x = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed) - 0.5f) * noiseMagnitude;
            noiseOffset.y = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.33f) - 0.5f) * noiseMagnitude;
            noiseOffset.z = (Mathf.PerlinNoise(randomNumber, Time.time * noiseSpeed + 0.66f) - 0.5f) * noiseMagnitude;

            this.transform.position = Vector3.Lerp(this.transform.position, camTransform.position + noiseOffset, speed * dt);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, camTransform.rotation, speed * dt);
        }

    }
}



// void Start()
// {
// 	//Seed for camera perlin sway
// 	randomNumber = UnityEngine.Random.Range(0f, 1f);

// 	//Resets
// 	curMenuIndex = 0;
// 	menuText.Value = "";

// 	//Auto sets the name of each menu item
// 	foreach (var menuItem in menuItems)
// 	{
// 		menuItem.name = menuItem.point.name;
// 	}
// }

// void Update()
// {
//     //Set menu text
//     menuText.Value = menuItems[curMenuIndex].name;

//     //Select between camera points
//     if (Input.GetKeyDown(KeyCode.LeftArrow))
//     {
//         curMenuIndex--;
//         if (curMenuIndex < 0)
//             curMenuIndex = 0;
//     }
//     if (Input.GetKeyDown(KeyCode.RightArrow))
//     {
//         curMenuIndex++;
//         if (curMenuIndex > menuItems.Count - 1)
//             curMenuIndex = menuItems.Count - 1;
//     }

//     SetCameraPosition();
// }