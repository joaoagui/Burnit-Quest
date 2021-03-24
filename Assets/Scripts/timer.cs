using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    private float minutes;
    private float seconds;
        
    public TextMeshPro minutesTxt;
    public TextMeshPro secondsTxt;

    public GameObject EndlessRunnerManager;

    // Start is called before the first frame update
    void Start()
    {
        if(EndlessRunnerSettings.timerGoal == false)
        {
            gameObject.SetActive(false);
        }
        minutes = EndlessRunnerSettings.targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.paused == false)
        {
            secondsTxt.text = "" + seconds.ToString("00");
            minutesTxt.text = "" + minutes.ToString("00");

            if (minutes >= 0 && seconds > 0)
            {
                seconds -= Time.deltaTime * 1;
            }

            if (minutes > 0 && seconds <= 0)
            {
                minutes -= 1;
                seconds = 59;
            }

            if (minutes <= 0 && seconds <= 0 && EndlessRunnerSettings.timerGoal == true)
            {
                EndlessRunnerManager.GetComponent<EndlessRunner>().Finish();                
            }
        }

    }
}
