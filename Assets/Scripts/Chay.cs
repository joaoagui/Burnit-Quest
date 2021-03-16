using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Chay : MonoBehaviour
{
    // moving system
    static public float ChaySpeed = 0f;
    static public bool ChayMoving = true;


    public Rigidbody2D rb;
    public float playerSpeed = 7;
    public Animator animator;

    //get player colliders to turn them off
    public EdgeCollider2D playerCollider1;
    public CircleCollider2D playerCollider2;

    //walking dust
    private double dustTimer;
    public Transform dustPoint;
    public GameObject walkDust;
    public PlayableDirector director;

    void Start()
    {
        dustTimer = director.duration;
        animator.SetBool("Moving", true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider1);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider2);
    }


    // Update is called once per frame
    void Update()
    {   

        dustTimer -= 1f * Time.deltaTime;

        if(dustTimer <= 0 && ChaySpeed > 0)
        {
            dustTimer = 2;
            Instantiate(walkDust, dustPoint.position, Quaternion.identity);
        }



        if (PauseMenu.paused == false)
        {
            rb.transform.Translate(new Vector2(ChaySpeed * Time.deltaTime, 0));
            animator.SetFloat("Speed", ChaySpeed);



            //chay adjusts speed if player surpasses him
            if (playerCollider1.transform.position.x > rb.transform.position.x + 2 && playerCollider1.transform.position.x < rb.transform.position.x + 9 && ChayMoving == true)
            {
                ChaySpeed = playerSpeed * 0.75f;
            }

            else if (playerCollider1.transform.position.x < rb.transform.position.x + 2 && ChayMoving == true)
            {
                ChaySpeed =  playerSpeed * 0.4f;
            }

            if (playerCollider1.transform.position.x > rb.transform.position.x + 9 &&  ChayMoving == true)
            {
                ChaySpeed = playerSpeed * 0.9f;
            }

            if (ChayMoving == false)
            {
                ChaySpeed = 0;
                animator.SetBool("Moving", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Crate crate = collision.GetComponent<Crate>();
        if (collision.gameObject.CompareTag("Crate"))
        {
            crate.Break();
        }
    }

    static public void Stop()
    {
        ChaySpeed = 0;
    }
}
