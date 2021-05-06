using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float BumpPower;
    private Rigidbody2D rb;
    public bool Multiplayer = false;

    public Animator animator;
    [Range(0,1)]
    public float rotationSpeed;

    public AudioClip hammerWoosh;
    AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        animator.speed = rotationSpeed;
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            rb = hitInfo.gameObject.GetComponent<Rigidbody2D>();
            Health.invincibilityTimer = 0;
            rb.velocity = new Vector2(BumpPower * -1, 2);
        }

        if (hitInfo.gameObject.CompareTag("Chay") && Multiplayer == true)
        {
            rb = hitInfo.gameObject.GetComponent<Rigidbody2D>();
            Health.invincibilityTimerP2 = 0;
            rb.velocity = new Vector2(BumpPower * -1, 2);
        }
    }


    public void HammerWoosh()
    {
        AudioSource.PlayOneShot(hammerWoosh, 0.8f);
    }
}
