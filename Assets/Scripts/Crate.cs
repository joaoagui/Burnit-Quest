using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject breakEffect;

    //objects to spawn
    public GameObject coin;
    public GameObject key;
    public GameObject heart;

    private bool broken = false;

    private Rigidbody2D rb;

    public bool hasHeart = false;
    public bool hasCoin = false;
    public bool hasKey = false;

    public bool OverPlayer;
    public LayerMask Player;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        OverPlayer = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.8f, transform.position.y - 1.8f), new Vector2(transform.position.x + 0.8f, transform.position.y + 0f), Player);

        if (rb.transform.position.y < -16)
        {
            Destroy(gameObject);
        }

        if (OverPlayer == true)
        {
            Break();
        }

    }

    public void Break()
    {
        if(broken == false)
        {
            broken = true;
            Instantiate(breakEffect, transform.position, Quaternion.identity);
            if (hasCoin == true)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            else if (hasHeart == true)
            {
                Instantiate(heart, transform.position, Quaternion.identity);
            }
            else if (hasKey == true)
            {
                Instantiate(key, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }


    public void FinishedSpawning()
    {
        animator.SetBool("Spawned", false);
    }
}
