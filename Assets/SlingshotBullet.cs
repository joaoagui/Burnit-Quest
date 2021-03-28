using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotBullet : MonoBehaviour
{
    public int speed;
    public GameObject destroyEffect;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed, 8), ForceMode2D.Impulse);
    }


    private void Update()
    {
        if(transform.position.y > 1600 || transform.position.y < -400)
        {
            Destroy(gameObject);
        }
    }

}
