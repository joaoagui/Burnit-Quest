using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2Control : MonoBehaviour
{
    public Button BtnStage2_1;
    public Button BtnStage2_2;
    public Button BtnStage2_3;
    public Button BtnStage2_4;
    public Button BtnStage2_5;

    public GameObject Complete2_1;
    public GameObject Complete2_2;
    public GameObject Complete2_3;
    public GameObject Complete2_4;
    public GameObject Complete2_5;

    public GameObject Trophy2_1;
    public GameObject Trophy2_2;
    public GameObject Trophy2_3;
    public GameObject Trophy2_4;
    public GameObject Trophy2_5;

    public AudioSource start;

    void Start()
    {
        if (DataManager.Instance.playerData.stageComplete <= 5)
        {
            BtnStage2_2.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 6)
        {
            BtnStage2_3.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 7)
        {
            BtnStage2_4.interactable = false;
        }
        if (DataManager.Instance.playerData.stageComplete <= 8)
        {
            BtnStage2_5.interactable = false;
        }


        if (DataManager.Instance.playerData.stageComplete >= 6)
        {
            Complete2_1.SetActive(true);
            if (DataManager.Instance.playerData.Trophy6 == 1)
            {
                Trophy2_1.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 7)
        {
            Complete2_2.SetActive(true);
            if (DataManager.Instance.playerData.Trophy7 == 1)
            {
                Trophy2_2.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 8)
        {
            Complete2_3.SetActive(true);
            if (DataManager.Instance.playerData.Trophy8 == 1)
            {
                Trophy2_3.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 9)
        {
            Complete2_4.SetActive(true);
            if (DataManager.Instance.playerData.Trophy9 == 1)
            {
                Trophy2_4.SetActive(true);
            }
        }
        if (DataManager.Instance.playerData.stageComplete >= 10)
        {
            Complete2_5.SetActive(true);
            if (DataManager.Instance.playerData.Trophy10 == 1)
            {
                Trophy2_5.SetActive(true);
            }
        }
    }
}
