using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    private Rigidbody2D rb;
    public GameObject dmgText;
    public GameObject sparks;
    public static int dmgTotal;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
        timer -= Time.deltaTime * 1;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.CompareTag("Enemy") && timer <= 0)
        {
            timer = 1;
            dmgTotal = Random.Range( DataManager.Instance.playerData.damageSkill - 2,  DataManager.Instance.playerData.damageSkill + 1);
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

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }

    }

}
