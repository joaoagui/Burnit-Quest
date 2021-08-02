using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBullet2 : MonoBehaviour
{

    public float speed = 20f;
    private Rigidbody2D rb;
    public GameObject dmgText;
    public GameObject sparks;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (8,2);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Bullet.dmgTotal = Random.Range( DataManager.Instance.playerData.damageSkill - 2,  DataManager.Instance.playerData.damageSkill + 1);
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
            Instantiate(sparks, transform.position, new Quaternion(0,0,33,0));
        }

    }
}
