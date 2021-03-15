using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startcooldown;
    private float cooldown;
    public GameObject gameObj;

    // Update is called once per frame

    private void Start()
    {
        cooldown = startcooldown;
    }


    void FixedUpdate()
    {
        cooldown = cooldown - 1f * Time.deltaTime;

            if(cooldown <= 0)
        {
            cooldown = startcooldown;
            Instantiate(gameObj, transform.position, Quaternion.identity);
        }
    }
}
