using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float BumpPower;
    public AudioSource bump;
    private Rigidbody2D rb;
    public bool Multiplayer = false;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            rb = hitInfo.gameObject.GetComponent<Rigidbody2D>();
            Health.invincibilityTimer = 0;
            rb.velocity = new Vector2(BumpPower * -1, 2);
            bump.Play();
        }

        if (hitInfo.gameObject.CompareTag("Chay") && Multiplayer == true)
        {
            rb = hitInfo.gameObject.GetComponent<Rigidbody2D>();
            Health.invincibilityTimerP2 = 0;
            rb.velocity = new Vector2(BumpPower * -1, 2);
            bump.Play();
        }
    }
}
