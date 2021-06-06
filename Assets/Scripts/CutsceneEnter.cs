using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject thingstoHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cutscene.SetActive(true);
        thingstoHide.SetActive(false);
    }
}
