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

    public GameObject Stage2Locked;
    public GameObject Stage3Locked;
    public GameObject Stage4Locked;
    public GameObject Stage5Locked;
    public GameObject Stage6Locked;
    public GameObject Stage7Locked;
    public GameObject Stage8Locked;

    public Text currentStage_Txt;

    // Start is called before the first frame update
    void Start()
    {

        if (DataManager.Instance.playerData.stageComplete >= 5)
        {
            Stage2Locked.SetActive(false);
        }
        if (DataManager.Instance.playerData.stageComplete >= 10)
        {
            Stage3Locked.SetActive(false);
        }
        if (DataManager.Instance.playerData.stageComplete >= 15)
        {
            Stage4Locked.SetActive(false);
        }
        if (DataManager.Instance.playerData.stageComplete >= 20)
        {
            Stage5Locked.SetActive(false);
        }
        if (DataManager.Instance.playerData.stageComplete >= 25)
        {
            Stage6Locked.SetActive(false);
        }
        if (DataManager.Instance.playerData.stageComplete >= 30)
        {
            Stage7Locked.SetActive(false);
        }
        if (DataManager.Instance.playerData.stageComplete >= 35)
        {
            Stage8Locked.SetActive(false);
        }
    }


    private void Update()
    {
        currentStage_Txt.text = "" + DataManager.Instance.playerData.stageComplete;
    }
}
