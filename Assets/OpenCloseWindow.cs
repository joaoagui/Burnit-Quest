using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCloseWindow : MonoBehaviour
{

    public GameObject screen;
    public GameObject btnReturn;
    public GameObject btnScreen;


    // Update is called once per frame
    public void OpenScreen()
    {
        screen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(btnScreen);
    }

    public void CloseScreen()
    {
        screen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(btnReturn);
    }
}
