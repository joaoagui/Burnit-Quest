using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStats : MonoBehaviour
{

    public TextMeshPro lifeTxt;
    public TextMeshPro damageTxt;
    public TextMeshPro jumpTxt;
    public TextMeshPro speedTxt;

    // Start is called before the first frame update
    void Start()
    {
        lifeTxt.text = "" + DataManager.Instance.playerData.numOfHearts;
        damageTxt.text = "" + (DataManager.Instance.playerData.damageSkill - 2) + "-" + (   DataManager.Instance.playerData.damageSkill);
        jumpTxt.text = "" + (22 + DataManager.Instance.playerData.jumpSkill) + " cm";
        speedTxt.text = "" + (6 * DataManager.Instance.playerData.speedSkill) + " m/s";

    }

}
