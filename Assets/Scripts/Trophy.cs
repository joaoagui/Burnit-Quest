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
                DataManager.Instance.playerData.Trophy1 = 1;
            }
            if (trophyStage == 12)
            {
                DataManager.Instance.playerData.Trophy2 = 1;
            }
            if (trophyStage == 13)
            {
                DataManager.Instance.playerData.Trophy3 = 1;
            }
            if (trophyStage == 14)
            {
                DataManager.Instance.playerData.Trophy4 = 1;
            }
            if (trophyStage == 15)
            {
                DataManager.Instance.playerData.Trophy5 = 1;
            }
            if (trophyStage == 16)
            {
                DataManager.Instance.playerData.Trophy6 = 1;
            }
            if (trophyStage == 17)
            {
                DataManager.Instance.playerData.Trophy7 = 1;
            }
            if (trophyStage == 18)
            {
                DataManager.Instance.playerData.Trophy8 = 1;
            }
            if (trophyStage == 19)
            {
                DataManager.Instance.playerData.Trophy9 = 1;
            }
            if (trophyStage == 20)
            {
                DataManager.Instance.playerData.Trophy10 = 1;
            }

            if (hitInfo.gameObject.CompareTag("Magnet"))
            {
                pulling = true;
            }

        }

    }
}
