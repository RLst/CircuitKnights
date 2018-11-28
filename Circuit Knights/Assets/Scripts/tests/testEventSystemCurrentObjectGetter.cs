using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testEventSystemCurrentObjectGetter : MonoBehaviour
{

    EventSystem eventSystem;

    // Use this for initialization
    void Start()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentSelectedObject = eventSystem.currentSelectedGameObject;
        Debug.Log("CurrentSelectedObj: " + currentSelectedObject);
    }
}
