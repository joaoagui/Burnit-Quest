using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject sparks;
    public static int dmgTotal;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * -speed;
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }
    }
}
