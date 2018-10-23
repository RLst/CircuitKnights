using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Brent D'Auria
//23 of October
public class SwitchCanvas : MonoBehaviour {


    public GameObject OffCanvas;
    public GameObject OnCanvas;
    public GameObject FirstObject;
    

    public void Switch()
    {
        
        OffCanvas.SetActive(false);
        OnCanvas.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstObject, null);
    }

	}
