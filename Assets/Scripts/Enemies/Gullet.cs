using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gullet : MonoBehaviour
{
    public int level = 1;
    public TextMeshPro levelTxt;

    public float speed;
    public float gulletHealth = 1;
    public GameObject dmgText;
    //public GameObject deathEffect;
    public GameObject damageParticles;
    public GameObject gulletDead;

    private float invincibilityTimer;
    private IEnumerator coroutine;

    AudioSource AudioSource;

    private SpriteRenderer sprite;
    private Animator animator;

    private Material defaultMaterial;
    public Material dmgMaterial;


    public Transform eggPoint;
    public GameObject eggObject;
    public float moveTrigger;
    public float dropTrigger;
    public bool isMoving;
    public bool eggDropped;
    bool hasEgg = true;

    public LayerMask whatIsPlayer;

    //lifebar
    private float lerpTimer;
    private float chipSpeed = 2;
    public float maxHealth;
    public GameObject lifebar;
    public GameObject frontHealthBar;
    public GameObject backHealthBar;

    public AudioClip gulletEnter;

    private void Start()
    {
        //health and lifebar setup
        gulletHealth = gulletHealth + level;
        maxHealth = gulletHealth;
        lifebar.SetActive(false);

        animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        defaultMaterial = sprite.material;
    }


    void Update()
    {
        isMoving = Physics2D.OverlapArea(new Vector2(transform.position.x - moveTrigger, transform.position.y - moveTrigger), new Vector2(transform.position.x + moveTrigger, transform.position.y + moveTrigger), whatIsPlayer);
        eggDropped = Physics2D.OverlapArea(new Vector2(transform.position.x - dropTrigger, transform.position.y - dropTrigger), new Vector2(transform.position.x + dropTrigger, transform.position.y + dropTrigger), whatIsPlayer);

        if (eggDropped == true && hasEgg == true)
        {
            Rigidbody2D eggRB;

            hasEgg = false;
            animator.SetBool("Egg", false);
            GameObject newEgg = Instantiate(eggObject, eggPoint.position, Quaternion.identity);

            eggRB = newEgg.GetComponent<Rigidbody2D>();
            eggRB.AddForce(new Vector2(-4, 0), ForceMode2D.Impulse);
            AudioSource.PlayOneShot(gulletEnter, 0.8f);
        }

        invincibilityTimer -= Time.deltaTime * 2;
        levelTxt.text = "" + level;

        if (PauseMenu.paused == false && isMoving == true)
        {
            transform.Translate(-speed,0,0);
        }

        //healthbar
        gulletHealth = Mathf.Clamp(gulletHealth, 0, maxHealth);
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
        float hFraction = gulletHealth / maxHealth;
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


        void TakeDamage()
        {
            lifebar.SetActive(true);
            lerpTimer = 0f;
            coroutine = Flash();
            StartCoroutine(coroutine);
            gulletHealth -= Bullet.dmgTotal;

            if (gulletHealth > 0)
            {
                Instantiate(damageParticles, transform.position, Quaternion.identity);
            }

            if (gulletHealth < 1)
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
            gulletHealth -= bulletSuper.superDmgTotal;

            if (gulletHealth > 0)
            {
                Instantiate(damageParticles, transform.position, Quaternion.identity);
            }


            if (gulletHealth < 1)
            {
                Destroy(gameObject);
                Die();
            }
        }

        void Die()
        {
            Instantiate(gulletDead, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
