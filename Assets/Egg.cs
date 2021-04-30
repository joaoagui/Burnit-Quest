using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    private bool broken;
    public GameObject breakEffect;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Bullet"))

        Instantiate(breakEffect, transform.position, Quaternion.identity);
        broken = true;
        Destroy(gameObject);
    }


}