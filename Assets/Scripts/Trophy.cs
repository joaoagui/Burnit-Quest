using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trophy : MonoBehaviour
{

    public int trophyStage = 0;
    public GameObject TrophyUI;
    public GameObject TrophyParticles;


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





        }

    }
}
