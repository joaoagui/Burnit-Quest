using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Yuxu : MonoBehaviour
{
    public int level = 1;
    public TextMeshPro levelTxt;

    public bool JumpLeft;
    public float YuzuHealth = 6;
    public float jumpPower = 12;
    private Rigidbody2D rb ;
    public GameObject damageParticles;
    public GameObject yuzuDie;
    public Animator animator;

    private AudioSource AudioSource;
    public AudioClip die;
    public AudioClip jump;

    public LayerMask WhatIsGround;
    private bool isGrounded;

    //invincibility timer and flashing when taking dmg
    private float invincibilityTimer;
    private IEnumerator coroutine;
    private SpriteRenderer sprite;
    private Material defaultMaterial;
    public Material dmgMaterial;


    //lifebar
    private float lerpTimer;
    private float chipSpeed = 2;
    public float maxHealth;
    public GameObject lifebar;
    public GameObject frontHealthBar;
    public GameObject backHealthBar;

    private void Start()
    {
        //health and lifebar setup
        YuzuHealth = YuzuHealth + level;
        maxHealth = YuzuHealth;
        lifebar.SetActive(false);

        //get components
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
        defaultMaterial = sprite.material;
    }

    private void FixedUpdate()
    {
        invincibilityTimer -= Time.deltaTime * 2;
        levelTxt.text = "" + level;
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 4f, transform.position.y - 3f), new Vector2(transform.position.x + 4f, transform.position.y + 3f), WhatIsGround);

        if (isGrounded == true)
        {
            animator.SetBool("Grounded", true);
            
        }
        if(rb.velocity.y > 0)
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Grounded", false);
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("Jumping", false);
        }

        YuzuHealth = Mathf.Clamp(YuzuHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.transform.localScale.x;
        float fillB = backHealthBar.transform.localScale.x;
        float hFraction = YuzuHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.transform.localScale = new Vector2(hFraction, 1f);
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.transform.localScale = new Vector2((Mathf.Lerp(fillB, hFraction, percentComplete)), 1f);
        }
    }

    public void PrepareJump()
    {
        animator.SetBool("Jumping", true);
    }

    public void Jump()
    {
        if (PauseMenu.paused == false)
        {
            if (JumpLeft == false)
            {
                rb.velocity = new Vector2(8f, jumpPower);
                JumpLeft = true;
                AudioSource.PlayOneShot(jump, 0.7f);
            }

            else
            {
                rb.velocity = new Vector2(-8f, jumpPower);
                JumpLeft = false;
                AudioSource.PlayOneShot(jump, 0.7f);
            }

        }
               
    }

    public IEnumerator Flash()
    {
        sprite.material = dmgMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = defaultMaterial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet") && invincibilityTimer <= 0)
        {
            invincibilityTimer = 0.5f;
            TakeDamage();
        }

    }

    public void TakeDamage()
    {
        lifebar.SetActive(true);
        lerpTimer = 0f;

            coroutine = Flash();
            StartCoroutine(coroutine);
            YuzuHealth -= Bullet.dmgTotal;
            Instantiate(damageParticles, transform.position, Quaternion.identity);

        if (YuzuHealth < 1)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(yuzuDie, transform.position, Quaternion.identity);
        AudioSource.PlayOneShot(die, 0.7f);
        Destroy(gameObject);
    }
}
