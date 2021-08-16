using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
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
    public float shotNumber; //controls how many times each animation runs

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

    public void Shoot()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossShoot, 0.8f);
            Instantiate(enemyProjectile, firePoint.position, Quaternion.identity);
        }
    }

    public void Move()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossMove, 0.8f);
            rb.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
        }
    }

    public void TentacleAttack()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(bossMove, 0.8f);
            rb.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
        }
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
        StageEnd.transform.position = new Vector2(rb.transform.position.x + 20, StageEnd.transform.position.y);
        Destroy(gameObject);
        Destroy(LifeBar, 2f);
    }
}
