using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject creditsScreen;

    public GameObject Btn;
    public GameObject backBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backBtn);
    }

    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Btn);

    }
}
