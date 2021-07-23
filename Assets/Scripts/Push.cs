using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public float pushY;
    public float pushX;
    public string pushTag;

    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == pushTag)
        {
            rb = collision.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(pushX, pushY), ForceMode2D.Impulse);
        }
    }
}
