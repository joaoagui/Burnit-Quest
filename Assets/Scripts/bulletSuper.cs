using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSuper : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    public GameObject dmgText;
    public GameObject sparks;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
            Instantiate(dmgText, transform.position, Quaternion.identity);
        }

        Crate crate = collision.GetComponent<Crate>();
        if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
            crate.Break();
            Instantiate(sparks, transform.position, Quaternion.identity);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }

    }
}
