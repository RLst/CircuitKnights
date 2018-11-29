//DuckBike
//Brent
//Tony, 29 Nov 2018

using UnityEngine;


public class MouseDisabler : MonoBehaviour
{
    [SerializeField] new bool enabled = true;

    void Awake()
    {
		if (enabled)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
    }

}
