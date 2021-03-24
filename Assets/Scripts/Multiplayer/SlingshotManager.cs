using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlingshotManager : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject pauseButton;

    static public float p1Score;
    static public float p2Score;

    public Text P1ScoreText;
    public Text P2ScoreText;

    public TextMeshPro WinText;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.paused = false;
        p1Score = 0;
        p2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        P1ScoreText.text = "" + p1Score;
        P2ScoreText.text = "" + p2Score;
    }

    public void Finish()
    {
        if (p1Score > p2Score)
        {
            PauseMenu.paused = true;
            WinText.text = "P1 WINS!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }

        else if (p2Score > p1Score)
        {
            PauseMenu.paused = true;
            WinText.text = "P2 WINS!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }

        else if (p2Score == p1Score)
        {
            PauseMenu.paused = true;
            WinText.text = "DRAW!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }
    }
}
