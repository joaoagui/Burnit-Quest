using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public  Animator animator;

    public GameObject Player1;
    public GameObject Player2;

    public GameObject ChayWin;
    public GameObject RithWin;
    
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

            if (VersusSettings.P1Character == "Chay")
            {
                Instantiate(ChayWin, Player1.transform.position, Quaternion.identity);
                Destroy(Player1);
            }

            else if (VersusSettings.P1Character == "Rith")
            {
                Instantiate(RithWin, Player1.transform.position, Quaternion.identity);
                Destroy(Player1);
            }

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

            if(VersusSettings.P2Character == "Chay")
            {
                Instantiate(ChayWin, Player2.transform.position, Quaternion.identity);
                Destroy(Player2);
            }

            else if (VersusSettings.P2Character == "Rith")
            {
                Instantiate(RithWin, Player2.transform.position, Quaternion.identity);
                Destroy(Player2);
            }

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);

            finishText.text = "P2 WINS";

            FinishScreen.SetActive(true);
        }
    }
}
