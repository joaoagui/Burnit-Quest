using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopManager : MonoBehaviour
{
    public static bool CoopEnabled = false;
    public bool hamSpawned = false;
    

    public GameObject hamspotter;
    public GameObject P2Interface;

    public GameObject spawnParticles;

    public GameObject regata;
    //public GameObject riponga;
    public string currentHamster = "regata";


    // Start is called before the first frame update
    void Start()
    {
        if(CoopEnabled == false)
        {
            Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
            hamspotter.SetActive(false);
            P2Interface.SetActive(false);

        }
        else if(CoopEnabled == true)
        {
            Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
            hamspotter.SetActive(true);
            P2Interface.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {

        if(CoopEnabled == true && hamSpawned == false)
        {
            hamSpawned = true;
            Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
            hamspotter.SetActive(true);
            P2Interface.SetActive(true);

        }


        else if (CoopEnabled == false && hamSpawned == true)
        {
            hamSpawned = false;
            Instantiate(spawnParticles, hamspotter.transform.position, Quaternion.identity);
            hamspotter.SetActive(false);
            P2Interface.SetActive(false);
        }
    }

    public void SetCoop(bool coopEnabled)
    {
        CoopEnabled = coopEnabled;
    }
}
