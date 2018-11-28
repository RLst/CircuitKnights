using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Brent D'Auria
//23 of October
public class SwitchCanvas : MonoBehaviour {

    [SerializeField] GameObject OffCanvasOne;
    [SerializeField] GameObject OffCanvasTwo;
    [SerializeField] GameObject OnCanvas;
    [SerializeField] GameObject FirstObject;
    

    public void Switch()
    {
        
        OffCanvasOne.SetActive(false);
        OffCanvasTwo.SetActive(false);

        OnCanvas.SetActive(true);
        GameObject.Find("EventSystemOne").GetComponent<EventSystem>().SetSelectedGameObject(FirstObject, null);
    }

	}
