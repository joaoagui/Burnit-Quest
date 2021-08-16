using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinShot : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject sparks;
    public static int dmgTotal;


    public bool spinning;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -speed);
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        transform.Rotate(0, 0, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }
    }
}
