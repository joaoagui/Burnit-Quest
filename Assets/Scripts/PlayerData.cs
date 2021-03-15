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
    public int currentStage = 0;

    public int numOfHearts = 3;

    public int stageComplete = 0;
    public int totalCoins = 0;
    public int heartPieces = 0;

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
    public int Trophy1, Trophy2, Trophy3, Trophy4, Trophy5;

    public int amulet1, amulet2, amulet3, amulet4, amulet5, amulet6, amulet7, amulet8, amulet9, amulet10, amulet11, amulet12;

}
