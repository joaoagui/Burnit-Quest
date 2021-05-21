using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public SpriteRenderer sprite;
    private Material defaultMaterial;
    public Material dmgMaterial;
    private IEnumerator coroutine;

    private Rigidbody2D rb;
    public Rigidbody2D Prb;
    public float speed = 12f;

    //Shooting/Spitting Mechanics
    public float spitRandomizer = 0;
    
    public GameObject crate;
    public GameObject schlaf;
    public GameObject coin;
    public GameObject enemyProjectile;
    public Animator animator;
    public Transform firePoint;
    public Transform spitPoint;
    public GameObject particleSpawn;
    public float cycles; //controls how many times each animation runs

    //audio
    public AudioSource AudioSource;
    public AudioClip bossMove;
    public AudioClip bossDamage;
    public AudioClip bossFart;
    public AudioClip bossSpit;

    //die

    public GameObject StageEnd; 
    public GameObject BossDie;
    public GameObject LifeBar;
    public Transform diePoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultMaterial = sprite.material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Cycles", cycles);
        if(rb.transform.position.x - Prb.transform.position.x >= 30)
        {
            cycles = 3;
        }
    }

    public void Spit()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossMove, 0.8f);
            rb.velocity = new Vector2(speed , 0);
            cycles += 1f;

            spitRandomizer = Random.Range(0f, 10f);
            if (spitRandomizer < 7)
            {
                AudioSource.PlayOneShot(bossSpit, 0.8f);
                GameObject crateInstance = Instantiate(crate, spitPoint.position, Quaternion.identity);
                Rigidbody2D crateInstanceRB = crateInstance.GetComponent<Rigidbody2D>();
                crateInstanceRB.velocity = new Vector2 (-3f,6f);
                Animator crateInstanceAnimator = crateInstance.GetComponent<Animator>();
                crateInstanceAnimator.SetBool("Spawned", true);
                Instantiate(particleSpawn, spitPoint.position, Quaternion.identity);

                if (spitRandomizer <2.1f)
                {
                    crateInstance.GetComponent<Crate>().hasCoin = true;
                }
                else if (spitRandomizer > 3.9f)
                {
                    crateInstance.GetComponent<Crate>().hasHeart = true;
                }
            }

            else if (spitRandomizer >= 7)
            {
                AudioSource.PlayOneShot(bossSpit, 0.8f);
                GameObject schlafInstance = Instantiate(schlaf, spitPoint.position, Quaternion.identity);
                Animator schlafInstanceAnimator = schlafInstance.GetComponent<Animator>();
                schlafInstanceAnimator.SetBool("Spawned", true);
                Rigidbody2D schlafInstanceRB = schlafInstance.GetComponent<Rigidbody2D>();
                schlafInstanceRB.velocity = new Vector2(-3f, 6f);
            

                Instantiate(particleSpawn, spitPoint.position, Quaternion.identity);
            }
        }

    }

    public void Shoot()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossFart, 0.8f);
            Instantiate(enemyProjectile, firePoint.position, Quaternion.identity);
        }
    }

    public void Move()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossMove, 0.8f);
            rb.velocity = new Vector2(speed, 0);
        }
    }

    public void Rest()
    {
        cycles = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet") && BossHealth.health > 0)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            AudioSource.PlayOneShot(bossDamage, 1f);
            BossHealth.TakeDamage();
            GameObject crateInstance = Instantiate(coin, firePoint.position, Quaternion.identity);

            if(BossHealth.health <= 0)
            {
                AudioSource.PlayOneShot(bossDamage, 1f);
                Die();
            }
        }



        else if (collision.gameObject.CompareTag("SuperBullet") && BossHealth.health > 0)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            AudioSource.PlayOneShot(bossDamage, 1f);
            BossHealth.TakeSuperDamage();
            GameObject crateInstance = Instantiate(coin, firePoint.position, Quaternion.identity);

            if (BossHealth.health <= 0)
            {
                AudioSource.PlayOneShot(bossDamage, 1f);
                Die();
            }
        }


    }

    public IEnumerator Flash()
    {
        sprite.material = dmgMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = defaultMaterial;
    }

    public void Die()
    {
        Instantiate(BossDie, diePoint.position, Quaternion.identity);
        StageEnd.transform.position = new Vector2(rb.transform.position.x + 20, StageEnd.transform.position.y);
        Destroy(gameObject);
        Destroy(LifeBar, 2f);
    }
}
