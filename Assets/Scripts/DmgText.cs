using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgText : MonoBehaviour
{
    public TextMeshPro text;
    
    // Update is called once per frame
    private void Start()
    {
        text.SetText("" + Bullet.dmgTotal);
    }
}
