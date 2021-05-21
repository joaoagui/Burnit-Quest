using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GulletFront : MonoBehaviour
{
    public bool movingUP;
    public GameObject gulletDead;

    private bool dead = false;


    void Update()
    {
        if (gameObject.transform.position.y < -400 || gameObject.transform.position.y > 1600)
        {
            Destroy(gameObject);
        }

        if (movingUP == true)
        {
            transform.Translate(Vector2.up * 2 * Time.deltaTime);
        }

        if (movingUP == false)
        {
            transform.Translate(Vector2.up * -2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dead = true;
            SlingshotMultiplayer.p1Score += 1;
            SlingshotManager.gulletNumber -= 1;
            Instantiate(gulletDead, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.tag == "Chay")
        {
            dead = true;
            SlingshotMultiplayer.p2Score += 1;
            Instantiate(gulletDead, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
