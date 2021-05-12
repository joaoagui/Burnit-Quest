using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    
    public Rigidbody2D rb;
    public Animator animator;
    public Transform firePoint;

    public GameObject projectile;
    public GameObject projectile2;
    public GameObject projectile3;
    public GameObject superProjectile;

    public static int combo = 0;

    public float swimSpeed = 16;
    public GameObject bubblesParticle;


    public CircleCollider2D magnet;

    public static bool isGrounded;
    //private bool bounce = false;
    public static bool hasKey = false;
    public static bool hasShield;

    [SerializeField] private LayerMask WhatIsGround;

    public bool underwater = false;


    //[SerializeField] private LayerMask WhatIsEnemy;

    private void Start()
    {
        magnet.radius =    DataManager.Instance.playerData.magnetRange;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.66f, transform.position.y - 2.2f), new Vector2(transform.position.x + 0.62f, transform.position.y + 0.2f), WhatIsGround);
        if (rb.velocity.y < 0)

        {
            animator.SetBool("Jumping", false);
        }

        if (isGrounded == false)
        {
            animator.SetBool("OnAir", true);
        }
        else
        {
            animator.SetBool("OnAir", false);
        }
    }

    void JumpFinished()
    {
        animator.SetBool("Jumping", false);
    }

    void PunchFinished()
    {
        animator.SetBool("Punch", false);
    }

    public void Swim()
    {
        rb.AddForce(new Vector2(0, swimSpeed), ForceMode2D.Impulse);
        Instantiate(bubblesParticle, new Vector2(transform.position.x, transform.position.y) , Quaternion.identity);
    }
    

    void FireProjectile()
    {
        if(   DataManager.Instance.playerData.punchCombo == 0 || (   DataManager.Instance.playerData.punchCombo == 1 && combo < 4))
        {
            GameObject newBullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        }

        if(   DataManager.Instance.playerData.punchCombo == 1 && combo >= 4)
        {
            combo = 0;
            Instantiate(superProjectile, firePoint.position, firePoint.rotation);            
        }

        if (   DataManager.Instance.playerData.multishots >= 1)
        {
            GameObject multishot1 = Instantiate(projectile2, firePoint.position, firePoint.rotation);
            multishot1.transform.Rotate(0, 0, 20);
        }

        if (   DataManager.Instance.playerData.multishots == 2)
        {
            GameObject multishot2 = Instantiate(projectile3, firePoint.position, firePoint.rotation);
            multishot2.transform.Rotate(0, 0, 10);
        }

    }

    public void Sleep()
    {
        animator.SetBool("Sleep", true);
    }

}
