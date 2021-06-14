using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public SpriteRenderer sprite;
    private Material defaultMaterial;
    public Material dmgMaterial;
    private IEnumerator coroutine;

    public Rigidbody2D rb;
    public Rigidbody2D PlayerRb;
    public float speed = 12f;
    private float bonusSpeed = 0;

    public GameObject coin;
    public GameObject spitPlatform;

    private float gravityScale; 
    public GameObject jumpDust;
    public GameObject landDust;


    public Animator animator;
    public Transform firePoint;

    public bool jumping;
    public bool flying;
    public bool spitting;
    public bool tired;

    public bool isGrounded;
    public LayerMask player;
    public LayerMask ground;

    //audio
    public AudioSource AudioSource;
    public AudioClip spitClip;
    public AudioClip flapWingsClip;
    public AudioClip lickClip;
    public AudioClip thudClip;
    public AudioClip jumpClip;
    public AudioClip bossDamage;

    //die
    public GameObject StageEnd;
    public GameObject BossDie;
    public GameObject LifeBar;
    public Transform diePoint;

    public GameObject Trophy;


    private float turnTimer;

    public float flySpeed = 10;

    public MultipleTargetCamera multipleTargetCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        defaultMaterial = sprite.material;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.66f, transform.position.y - 3f), new Vector2(transform.position.x + 0.62f, transform.position.y + 3f), ground);
        turnTimer -= Time.deltaTime;

        if (PauseMenu.paused == false)
        {
                if (isGrounded == true)
            {
                animator.SetBool("Grounded", true);
            }

            if(flying == true && rb.transform.position.x > PlayerRb.transform.position.x -20)
            {
                rb.velocity= new Vector2(-flySpeed, 0);
            }

            if(jumping == true)
            {
                rb.gravityScale = gravityScale;
            }

            if (flying == true && rb.transform.position.x <= PlayerRb.transform.position.x - 20)
            {
                flying = false;
                jumping = true;
                spitting = false;

                if(turnTimer < 0)
                {
                    Turn();
                }

                rb.velocity = new Vector2(0, 0);
                rb.gravityScale = gravityScale;
            }
        }
        animator.SetBool("Jumping", jumping);
        animator.SetBool("Spit", spitting);
    }

    public void JumpForward()
    {
        if (PauseMenu.paused == false && isGrounded == true && jumping == true && rb.transform.position.x < PlayerRb.transform.position.x +20)
        {
            rb.AddForce(new Vector2((140 + bonusSpeed), 360), ForceMode2D.Impulse);
            Instantiate(jumpDust, new Vector2(transform.position.x - 3, transform.position.y - 3), Quaternion.identity);
            AudioSource.PlayOneShot(jumpClip, 1f);
            rb.gravityScale = gravityScale;

            bonusSpeed += 30;

            animator.SetBool("Grounded", false);
        }

        else if (PauseMenu.paused == false && isGrounded == true && jumping == true && rb.transform.position.x >= PlayerRb.transform.position.x + 20)
        {
            bonusSpeed = 0;
            jumping = false;
            spitting = true;
            animator.SetBool("Spit", true);
        }
    }

    public void Turn()
    {
        turnTimer = 1;

        if (PauseMenu.paused == false )
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    public void Land()
    {
        if (PauseMenu.paused == false)
        {
            Instantiate(landDust, new Vector2(transform.position.x - 1, transform.position.y - 3), Quaternion.identity);
            AudioSource.PlayOneShot(thudClip, 1f);
        }
    }

    public void Spit()
    {
        if (PauseMenu.paused == false)
        {
            GameObject newSpitPlatform = Instantiate(spitPlatform, firePoint.position, Quaternion.identity);
            Rigidbody2D spitPlatformRB = newSpitPlatform.GetComponent<Rigidbody2D>();
            spitPlatformRB.AddForce(new Vector2(-40, 8), ForceMode2D.Impulse);
            AudioSource.PlayOneShot(spitClip, 1f);

        }
    }

    public void TakeOff()
    {
        if (PauseMenu.paused == false)
        {
            rb.gravityScale = 0;
            AudioSource.PlayOneShot(flapWingsClip, 1f);
            rb.AddForce(new Vector2(0,60), ForceMode2D.Impulse);
        }
    }

    public void Tongue()
    {
        if (PauseMenu.paused == false)
        {
            AudioSource.PlayOneShot(lickClip, 1f);
        }
    }


    public void FlyBack()
    {
        if (PauseMenu.paused == false)
        {
            flying = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isGrounded == false)
        {
            rb.AddForce(new Vector2(100, 200), ForceMode2D.Impulse);
        }


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

        if (PauseMenu.paused == false)
        {
            Instantiate(BossDie, diePoint.position, Quaternion.identity);
            StageEnd.transform.position = new Vector2(rb.transform.position.x + 20, StageEnd.transform.position.y);
            gameObject.SetActive(false);
            Destroy(LifeBar, 2f);
        }
    }
}
