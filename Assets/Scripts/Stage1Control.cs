using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Control : MonoBehaviour
{
    public Button BtnStage1_1;
    public Button BtnStage1_2;
    public Button BtnStage1_3;
    public Button BtnStage1_4;
    public Button BtnStage1_5;

    public GameObject Complete1_1;
    public GameObject Complete1_2;
    public GameObject Complete1_3;
    public GameObject Complete1_4;
    public GameObject Complete1_5;

    public GameObject Trophy1_1;
    public GameObject Trophy1_2;
    public GameObject Trophy1_3;
    public GameObject Trophy1_4;
    public GameObject Trophy1_5;

    public AudioSource start;

    void Start()
    {
        if (DataManager.Instance.playerData.stageComplete <= 1)
        {
            BtnStage1_2.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 2)
        {
            BtnStage1_3.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 3)
        {
            BtnStage1_4.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 4)
        {
            BtnStage1_5.interactable = false;
        }


        if (DataManager.Instance.playerData.stageComplete >= 2)
        {
            Complete1_1.SetActive(true);
            if (DataManager.Instance.playerData.Trophy1 == 1)
            {
                Trophy1_1.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 3)
        {
            Complete1_2.SetActive(true);
            if (DataManager.Instance.playerData.Trophy2 == 1)
            {
                Trophy1_2.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 4)
        {
            Complete1_3.SetActive(true);
            if (DataManager.Instance.playerData.Trophy3 == 1)
            {
                Trophy1_3.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 5)
        {
            Complete1_4.SetActive(true);
            if (DataManager.Instance.playerData.Trophy4 == 1)
            {
                Trophy1_4.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 6)
        {
            Complete1_5.SetActive(true);
            if (DataManager.Instance.playerData.Trophy5 == 1)
            {
                Trophy1_5.SetActive(true);
            }
        }



    }
}
