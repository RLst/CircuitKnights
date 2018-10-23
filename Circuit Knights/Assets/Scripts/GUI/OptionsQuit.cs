using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//Brent D'Auria
//23 of October
public class OptionsQuit : MonoBehaviour {

    public GameObject FirstObject;
    public void Exit()
    {
        
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstObject, null);
    }
}
