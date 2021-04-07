using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TokenFrenzyManager : MonoBehaviour
{
    public GameObject finishScreen;

    public GameObject Player1;
    public GameObject Player2;

    public GameObject RithWin;
    public GameObject ChayWin;


    public GameObject pauseButton;
    public GameObject button;

    static public float p1Score;
    static public float p2Score;

    public Text P1ScoreText;
    public Text P2ScoreText;

    public Text WinText;

    private Animator P1Animator;
    private Animator P2Animator;

    public AnimatorOverrideController ChayAnimator;

    private void Start()
    {
        P1Animator = Player1.GetComponent<Animator>();
        P2Animator = Player2.GetComponent<Animator>();
        p1Score = 0;
        p2Score = 0;

        if (VersusSettings.P1Character == "Chay")
        {
            P1Animator.runtimeAnimatorController = ChayAnimator;
        }

        if (VersusSettings.P2Character == "Chay")
        {
            P2Animator.runtimeAnimatorController = ChayAnimator;
        }
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
            Destroy(pauseButton);
            PauseMenu.paused = true;
            WinText.text = "P1 WINS!";
            finishScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);

            if (VersusSettings.P1Character == "Rith")
            {
                Instantiate(RithWin, Player1.transform.position, Quaternion.identity);
            }

            if (VersusSettings.P1Character == "Chay")
            {
                Instantiate(ChayWin, Player1.transform.position, Quaternion.identity);
            }

            Destroy(Player1);
        }

        else if (p2Score > p1Score)
        {
            Destroy(pauseButton);
            PauseMenu.paused = true;
            WinText.text = "P2 WINS!";
            finishScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);

            if (VersusSettings.P2Character == "Rith")
            {
                Instantiate(RithWin, Player2.transform.position, Quaternion.identity);
            }

            if (VersusSettings.P2Character == "Chay")
            {
                Instantiate(ChayWin, Player2.transform.position, Quaternion.identity);
            }

            Destroy(Player2);
        }

        else if (p2Score == p1Score)
        {
            Destroy(pauseButton);
            PauseMenu.paused = true;
            WinText.text = "DRAW!";
            finishScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);
        }
    }
}
