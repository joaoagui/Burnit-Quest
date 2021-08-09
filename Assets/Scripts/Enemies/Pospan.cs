using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pospan : MonoBehaviour
{

    public int level = 1;
    public TextMeshPro levelTxt;

    public float speed;
    public float Health = 3;
    public Rigidbody2D rb;
    public GameObject dmgText;
    //public GameObject deathEffect;
    public GameObject damageParticles;
    public GameObject sporDie;

    private float invincibilityTimer;
    private IEnumerator coroutine;

    private bool woke = false;
    private bool wokeTriggered = false;
    private float distance;

    public AudioClip die;
    public AudioClip wakeUp;
    AudioSource AudioSource;

    public SpriteRenderer sprite;

    private Material defaultMaterial;
    public Material dmgMaterial;

    //lifebar
    private float lerpTimer;
    private float chipSpeed = 2;
    public float maxHealth;
    public GameObject lifebar;
    public GameObject frontHealthBar;
    public GameObject backHealthBar;

    public Transform player;

    public Animator animator;


    private Vector3 zAxis = new Vector3(0, 0, 1);

    private void Start()
    {
        //health and lifebar setup
        Health = Health + level;
        maxHealth = Health;
        lifebar.SetActive(false);

        AudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        defaultMaterial = sprite.material;
    }


    void Update()
    {
        invincibilityTimer -= Time.deltaTime * 2;
        levelTxt.text = "" + level;
        distance = Vector2.Distance(player.position, transform.position);

        if(woke== true && distance  > 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, .1f);
        }

        if (player.position.y >= transform.position.y && wokeTriggered == false)
        {
            wokeTriggered = true;
            AudioSource.Stop();
            AudioSource.PlayOneShot(wakeUp, 1f);
            animator.SetBool("Woke", true);
        }
        
        if(woke == true && PauseMenu.paused == false)
        {
            //Keep rotation torwards player
            var offset = 90f;
            Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset + 90));


            //Rotate around player
            transform.RotateAround(player.position, zAxis, speed);
        }

        //healthbar
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void WakeUp()
    {
        woke = true;
    }

    //flash when take damage
    public IEnumerator Flash()
    {
        sprite.material = dmgMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = defaultMaterial;
    }

    //update healthbar
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.transform.localScale.x;
        float fillB = backHealthBar.transform.localScale.x;
        float hFraction = Health / maxHealth;
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
        Health -= Bullet.dmgTotal;

        if (Health > 0)
        {
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }


        if (Health < 1)
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
        Health -= bulletSuper.superDmgTotal;

        if (Health > 0)
        {
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }


        if (Health < 1)
        {
            Destroy(gameObject);
            Die();
        }
    }


    void Die()
    {
        GameObject sporDead = Instantiate(sporDie, transform.position, Quaternion.identity);

        AudioSource.PlayOneShot(die, 0.7f);
        Destroy(gameObject);

    }


}

