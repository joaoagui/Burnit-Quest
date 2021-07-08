using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage3Control : MonoBehaviour
{
    public Button BtnStage3_1;
    public Button BtnStage3_2;
    public Button BtnStage3_3;
    public Button BtnStage3_4;
    public Button BtnStage3_5;

    public GameObject Complete3_1;
    public GameObject Complete3_2;
    public GameObject Complete3_3;
    public GameObject Complete3_4;
    public GameObject Complete3_5;

    public GameObject Trophy3_1;
    public GameObject Trophy3_2;
    public GameObject Trophy3_3;
    public GameObject Trophy3_4;
    public GameObject Trophy3_5;

    public AudioSource start;

    void Start()
    {
        if (DataManager.Instance.playerData.stageComplete <= 10)
        {
            BtnStage3_2.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 11)
        {
            BtnStage3_3.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 12)
        {
            BtnStage3_4.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 13)
        {
            BtnStage3_5.interactable = false;
        }


        if (DataManager.Instance.playerData.stageComplete >= 11)
        {
            Complete3_1.SetActive(true);
            if (DataManager.Instance.playerData.Trophy11 == 1)
            {
                Trophy3_1.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 12)
        {
            Complete3_2.SetActive(true);
            if (DataManager.Instance.playerData.Trophy12 == 1)
            {
                Trophy3_2.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 13)
        {
            Complete3_3.SetActive(true);
            if (DataManager.Instance.playerData.Trophy13 == 1)
            {
                Trophy3_3.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 14)
        {
            Complete3_4.SetActive(true);
            if (DataManager.Instance.playerData.Trophy14 == 1)
            {
                Trophy3_4.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 15)
        {
            Complete3_5.SetActive(true);
            if (DataManager.Instance.playerData.Trophy15 == 1)
            {
                Trophy3_5.SetActive(true);
            }
        }
    }
}
