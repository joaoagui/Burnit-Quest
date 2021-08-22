using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss3 : MonoBehaviour
{
    public SpriteRenderer sprite;
    private Material defaultMaterial;
    public Material dmgMaterial;
    private IEnumerator coroutine;

    private Rigidbody2D rb;
    public Transform playerTransform;
    public float speed = 12f;
    public GameObject bubbleParticles;
    public GameObject bubblePoint;


    public CinemachineTargetGroup CMgroup;

    public GameObject coin;
    public GameObject enemyProjectile;
    public GameObject enemyTentacle;
    private float randomizer;

    public Animator animator;
    public Transform firePoint;
    public float shotNumber; //controls how many times each animation runs


    public bool shooting;
    public bool tentacle;
    public float tentacleNumber;
    private float heightmodifier;


    //audio
    public AudioSource AudioSource;
    public AudioClip bossMove;
    public AudioClip bossDamage;
    public AudioClip bossTentacleAttack;
    public AudioClip bossShoot;


    //die

    public GameObject StageEnd;
    public GameObject BossDie;
    public GameObject LifeBar;
    public Transform diePoint;

    public GameObject Trophy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultMaterial = sprite.material;
    }

    private void Update()
    {
        if((transform.position.y - playerTransform.position.y) >= 20)
        {
            CMgroup.m_Targets[1].weight = 0;
        }

        else if ((transform.position.y - playerTransform.position.y) < 20)
        {
            CMgroup.m_Targets[1].weight = 1;
        }

        randomizer = Random.Range(0, 10);

        animator.SetBool("Tentacles", tentacle);
        animator.SetFloat("Shots", shotNumber);

        if(shotNumber < 1)
        {
            tentacle = true;
        }

        else if (shotNumber >= 1)
        {
            tentacle = false;
        }
    }

    public void Shoot()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossShoot, 0.8f);
            Instantiate(enemyProjectile, firePoint.position, Quaternion.identity);
            shotNumber -= 1;
        }
    }

    public void Move()
    {
        if (PauseMenu.paused == false)
        {
            if ((transform.position.y - playerTransform.position.y) < 20 && transform.position.y < 660)
            {
                AudioSource.PlayOneShot(bossMove, 0.8f);
                rb.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
                Instantiate(bubbleParticles, bubblePoint.transform.position, Quaternion.identity);

            }
        }
    }

    public void TentacleAttack()
    {

        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossMove, 0.8f);
            heightmodifier = Random.Range(0, 10);

            if (randomizer > 5 )
            {
                GameObject newTentacle = Instantiate(enemyTentacle, new Vector2(2.5f, playerTransform.position.y + heightmodifier), Quaternion.Euler(0,0,90));
                newTentacle.transform.localScale = new Vector2(1, 1);
            }

            if (randomizer <= 5)
            {
                GameObject newTentacle = Instantiate(enemyTentacle, new Vector2(-2.5f, playerTransform.position.y + heightmodifier), Quaternion.Euler(0, 0, 90));
                newTentacle.transform.localScale = new Vector2(1, -1);
            }
        }
    }

    public void TentacleFinished()
    {
        tentacle = false;
        shotNumber = Random.Range(1,2);
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
        if (Health.health >= DataManager.Instance.playerData.numOfHearts)
        {
            Trophy.SetActive(true);
        }

        Instantiate(BossDie, diePoint.position, Quaternion.identity);
        StageEnd.SetActive(true);
        Destroy(gameObject);
        Destroy(LifeBar, 2f);
    }
}
