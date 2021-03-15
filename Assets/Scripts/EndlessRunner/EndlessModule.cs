using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessModule : MonoBehaviour
{
    public GameObject Module;
    private GameObject Player;

    public int enterHeight;

    public int exitHeight;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
    }
    void Update()
    {
        if (Module.transform.position.x <= Player.transform.position.x -40)
        {
            Destroy(gameObject);
        }
    }
}
