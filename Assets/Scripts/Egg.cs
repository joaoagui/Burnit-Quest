using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    private bool broken =  false;
    public GameObject breakEffect;
    public float lifetime = 3f;


    private void Update()
    {
        transform.Rotate(0, 0, 3 * Time.deltaTime);
        lifetime -= 1f * Time.deltaTime;

        if(lifetime <= 0 && broken == false)
        {
            broken = true;
            BreakEgg();
        }
    }  

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player" && broken == false)
        {
            broken = true;
            BreakEgg();
        }
    }

    public void BreakEgg()
    {
        Instantiate(breakEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}