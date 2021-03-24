using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VersusSettings : MonoBehaviour
{

    public TextMeshPro ModeText;
    public string raceDescription;
    public string tokenDescription;
    public string slingshotDescription;
    public string lastonestandingDescription;

    public static string GameMode;

    public TextMeshPro P1Name;
    public TextMeshPro P2Name;

    static public string P1Character;
    static public string P2Character;

    public SpriteRenderer P1Portrait;
    public SpriteRenderer P2Portrait;

    public Sprite RithPortrait;
    public Sprite ChayPortrait;

    private float BtnTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        P1Character = "Rith";
        P2Character = "Chay";
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
    }


    public void ChangeP1CharacterLeft()
    {
        if(P1Character == "Rith" && BtnTimer <0)
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
        if(GameMode == "Race")
        {
            GameMode = "Token";
        }
    }

    public void GameModeRight()
    {
        if (GameMode == "Race")
        {
            GameMode = "Token";
        }
    }
}
