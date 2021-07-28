using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EraseData : MonoBehaviour
{
    public GameObject PromptScreen;
    public GameObject SettingsScreen;
    public GameObject BtnNo;
    public GameObject BtnSettings;


    // Update is called once per frame

    public void PromptYN()
    {        
        SettingsScreen.SetActive(false);
        PromptScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(BtnNo);
    }

    public void ExitErase()
    {
        PromptScreen.SetActive(false);
        SettingsScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(BtnSettings);
    }

    public void EraseSave()
    {
         DataManager.Instance.playerData.totalCoins = 0;
         DataManager.Instance.playerData.totalCalories = 0;
         DataManager.Instance.playerData.damageSkill = 3;
         DataManager.Instance.playerData.speedSkill = 1;
         DataManager.Instance.playerData.jumpSkill = 1;
         DataManager.Instance.playerData.shieldSphere = 0;
         DataManager.Instance.playerData.superJump = 0;
         DataManager.Instance.playerData.punchCombo = 0;
         DataManager.Instance.playerData.numOfHearts = 3;
         DataManager.Instance.playerData.magnetRange = 2;

         DataManager.Instance.playerData.altar1 = 0;
         DataManager.Instance.playerData.altar2 = 0;
         DataManager.Instance.playerData.altar3 = 0;
         DataManager.Instance.playerData.altar4 = 0;
         DataManager.Instance.playerData.altar5 = 0;
         DataManager.Instance.playerData.altar6 = 0;
         DataManager.Instance.playerData.altar7 = 0;
         DataManager.Instance.playerData.altar8 = 0;
         DataManager.Instance.playerData.altar9 = 0;
         DataManager.Instance.playerData.altar10 = 0;

         DataManager.Instance.playerData.Cutscene1 = false;
         DataManager.Instance.playerData.Cutscene2 = false;
         DataManager.Instance.playerData.Cutscene3 = false;
         DataManager.Instance.playerData.Cutscene4 = false;
         DataManager.Instance.playerData.Cutscene5 = false;
         DataManager.Instance.playerData.Cutscene6 = false;
         DataManager.Instance.playerData.Cutscene7 = false;
         DataManager.Instance.playerData.Cutscene8 = false;
         DataManager.Instance.playerData.Cutscene9 = false;
         DataManager.Instance.playerData.Cutscene10 = false;

         DataManager.Instance.playerData.stageComplete = 0;

         DataManager.Instance.playerData.Trophy1 = 0;
         DataManager.Instance.playerData.Trophy2 = 0;
         DataManager.Instance.playerData.Trophy3 = 0;
         DataManager.Instance.playerData.Trophy4 = 0;
         DataManager.Instance.playerData.Trophy5 = 0;
        DataManager.Instance.playerData.Trophy6 = 0;
        DataManager.Instance.playerData.Trophy7 = 0;
        DataManager.Instance.playerData.Trophy8 = 0;
        DataManager.Instance.playerData.Trophy9 = 0;
        DataManager.Instance.playerData.Trophy10 = 0;
        DataManager.Instance.playerData.Trophy11 = 0;
        DataManager.Instance.playerData.Trophy12 = 0;
        DataManager.Instance.playerData.Trophy13 = 0;
        DataManager.Instance.playerData.Trophy14 = 0;
        DataManager.Instance.playerData.Trophy15 = 0;
        DataManager.Instance.playerData.Trophy16 = 0;
        DataManager.Instance.playerData.Trophy17 = 0;
        DataManager.Instance.playerData.Trophy18 = 0;
        DataManager.Instance.playerData.Trophy19 = 0;
        DataManager.Instance.playerData.Trophy20 = 0;
        DataManager.Instance.playerData.Trophy21 = 0;
        DataManager.Instance.playerData.Trophy22 = 0;
        DataManager.Instance.playerData.Trophy23 = 0;
        DataManager.Instance.playerData.Trophy24 = 0;
        DataManager.Instance.playerData.Trophy25 = 0;
        DataManager.Instance.playerData.Trophy26 = 0;
        DataManager.Instance.playerData.Trophy27 = 0;
        DataManager.Instance.playerData.Trophy28 = 0;
        DataManager.Instance.playerData.Trophy29 = 0;
        DataManager.Instance.playerData.Trophy30 = 0;

        DataManager.Instance.playerData.SpeedLvl1 = 0;
        DataManager.Instance.playerData.SpeedLvl2 = 0;
        DataManager.Instance.playerData.SpeedLvl3 = 0;
        DataManager.Instance.playerData.JumpLvl1 = 0;
        DataManager.Instance.playerData.JumpLvl2 = 0;
        DataManager.Instance.playerData.SuperJumplvl1 = 0;

        DataManager.Instance.playerData.HealthLvl1 = 0;
        DataManager.Instance.playerData.HealthLvl2 = 0;
        DataManager.Instance.playerData.HealthLvl3 = 0;
        DataManager.Instance.playerData.MagnetLvl1 = 0;
        DataManager.Instance.playerData.MagnetLvl2 = 0;
        DataManager.Instance.playerData.ShieldSphereLvl1 = 0;

        DataManager.Instance.playerData.PunchLvl1 = 0;
        DataManager.Instance.playerData.PunchLvl2 = 0;
        DataManager.Instance.playerData.PunchLvl3 = 0;
        DataManager.Instance.playerData.MultiLvl1 = 0;
        DataManager.Instance.playerData.MultiLvl2 = 0;
        DataManager.Instance.playerData.ComboLvl1 = 0;



    PlayerPrefs.DeleteAll();

         PromptScreen.SetActive(false);
         SettingsScreen.SetActive(true);
         EventSystem.current.SetSelectedGameObject(BtnSettings);
         DataManager.Instance.SaveFile();
    }
}
