using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss2 : MonoBehaviour
{
    public CinemachineVirtualCamera Camera;

    public SpriteRenderer sprite;
    private Material defaultMaterial;
    public Material dmgMaterial;
    private IEnumerator coroutine;

    private Rigidbody2D rb;
    public Rigidbody2D Prb;
    public float speed = 12f;

    public GameObject coin;
    public GameObject enemyProjectile;
    public Animator animator;
    public Transform firePoint;
    public float cycles; //controls how many times each animation runs

    //audio
    public AudioSource AudioSource;
    public AudioClip bossDamage;

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
        if (rb.transform.position.x - Prb.transform.position.x >= 30)
        {
            cycles = 3;
        }
    }

    public void Spit()
    {
        if (PauseMenu.paused == false)
        {
            rb.velocity = new Vector2(speed, 0);
            cycles += 1f;

        }

    }

    public void Shoot()
    {
        if (PauseMenu.paused == false)
        {
            Instantiate(enemyProjectile, firePoint.position, Quaternion.identity);
        }
    }

    public void Move()
    {
        if (PauseMenu.paused == false)
        {
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

            if (BossHealth.health <= 0)
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
