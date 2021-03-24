using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    private bool get = false;
    public GameObject getParticle;
    public AudioClip clip;


    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player" && get == false)
        {
            get = true;
            TokenFrenzyManager.p1Score += 1;
            Destroy(gameObject);
            Instantiate(getParticle, gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("token");

        }

        else if (collision.tag == "Chay" && get == false)
        {
            get = true;
            TokenFrenzyManager.p2Score += 1;
            Destroy(gameObject);
            Instantiate(getParticle, gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("token");

        }
    }
}
