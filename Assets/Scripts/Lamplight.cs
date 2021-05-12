using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamplight : MonoBehaviour
{
    public Animator animator;
    public GameObject sparks;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet enemy = collision.GetComponent<Bullet>();
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("SuperBullet"))
        {
            animator.SetBool("Lit", true);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }

    }
}
