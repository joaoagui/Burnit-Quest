using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GulletFront : MonoBehaviour
{
    public bool movingUP;

    void Update()
    {
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

        }

        if (collision.tag == "Chay")
        {

        }
    }
}
