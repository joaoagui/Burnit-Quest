using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private bool heartGet = false;
    public GameObject heartParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && heartGet == false)
        {
            heartGet = true;
            Destroy(gameObject);
            Instantiate(heartParticles, transform.position, Quaternion.identity);
            Health.health += 1;
            FindObjectOfType<AudioManager>().Play("heal");
        }

    }
}
