using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LasStandingManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private Animator P1Animator;
    private Animator P2Animator;

    public AnimatorOverrideController ChayAnimator;

    public SurfaceEffector2D threadmill;
    public float speed = -1;
    public TextMeshPro speedTxt;
    bool threadmillON = true;

    public GameObject finishScreen;
    public TextMeshPro WinText;
    public GameObject pauseButton;
    public GameObject button;

    public GameObject crateSpawner1;
    public GameObject crateSpawner2;

    private float spawnCD1;
    private float spawnCD2;

    public GameObject bumper1;
    public GameObject bumper2;
    public GameObject bumper3;


    private void Start()
    {
        bumper1.SetActive(false);
        bumper2.SetActive(false);
        bumper3.SetActive(false);

        crateSpawner1.SetActive(false);
        crateSpawner2.SetActive(false);

        P1Animator = Player1.GetComponent<Animator>();
        P2Animator = Player2.GetComponent<Animator>();

        spawnCD1 = crateSpawner1.GetComponent<Spawner>().startcooldown;
        spawnCD2 = crateSpawner2.GetComponent<Spawner>().startcooldown;

        spawnCD1 = 200f;
        spawnCD2 = 200f;

        if (VersusSettings.P1Character == "Chay")
        {
            P1Animator.runtimeAnimatorController = ChayAnimator;
        }

        if (VersusSettings.P2Character == "Chay")
        {
            P2Animator.runtimeAnimatorController = ChayAnimator;
        }
    }

    void Update()
    {
        speedTxt.text = (speed *-1).ToString("F1");
        if(PauseMenu.paused == false)
        {
            if (threadmillON == true)
            {
                if (speed > -1 && speed <= 0)
                {
                    speed -= 0.1f * Time.deltaTime;
                }

                if (speed > -2 && speed <= -1)
                {
                    speed -= 0.05f * Time.deltaTime;
                    bumper1.SetActive(true);
                }

                if (speed > -3 && speed <= -2)
                {
                    speed -= 0.04f * Time.deltaTime;
                    crateSpawner1.SetActive(true);
                }

                if (speed > -4 && speed <= -3)
                {
                    speed -= 0.04f * Time.deltaTime;
                    bumper2.SetActive(true);
                }

                if (speed > -4.5f && speed <= -4)
                {
                    speed -= 0.03f * Time.deltaTime;
                    crateSpawner2.SetActive(true);
                }

                if (speed > -5 && speed <= -4.5f)
                {
                    speed -= 0.03f * Time.deltaTime;
                    bumper3.SetActive(true);
                }

                threadmill.speed = speed;

                if (Player1.transform.position.y < -100)
                {
                    Destroy(pauseButton);
                    finishScreen.SetActive(true);
                    PauseMenu.paused = true;
                    threadmillON = false;
                    speed = 0.01f;
                    WinText.text = "P2 WINS!";
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(button);
                }
                if (Player2.transform.position.y < -100)
                {
                    Destroy(pauseButton);
                    finishScreen.SetActive(true);
                    PauseMenu.paused = true;
                    threadmillON = false;
                    speed = 0.01f;
                    WinText.text = "P1 WINS!";
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(button);
                }
            }
       

        }

    }
}
