using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer MainMixer;

    public GameObject focusButton;

    //public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusButton);



        //resolutions = Screen.resolutions;

        //resolutionDropdown.ClearOptions();

        //int currentResolutionIndex = 0;
        //List<string> options = new List<string>();
        //for(int i = 0; i< resolutions.Length; i++)
        //{
        //    string option = resolutions[i].width + "x" + resolutions[i].height;
        //    options.Add(option);

        //    if(resolutions[i].width == Screen.currentResolution.width && 
        //        resolutions[i].height == Screen.currentResolution.height)
        //    {
        //        currentResolutionIndex = i;
        //    }
        //}

        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshShownValue();
    }

    //public void SetResolution(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}

    public void SetMainVolume(float volume)
    {
        MainMixer.SetFloat("volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        MainMixer.SetFloat("music", volume);
    }

    public void SetSfxVolume(float volume)
    {
        MainMixer.SetFloat("sfx", volume);
    }

    public void SetVoicesVolume(float volume)
    {
        MainMixer.SetFloat("voices", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetCoop(bool coopEnabled)
    {
        CoopManager.CoopEnabled = coopEnabled;
    }
}
