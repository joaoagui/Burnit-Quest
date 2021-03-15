using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UILastBtn : MonoBehaviour
{
    static public GameObject lastselect;
    //public Text currentFocustxt;


    void Start()
    {
        lastselect = new GameObject();
    }
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }

        //currentFocustxt.text = EventSystem.current.currentSelectedGameObject.name;
    }
}
