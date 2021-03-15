using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkipCutscene : MonoBehaviour
{
    public PlayableDirector Director;
    public GameObject button;
    public GameObject pauseBtn;

    private void Update()
    {
        PauseMenu.timerPause = 5f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
    public void Skip()
    {
        Director.time = Director.duration - 1f;
        button.SetActive(false);
        pauseBtn.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseBtn);
        Destroy(gameObject);
    }



}
