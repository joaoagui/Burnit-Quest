using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    public static int stageCoins;
    public TextMeshPro CoinText;

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "" + stageCoins.ToString();
    }
}
