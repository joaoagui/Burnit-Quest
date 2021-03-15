using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        Crate crate = collision.GetComponent<Crate>();
        if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(collision.gameObject);
        }

    }
}
