using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData {
         
    public int stepsNumber = 0;
    public int Squats = 0;
    public float stageCalories = 0f;
    public float totalCalories = 0f;
    public float punches = 0;
    public float jumpingJacks = 0;
    public float sitUps = 0;


    public int currentStage = 0;

    public int numOfHearts = 3;

    public int stageComplete = 0;
    public int totalCoins = 0;
    public int heartPieces = 0;

    public int SpeedLvl1 = 0;
    public int SpeedLvl2 = 0;
    public int SpeedLvl3 = 0;
    public int JumpLvl1 = 0;
    public int JumpLvl2 = 0;
    public int SuperJumplvl1 = 0;

    public int HealthLvl1 = 0;
    public int HealthLvl2 = 0;
    public int HealthLvl3 = 0;
    public int MagnetLvl1 = 0;
    public int MagnetLvl2 = 0;
    public int ShieldSphereLvl1 = 0;

    public int PunchLvl1 = 0;
    public int PunchLvl2 = 0;
    public int PunchLvl3 = 0;
    public int MultiLvl1 = 0;
    public int MultiLvl2 = 0;
    public int ComboLvl1 = 0;

    public float speedSkill = 1;
    public float jumpSkill = 0;
    public int damageSkill = 3;

    public int shieldSphere = 0;

    public int multishots = 0;
    public float magnetRange = 2;
    public int superJump = 0;

    public int punchCombo = 0;

    //Fire Shrines
    public int altar1, altar2, altar3, altar4, altar5, altar6, altar7, altar8, altar9, altar10;

    //cutscenes watched
    public bool Cutscene1, Cutscene2, Cutscene3, Cutscene4, Cutscene5, Cutscene6, Cutscene7, Cutscene8, Cutscene9, Cutscene10;

    //trophies
    public int Trophy1, Trophy2, Trophy3, Trophy4, Trophy5, Trophy6, Trophy7, Trophy8, Trophy9, Trophy10, Trophy11, Trophy12, Trophy13, Trophy14, Trophy15, Trophy16, Trophy17, Trophy18, Trophy19, Trophy20, Trophy21, Trophy22, Trophy23, Trophy24, Trophy25, Trophy26, Trophy27, Trophy28, Trophy29, Trophy30;

    public int amulet1, amulet2, amulet3, amulet4, amulet5, amulet6, amulet7, amulet8, amulet9, amulet10, amulet11, amulet12;

}
