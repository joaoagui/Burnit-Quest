using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{

    public void GoToSplash()
    {
        DataManager.Instance.LoadFromFile();
        SceneManager.LoadScene("Splash");
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoToStageSelect()
    {
        DataManager.Instance.LoadFromFile();
        SceneManager.LoadScene("StageSelect");
        FindObjectOfType<AudioManager>().Play("Select");
    }
}
