using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trophy : MonoBehaviour
{

    public int trophyStage = 0;
    public GameObject TrophyUI;
    public GameObject TrophyParticles;

    public bool pulling = false;

    GameObject Target;


    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        if (pulling == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, .3f);
        }
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.CompareTag("Player")) 
        {
            TrophyUI.SetActive(true);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("TrophyGet");
            Instantiate(TrophyParticles, transform.position, transform.rotation);
            TrophyUI.SetActive(true);

            if (trophyStage == 1)
            {
                 DataManager.Instance.playerData.Trophy1 = 1;
            }
            if (trophyStage == 2)
            {
                 DataManager.Instance.playerData.Trophy2 = 1;
            }
            if (trophyStage == 3)
            {
                 DataManager.Instance.playerData.Trophy3 = 1;
            }
            if (trophyStage == 4)
            {
                 DataManager.Instance.playerData.Trophy4 = 1;
            }
            if (trophyStage == 5)
            {
                 DataManager.Instance.playerData.Trophy5 = 1;
            }

            if (trophyStage == 6)
            {
                DataManager.Instance.playerData.Trophy6 = 1;
            }
            if (trophyStage == 7)
            {
                DataManager.Instance.playerData.Trophy7 = 1;
            }
            if (trophyStage == 8)
            {
                DataManager.Instance.playerData.Trophy8 = 1;
            }
            if (trophyStage == 9)
            {
                DataManager.Instance.playerData.Trophy9 = 1;
            }
            if (trophyStage == 10)
            {
                DataManager.Instance.playerData.Trophy10 = 1;
            }
            if (trophyStage == 11)
            {
                DataManager.Instance.playerData.Trophy11 = 1;
            }
            if (trophyStage == 12)
            {
                DataManager.Instance.playerData.Trophy12 = 1;
            }
            if (trophyStage == 13)
            {
                DataManager.Instance.playerData.Trophy13 = 1;
            }
            if (trophyStage == 14)
            {
                DataManager.Instance.playerData.Trophy14 = 1;
            }
            if (trophyStage == 15)
            {
                DataManager.Instance.playerData.Trophy15 = 1;
            }
            if (trophyStage == 16)
            {
                DataManager.Instance.playerData.Trophy16 = 1;
            }
            if (trophyStage == 17)
            {
                DataManager.Instance.playerData.Trophy17 = 1;
            }
            if (trophyStage == 18)
            {
                DataManager.Instance.playerData.Trophy18 = 1;
            }
            if (trophyStage == 19)
            {
                DataManager.Instance.playerData.Trophy19 = 1;
            }
            if (trophyStage == 20)
            {
                DataManager.Instance.playerData.Trophy20 = 1;
            }

            if (trophyStage == 21)
            {
                DataManager.Instance.playerData.Trophy21 = 1;
            }
            if (trophyStage == 22)
            {
                DataManager.Instance.playerData.Trophy22 = 1;
            }
            if (trophyStage == 23)
            {
                DataManager.Instance.playerData.Trophy23 = 1;
            }
            if (trophyStage == 24)
            {
                DataManager.Instance.playerData.Trophy24 = 1;
            }
            if (trophyStage == 25)
            {
                DataManager.Instance.playerData.Trophy25 = 1;
            }
            if (trophyStage == 26)
            {
                DataManager.Instance.playerData.Trophy26 = 1;
            }
            if (trophyStage == 27)
            {
                DataManager.Instance.playerData.Trophy27 = 1;
            }
            if (trophyStage == 28)
            {
                DataManager.Instance.playerData.Trophy28 = 1;
            }
            if (trophyStage == 29)
            {
                DataManager.Instance.playerData.Trophy29 = 1;
            }
            if (trophyStage == 30)
            {
                DataManager.Instance.playerData.Trophy30 = 1;
            }

            if (hitInfo.gameObject.CompareTag("Magnet"))
            {
                pulling = true;
            }

        }

    }
}
