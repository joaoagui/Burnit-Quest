using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject Target;
    public static GameObject key;

    private Follow Follow;

    private void Start()
    {
        Follow = GetComponent<Follow>();
        Follow.enabled = false;
        key = GetComponent<GameObject>();
        Target = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Player.hasKey == false)
        {
            Player.hasKey = true;
            Follow.enabled = true;
            FindObjectOfType<AudioManager>().Play("key");
        }
    }

}
