using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialMultiplayer : MonoBehaviour
{
    public GameObject canvasPause;
    public GameObject pauseButton;
    public GameObject Objective;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.paused = true;
    }

    // Update is called once per frame
    public void StartGame()
    {
        canvasPause.SetActive(true);
        Objective.SetActive(true);
        PauseMenu.paused = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseButton);
        Destroy(gameObject);
    }
}