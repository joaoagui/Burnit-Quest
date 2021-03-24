using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TokenFrenzyManager : MonoBehaviour
{
    public GameObject finishScreen;

    public GameObject p1;
    public GameObject p2;

    public GameObject RithWin;
    public GameObject ChayWin;

    public GameObject pauseButton;

    static public float p1Score;
    static public float p2Score;

    public Text P1ScoreText;
    public Text P2ScoreText;

    public Text WinText;

    private void Start()
    {
        PauseMenu.paused = false;
        p1Score = 0;
        p2Score = 0;
    }

    private void Update()
    {
        P1ScoreText.text = "" + p1Score;
        P2ScoreText.text = "" + p2Score;

    }

    // Start is called before the first frame update
    public void Finish()
    {
        if(p1Score > p2Score)
        {
            PauseMenu.paused = true;
            WinText.text = "P1 WINS!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);

            if(VersusSettings.P1Character == "Rith")
            {
                Instantiate(RithWin, p1.transform.position, Quaternion.identity);
            }

            if (VersusSettings.P1Character == "Chay")
            {
                Instantiate(ChayWin, p1.transform.position, Quaternion.identity);
            }

            Destroy(p1);
        }

        else if (p2Score > p1Score)
        {
            PauseMenu.paused = true;
            WinText.text = "P2 WINS!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);

            if (VersusSettings.P2Character == "Rith")
            {
                Instantiate(RithWin, p2.transform.position, Quaternion.identity);
            }

            if (VersusSettings.P2Character == "Chay")
            {
                Instantiate(ChayWin, p2.transform.position, Quaternion.identity);
            }

            Destroy(p2);
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
