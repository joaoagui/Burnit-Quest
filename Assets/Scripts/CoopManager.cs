using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopManager : MonoBehaviour
{
    public static bool CoopEnabled = false;
    public bool hamSpawned = true;
    

    public GameObject hamspotter;
    public GameObject P2Interface;

    public GameObject spawnParticles;

    private GameObject[] hamsters;
    private float timerToggle;


    public GameObject regata;
    //public GameObject riponga;
    public string currentHamster = "regata";


    // Start is called before the first frame update
    void Start()
    {
        //if(CoopEnabled == false && regata.activeInHierarchy == true)
        //{
        //    Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
        //    hamspotter.SetActive(false);
        //    P2Interface.SetActive(false);
        //}

        //else if(CoopEnabled == true && regata.activeInHierarchy == false)
        //{
        //    Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
        //    hamspotter.SetActive(true);
        //    P2Interface.SetActive(true);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(hamspotter.activeInHierarchy == true)
        {
            hamSpawned = true;
        }
        else if (hamspotter.activeInHierarchy == false)
        {
            hamSpawned = false;
        }


        if (CoopEnabled == true && hamSpawned == false && regata.activeInHierarchy == false)
        {
            hamSpawned = true;
            Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
            hamspotter.SetActive(true);
            P2Interface.SetActive(true);
        }

        else if (CoopEnabled == false && hamSpawned == true && regata.activeInHierarchy == true)
        {
            hamSpawned = false;
            Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
            hamspotter.SetActive(false);
            P2Interface.SetActive(false);
        }

        if (CoopEnabled == true && P2Interface.activeInHierarchy == false)
        {
            P2Interface.SetActive(true);
        }
        if (CoopEnabled == false && P2Interface.activeInHierarchy == true)
        {
            P2Interface.SetActive(false);
        }
    }

    public void SetCoop(bool coopEnabled)
    {
        CoopEnabled = coopEnabled;
    }
}
