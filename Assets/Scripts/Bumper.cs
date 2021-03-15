using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Rigidbody2D rb;
    public float BumpPower;
    private Animator animator;
    public AudioSource bump;

    public float maxHeight;
    private float minHeight;
    public bool verticalMove;
    private bool movingUP = true;


    private void Start()
    {
              
        minHeight = transform.position.y;
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            rb = hitInfo.gameObject.GetComponent<Rigidbody2D>();
            Health.invincibilityTimer = 0;
            rb.velocity = new Vector2(BumpPower * -1, 2);
            animator.SetBool("NotBumping", true);
            bump.Play();
        }
    }

    public void StopBumping()
    {
        animator.SetBool("NotBumping", false);
    }

    void Update()
    {
        if (PauseMenu.paused == false)
        {
            if(verticalMove == true && movingUP == true)
            {
                transform.Translate(Vector2.up * 4 * Time.deltaTime);
            }

            if (verticalMove == true && movingUP == false)
            {
                transform.Translate(Vector2.down * 4 * Time.deltaTime);
            }

            if ( this.transform.position.y <= minHeight)
            {
                movingUP = true;
            }
            if (this.transform.position.y >= maxHeight)
            {
                movingUP = false;
            }
        }
    }
}
