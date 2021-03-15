using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{


    [Header("Buttons")]
    public Button BtnStage1;
    public Button BtnStage2;
    public Button BtnStage3;
    public Button BtnStage4;
    public Button BtnStage5;
    public Button BtnStage6;
    public Button BtnStage7;
    public Button BtnStage8;
    public Button BtnStage9;
    public Button BtnStage10;


    // Start is called before the first frame update
    void Start()
    {

        if ( DataManager.Instance.playerData.stageComplete <= 4)
        {
            BtnStage2.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 9)
        {
            BtnStage3.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 14)
        {
            BtnStage4.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 19)
        {
            BtnStage5.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 24)
        {
            BtnStage6.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 29)
        {
            BtnStage7.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 34)
        {
            BtnStage8.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 39)
        {
            BtnStage9.interactable = false;
        }
        if ( DataManager.Instance.playerData.stageComplete <= 44)
        {
            BtnStage10.interactable = false;
        }
    }

}
