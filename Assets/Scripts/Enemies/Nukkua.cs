using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Nukkua : MonoBehaviour
{
    public int level = 1;
    public TextMeshPro levelTxt;

    public float speed;
    public float nukkuaHealth = 3;
    public Rigidbody2D rb;
    public GameObject dmgText;
    //public GameObject deathEffect;
    public GameObject damageParticles;
    public GameObject nukkuaDie;

    private float invincibilityTimer;
    private IEnumerator coroutine;

    private bool walkLeft = false;
    public AudioClip die;
    AudioSource AudioSource;
    public Animator animator;

    private SpriteRenderer sprite;

    private Material defaultMaterial;
    public Material dmgMaterial;

    public float attackTimer = 8;
    public Transform firePoint;
    public GameObject shot;

    public AudioSource audioSource;
    public AudioClip shootClip;


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
        nukkuaHealth = nukkuaHealth + level;
        maxHealth = nukkuaHealth;
        lifebar.SetActive(false);

        AudioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        defaultMaterial = sprite.material;
    }


    void Update()
    {
        invincibilityTimer -= Time.deltaTime * 2;
        levelTxt.text = "" + level;
        attackTimer -= Time.deltaTime;

        if (PauseMenu.paused == false && attackTimer > 0)
        {
            if (walkLeft == true)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }

        else if(attackTimer<= 0)
        {
            animator.SetBool("Attack", true);
        }

        //healthbar
        nukkuaHealth = Mathf.Clamp(nukkuaHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void Attack()
    {
        GameObject newShot = Instantiate(shot, firePoint.position, Quaternion.identity);
        newShot.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4, 10), ForceMode2D.Impulse);
        newShot.transform.Rotate(0, 0, -90);
        attackTimer = 4;
        animator.SetBool("Attack", false);
        AudioSource.PlayOneShot(shootClip, 1f);

    }

    //flash when take damage
    public IEnumerator Flash()
    {
        sprite.material = dmgMaterial;
        rb.AddForce(new Vector2(60, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        sprite.material = defaultMaterial;
    }

    //update healthbar
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.transform.localScale.x;
        float fillB = backHealthBar.transform.localScale.x;
        float hFraction = nukkuaHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.transform.localScale = new Vector2(hFraction, 1f);
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.transform.localScale = new Vector2((Mathf.Lerp(fillB, hFraction, percentComplete)), 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flipper") || collision.gameObject.CompareTag("Crate"))
        {
            walkLeft = !walkLeft;
            Flip();
        }

        if (collision.gameObject.CompareTag("Bullet") && invincibilityTimer <= 0)
        {
            invincibilityTimer = 0.1f;
            TakeDamage();
        }

        else if (collision.gameObject.CompareTag("SuperBullet") && invincibilityTimer <= 0)
        {
            invincibilityTimer = 0.1f;
            TakeSuperDamage();
        }
    }



    void Flip() //flips when collides with a solid object
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
        lifebar.transform.localScale *= new Vector2(-1, 1);

    }

    void TakeDamage()
    {
        lifebar.SetActive(true);
        lerpTimer = 0f;
        coroutine = Flash();
        StartCoroutine(coroutine);
        nukkuaHealth -= Bullet.dmgTotal;

        if (nukkuaHealth > 0)
        {
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }


        if (nukkuaHealth < 1)
        {
            Destroy(gameObject);
            Die();
        }
    }


    void TakeSuperDamage()
    {
        lifebar.SetActive(true);
        lerpTimer = 0f;
        coroutine = Flash();
        StartCoroutine(coroutine);
        nukkuaHealth -= bulletSuper.superDmgTotal;

        if (nukkuaHealth > 0)
        {
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }


        if (nukkuaHealth < 1)
        {
            Destroy(gameObject);
            Die();
        }
    }


    void Die()
    {
        GameObject sporDead = Instantiate(nukkuaDie, transform.position, Quaternion.identity);

        if (walkLeft == false)
        {
            sporDead.transform.localScale = new Vector2(-1, 1);
        }

        AudioSource.PlayOneShot(die, 0.7f);
        Destroy(gameObject);

    }


}
