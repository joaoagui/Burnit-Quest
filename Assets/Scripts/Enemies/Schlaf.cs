using System.Collections;
using UnityEngine;
using TMPro;

public class Schlaf : MonoBehaviour
{


    private bool box = true;
    private bool hidden = true;

    [Header("Schlaf Stats")]
    public int level = 1;
    public TextMeshPro levelTxt;
    public float SchlafHealth = 5;
    public float speed = 0.5f;
    public Transform boxPoint;
    private Rigidbody2D rb;
    public GameObject damageParticles;
    public GameObject schlafDie;
    public GameObject splinters;
    private Animator animator;
    public PhysicsMaterial2D slide;
    private bool walkLeft = true;

    [Header("Detect Player System")]
    private bool detectPlayer;
    private bool overPlayer;
    public LayerMask player;
    public AudioSource AudioSource;
    public AudioClip schlafEnter;
    public AudioClip schlafMove;

    private float invincibilityTimer;
    private IEnumerator coroutine;
    private SpriteRenderer sprite;

    [Header("Lifebar")]
    private float lerpTimer;
    private float chipSpeed = 2;
    public float maxHealth = 100;
    public GameObject lifebar;
    public GameObject frontHealthBar;
    public GameObject backHealthBar;

    [Header("Materials for Flashing")]
    private Material defaultMaterial;
    public Material dmgMaterial;

    void Start()
    {
        //health and lifebar setup
        SchlafHealth = SchlafHealth + level;
        maxHealth = SchlafHealth;
        lifebar.SetActive(false);

        //get components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        defaultMaterial = sprite.material;
    }
    private void FixedUpdate()
    {
        invincibilityTimer -= Time.deltaTime * 2;
        detectPlayer = Physics2D.OverlapArea(new Vector2(transform.position.x - 8f, transform.position.y - 0.5f), new Vector2(transform.position.x + 1f, transform.position.y + 0.5f), player);
        overPlayer = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.8f, transform.position.y - 1.8f), new Vector2(transform.position.x + 0.8f, transform.position.y + 0f), player);

        if (hidden == true && detectPlayer == true)
        {
            GetComponent<Rigidbody2D>().sharedMaterial = slide;
            hidden = false;
            animator.SetBool("Hidden", false);
            AudioSource.PlayOneShot(schlafEnter, 0.8f);
        }

        if(overPlayer == true)
        {
            rb.transform.position = new Vector2(rb.transform.position.x -2.5f, rb.position.y);
            overPlayer = false;
        }

        //healthbar
        levelTxt.text = "" + level;
        SchlafHealth = Mathf.Clamp(SchlafHealth, 0, maxHealth);
        UpdateHealthUI();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Flipper") || collision.gameObject.CompareTag("Crate"))
        {
            rb.velocity = new Vector2(0, 0);
            walkLeft = !walkLeft;
            SpriteRenderer spriteSchlaf = GetComponent<SpriteRenderer>();

            if (walkLeft == true)
            {                
                spriteSchlaf.flipX = false;
            }
            if (walkLeft == false)
            {                
                spriteSchlaf.flipX = true;
            }
        }

        if (collision.gameObject.CompareTag("Bullet") && invincibilityTimer <= 0)
        {
            invincibilityTimer = 0.5f;
            TakeDamage();
        }

        else if (collision.gameObject.CompareTag("SuperBullet") && invincibilityTimer <= 0)
        {
            invincibilityTimer = 0.1f;
            TakeSuperDamage();
        }

    }

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
        float hFraction = SchlafHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.transform.localScale = new Vector2(hFraction, 1f);
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.transform.localScale = new Vector2((Mathf.Lerp(fillB, hFraction, percentComplete)), 1f);
        }
    }

    public void TakeDamage()
    {
        lifebar.SetActive(true);
        lerpTimer = 0f;

        if (box == false)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            SchlafHealth -= Bullet.dmgTotal;
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }

        if (box == true)
        {
            Instantiate(splinters, boxPoint.position, Quaternion.identity);
            GetComponent<Rigidbody2D>().sharedMaterial = slide;
            box = false;
            speed = 1;
            animator.SetBool("Angry", true);
            animator.SetBool("Hidden", false);
            AudioSource.PlayOneShot(schlafEnter, 0.8f);
        }

        if (SchlafHealth <= 0)
        {
            Die();
        }
    }


    void TakeSuperDamage()
    {
        lifebar.SetActive(true);
        lerpTimer = 0f;

        if (box == false)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            SchlafHealth -= bulletSuper.superDmgTotal;
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        }

        if (box == true)
        {
            Instantiate(splinters, boxPoint.position, Quaternion.identity);
            GetComponent<Rigidbody2D>().sharedMaterial = slide;
            box = false;
            speed = 1;
            animator.SetBool("Angry", true);
            animator.SetBool("Hidden", false);
            AudioSource.PlayOneShot(schlafEnter, 0.8f);
        }

        if (SchlafHealth < 1)
        {
            Destroy(gameObject);
            Die();
        }
    }


    public void Move()
    {
        if (PauseMenu.paused == false)
        {
                AudioSource.PlayOneShot(schlafMove, 0.8f);
            if (walkLeft == true)
            {
                rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
            }

        }
    }

    void Die()
    {

        GameObject schlafDead = Instantiate(schlafDie, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);

        if (walkLeft == false)
        {
            schlafDead.GetComponent<SpriteRenderer>().flipX = true;
        }
        Destroy(gameObject);
    }
}
