using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public  Animator animator;

    public GameObject Player1;
    public GameObject Player1win;

    public GameObject Player2;
    public GameObject Player2win;

    public GameObject FinishScreen;
    public GameObject button;
    public GameObject pauseButton;
    bool get = false;

    public TextMeshPro finishText;


    private void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (get == false && collision.gameObject.CompareTag("Player"))
        {
            get = true;
            animator.SetBool("Closed", true);
            PauseMenu.paused = true;
            FindObjectOfType<AudioManager>().Play("gateClose");
            Destroy(pauseButton);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);

            Instantiate(Player1win, Player2.transform.position, Quaternion.identity);
            Destroy(Player1);

            finishText.text = "P1 WINS";

            FinishScreen.SetActive(true);
        }

        if (get == false && collision.gameObject.CompareTag("Chay"))
        {
            get = true;
            animator.SetBool("Closed", true);
            PauseMenu.paused = true;
            FindObjectOfType<AudioManager>().Play("gateClose");
            Destroy(pauseButton);

            Instantiate(Player2win, Player2.transform.position, Quaternion.identity);
            Destroy(Player2);


            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);

            finishText.text = "P2 WINS";

            FinishScreen.SetActive(true);
        }
    }
}
