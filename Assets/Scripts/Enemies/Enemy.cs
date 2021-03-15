using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int level = 1;
    public TextMeshPro levelTxt;

    public float speed;
    public float sporHealth = 3;
    public Rigidbody2D rb;
    public GameObject dmgText;
    //public GameObject deathEffect;
    public GameObject damageParticles;
    public GameObject sporDie;

    private float invincibilityTimer;
    private IEnumerator coroutine;

    private bool walkLeft = true;
    public AudioClip die;
    AudioSource AudioSource;

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
        sporHealth = sporHealth + level;
        maxHealth = sporHealth;
        lifebar.SetActive(false);

        AudioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        defaultMaterial = sprite.material;
    }


    void Update()
    {
        invincibilityTimer -= Time.deltaTime * 2;
        levelTxt.text = "" + level;

        if (PauseMenu.paused == false)
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

        //healthbar
        sporHealth = Mathf.Clamp(sporHealth, 0, maxHealth);
        UpdateHealthUI();

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
        float hFraction = sporHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.transform.localScale = new Vector2(hFraction, 1f);
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.transform.localScale = new Vector2((Mathf.Lerp(fillB, hFraction, percentComplete)),1f);
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
        sporHealth -= Bullet.dmgTotal;

        if(sporHealth > 0)
        {
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }


        if (sporHealth < 1)
        {
            Die();
        }
    }


    void Die()
    {
            GameObject sporDead = Instantiate(sporDie, transform.position, Quaternion.identity);

            if(walkLeft == false)
            {
                sporDead.transform.localScale = new Vector2( -1, 1);
            }

            AudioSource.PlayOneShot(die, 0.7f);
            Destroy(gameObject);

    }


    }

}
