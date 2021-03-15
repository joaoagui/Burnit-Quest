using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        SaveSystem.Load();
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadFromFile()
    {
        PlayerData data = SaveSystem.Load();

        //load Exercise Data
        Instance.playerData.stepsNumber = data.stepsNumber;
        Instance.playerData.Squats = data.Squats;
        Instance.playerData.punches = data.punches;
        Instance.playerData.totalCalories = data.totalCalories;

        //load progression
        Instance.playerData.stageComplete = data.stageComplete;
        Instance.playerData.totalCoins = data.totalCoins;

        //load skills and Stats
        Instance.playerData.numOfHearts = data.numOfHearts;
        Instance.playerData.heartPieces = data.heartPieces;
        Instance.playerData.speedSkill = data.speedSkill;
        Instance.playerData.jumpSkill = data.jumpSkill;
        Instance.playerData.damageSkill = data.damageSkill;
        Instance.playerData.shieldSphere = data.shieldSphere;
        Instance.playerData.multishots = data.multishots;
        Instance.playerData.magnetRange = data.magnetRange;
        Instance.playerData.superJump = data.superJump;
        Instance.playerData.punchCombo = data.punchCombo;

        //Cutscenes
        Instance.playerData.Cutscene1 = data.Cutscene1;
        Instance.playerData.Cutscene2 = data.Cutscene2;
        Instance.playerData.Cutscene3 = data.Cutscene3;
        Instance.playerData.Cutscene4 = data.Cutscene4;
        Instance.playerData.Cutscene5 = data.Cutscene5;
        Instance.playerData.Cutscene6 = data.Cutscene6;
        Instance.playerData.Cutscene7 = data.Cutscene7;
        Instance.playerData.Cutscene8 = data.Cutscene8;
        Instance.playerData.Cutscene9 = data.Cutscene9;
        Instance.playerData.Cutscene10 = data.Cutscene10;

        //Altars
        Instance.playerData.altar1 = data.altar1;
        Instance.playerData.altar2 = data.altar2;
        Instance.playerData.altar3 = data.altar3;
        Instance.playerData.altar4 = data.altar4;
        Instance.playerData.altar5 = data.altar5;
        Instance.playerData.altar6 = data.altar6;
        Instance.playerData.altar7 = data.altar7;
        Instance.playerData.altar8 = data.altar8;
        Instance.playerData.altar9 = data.altar9;
        Instance.playerData.altar10 = data.altar10;

        //Trophies
        Instance.playerData.Trophy1 = data.Trophy1;
        Instance.playerData.Trophy2 = data.Trophy2;
        Instance.playerData.Trophy3 = data.Trophy3;
        Instance.playerData.Trophy4 = data.Trophy4;
        Instance.playerData.Trophy5 = data.Trophy5;
    }

    public void SaveFile()
    {
        SaveSystem.Save(playerData);

        //save Exercise Data
        playerData.stepsNumber = Instance.playerData.stepsNumber;
        playerData.Squats = Instance.playerData.Squats;
        playerData.punches = Instance.playerData.punches;
        playerData.totalCalories = Instance.playerData.totalCalories;

        //save progression
        playerData.stageComplete = Instance.playerData.stageComplete;
        playerData.totalCoins = Instance.playerData.totalCoins;

        //save skills and Stats
        playerData.numOfHearts = Instance.playerData.numOfHearts;
        playerData.heartPieces = Instance.playerData.heartPieces;
        playerData.speedSkill = Instance.playerData.speedSkill;
        playerData.jumpSkill = Instance.playerData.jumpSkill;
        playerData.damageSkill = Instance.playerData.damageSkill;
        playerData.shieldSphere = Instance.playerData.shieldSphere;
        playerData.multishots = Instance.playerData.multishots;
        playerData.magnetRange = Instance.playerData.magnetRange;
        playerData.superJump = Instance.playerData.superJump;
        playerData.punchCombo = Instance.playerData.punchCombo;

        // save Altars
        playerData.altar1 = Instance.playerData.altar1;
        playerData.altar2 = Instance.playerData.altar2;
        playerData.altar3 = Instance.playerData.altar3;
        playerData.altar4 = Instance.playerData.altar4;
        playerData.altar5 = Instance.playerData.altar5;
        playerData.altar6 = Instance.playerData.altar6;
        playerData.altar7 = Instance.playerData.altar7;
        playerData.altar8 = Instance.playerData.altar8;
        playerData.altar9 = Instance.playerData.altar9;
        playerData.altar10 = Instance.playerData.altar10;

        // save Cutscenes
        playerData.Cutscene1 = Instance.playerData.Cutscene1;
        playerData.Cutscene2 = Instance.playerData.Cutscene2;
        playerData.Cutscene3 = Instance.playerData.Cutscene3;
        playerData.Cutscene4 = Instance.playerData.Cutscene4;
        playerData.Cutscene5 = Instance.playerData.Cutscene5;
        playerData.Cutscene6 = Instance.playerData.Cutscene6;
        playerData.Cutscene7 = Instance.playerData.Cutscene7;
        playerData.Cutscene8 = Instance.playerData.Cutscene8;
        playerData.Cutscene9 = Instance.playerData.Cutscene9;
        playerData.Cutscene10 = Instance.playerData.Cutscene10;

        //Trophies
        playerData.Trophy1 = Instance.playerData.Trophy1;
        playerData.Trophy2 = Instance.playerData.Trophy2;
        playerData.Trophy3 = Instance.playerData.Trophy3;
        playerData.Trophy4 = Instance.playerData.Trophy4;
        playerData.Trophy5 = Instance.playerData.Trophy5;

    }

}
