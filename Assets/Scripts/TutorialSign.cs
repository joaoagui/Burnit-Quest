using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSign : MonoBehaviour
{

    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject Tutorial4;

    public int TutorialNumber; // 1:walk, 2:run, 3:punch, 4:jump


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (TutorialNumber == 1)
            {
                Tutorial1.SetActive(true);
            }
            if (TutorialNumber == 2)
            {
                Tutorial2.SetActive(true);
            }
            if (TutorialNumber == 3)
            {
                Tutorial3.SetActive(true);
            }
            if (TutorialNumber == 4)
            {
                Tutorial4.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (TutorialNumber == 1)
            {
                Tutorial1.SetActive(false);
            }
            if (TutorialNumber == 2)
            {
                Tutorial2.SetActive(false);
            }
            if (TutorialNumber == 3)
            {
                Tutorial3.SetActive(false);
            }
            if (TutorialNumber == 4)
            {
                Tutorial4.SetActive(false);
            }
        }
    }
}
