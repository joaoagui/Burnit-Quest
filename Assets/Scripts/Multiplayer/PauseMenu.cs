using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EasyWiFi.Core;

public class PauseMenu : MonoBehaviour
{
    public GameObject resumeBtn;
    public GameObject pauseBtn;
    public GameObject settingsBtn;
    public GameObject settingsScreen;
    public GameObject pauseScreen;
    //public AudioSource bgmusic;
    public static float timerPause = 4000f;

    static public float PauseTimer;

    private float bgmusicVol;

    static public bool paused = false;

    private void Start()
    {
        //bgmusicVol = bgmusic.volume;
    }

    public void Update()
    {
        timerPause -= 1f * Time.deltaTime;

        if(paused == false)
        {
            Time.timeScale = 1f;
            //bgmusic.volume = bgmusicVol;

        }
        else if(paused == true)
        {
            //bgmusic.volume = bgmusicVol * 0.5f;
            //Time.timeScale = 1f;
        }

        if (timerPause < 1 && timerPause > -1)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseBtn);
        }

    }

    public void PauseOn()
    {
        pauseBtn.SetActive(false);
        paused = true;
        pauseScreen.SetActive(true);
        settingsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeBtn);

    }

    public void Resume()
    {
        pauseBtn.SetActive(true);
        paused = false;
        pauseScreen.SetActive(false);
        PauseTimer = 3f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseBtn);
    }

    public void Settings()
    {
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsBtn);
    }


    public void ExitSettings()
    {
        settingsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseBtn);
    }

}
