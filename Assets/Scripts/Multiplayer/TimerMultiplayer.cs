using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerMultiplayer : MonoBehaviour
{
    private float minutes;
    private float seconds;

    public Text minutesTxt;
    public Text secondsTxt;

    public GameObject TokenFrenzyManager;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        minutes = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused == false)
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

            if (minutes <= 0 && seconds <= 0)
            {
                FindObjectOfType<AudioManager>().Play("whistle");
                TokenFrenzyManager.GetComponent<TokenFrenzyManager>().Finish();
            }
        }

    }
}
