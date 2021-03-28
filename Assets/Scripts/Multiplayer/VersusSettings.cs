using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VersusSettings : MonoBehaviour
{
    public TextMeshPro ModeTitle;
    public TextMeshPro ModeText;
    public string raceDescription;
    public string tokenDescription;
    public string slingshotDescription;
    public string lastStandingDescription;

    public static string GameMode;

    public TextMeshPro P1Name;
    public TextMeshPro P2Name;

    static public string P1Character;
    static public string P2Character;

    public SpriteRenderer P1Portrait;
    public SpriteRenderer P2Portrait;

    public Sprite RithPortrait;
    public Sprite ChayPortrait;

    public Animator P1Animator;
    public Animator P2Animator;

    public AnimatorOverrideController ChayOverride;
    public AnimatorOverrideController RithOverride;

    private float BtnTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        P1Character = "Rith";
        P2Character = "Chay";
        GameMode = "Race";
    }

    public void Update()
    {
        BtnTimer -= 1 * Time.deltaTime;

        if(P1Character == "Rith")
        {
            P1Portrait.sprite = RithPortrait;
            P1Name.text = "Rith";
        }

        if (P1Character == "Chay")
        {
            P1Portrait.sprite = ChayPortrait;
            P1Name.text = "Chay";
        }

        if (P2Character == "Rith")
        {
            P2Portrait.sprite = RithPortrait;
            P2Name.text = "Rith";
        }

        if (P2Character == "Chay")
        {
            P2Portrait.sprite = ChayPortrait;
            P2Name.text = "Chay";
        }

        if (VersusSettings.P1Character == "Rith")
        {
            P1Animator.runtimeAnimatorController = RithOverride;
        }


        if (VersusSettings.P2Character == "Rith")
        {
            P2Animator.runtimeAnimatorController = RithOverride;
        }


        if (VersusSettings.P1Character == "Chay")
        {
            P1Animator.runtimeAnimatorController = ChayOverride;
        }


        if (VersusSettings.P2Character == "Chay")
        {
            P2Animator.runtimeAnimatorController = ChayOverride;
        }


        //set mode title and descriptions


        if (GameMode == "Race")
        {
            ModeTitle.text = "RACE TO THE GATE";
            ModeText.text = raceDescription;
        }
        if (GameMode == "Token")
        {
            ModeTitle.text = "TOKEN FRENZY";
            ModeText.text = tokenDescription;
        }
        if (GameMode == "Slingshot")
        {
            ModeTitle.text = "SLINGSHOT";
            ModeText.text = slingshotDescription;
        }
        if (GameMode == "LastStanding")
        {
            ModeTitle.text = "LAST ONE STANDING";
            ModeText.text = lastStandingDescription;
        }
    }


    public void ChangeP1CharacterLeft()
    {
        FindObjectOfType<AudioManager>().Play("Select");

        if (P1Character == "Rith" && BtnTimer <0)
        {
            P1Character = "Chay";
            BtnTimer = 1;
        }
        if (P1Character == "Chay" && BtnTimer < 0)
        {
            P1Character = "Rith";
            BtnTimer = 1;
        }
    }

    public void ChangeP1CharacterRight()
    {
        FindObjectOfType<AudioManager>().Play("Select");

        if (P1Character == "Rith" && BtnTimer < 0)
        {
            P1Character = "Chay";
            BtnTimer = 1;
        }
        if (P1Character == "Chay" && BtnTimer < 0)
        {
            P1Character = "Rith";
            BtnTimer = 1;
        }
    }

    public void ChangeP2CharacterLeft()
    {
        FindObjectOfType<AudioManager>().Play("Select");

        if (P2Character == "Rith" && BtnTimer < 0)
        {
            P2Character = "Chay";
            BtnTimer = 1;
        }
        if (P2Character == "Chay" && BtnTimer < 0)
        {
            P2Character = "Rith";
            BtnTimer = 1;
        }
    }

    public void ChangeP2CharacterRight()
    {
        FindObjectOfType<AudioManager>().Play("Select");

        if (P2Character == "Rith" && BtnTimer < 0)
        {
            P2Character = "Chay";
            BtnTimer = 1;
        }
        if (P2Character == "Chay" && BtnTimer < 0)
        {
            P2Character = "Rith";
            BtnTimer = 1;
        }
    }

    public void GameModeLeft()
    {
        FindObjectOfType<AudioManager>().Play("Select");


        if (GameMode == "Race" && BtnTimer < 0)
        {
            GameMode = "LastStanding";
            BtnTimer = 1;
        }
        if (GameMode == "LastStanding" && BtnTimer < 0)
        {
            GameMode = "Slingshot";
            BtnTimer = 1;
        }

        if (GameMode == "Token" && BtnTimer < 0)
        {
            GameMode = "Race";
            BtnTimer = 1;
        }
        if (GameMode == "Slingshot" && BtnTimer < 0)
        {
            GameMode = "Token";
            BtnTimer = 1;
        }

    }

    public void GameModeRight()
    {
        FindObjectOfType<AudioManager>().Play("Select");


        if (GameMode == "Race" && BtnTimer < 0)
        {
            GameMode = "Token";
            BtnTimer = 1;
        }
        if (GameMode == "Token" && BtnTimer < 0)
        {
            GameMode = "Slingshot";
            BtnTimer = 1;
        }
        if (GameMode == "Slingshot" && BtnTimer < 0)
        {
            GameMode = "LastStanding";
            BtnTimer = 1;
        }
        if (GameMode == "LastStanding" && BtnTimer < 0)
        {
            GameMode = "Race";
            BtnTimer = 1;
        }
    }
}
