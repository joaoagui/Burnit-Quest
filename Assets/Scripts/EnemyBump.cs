using UnityEngine;

public class EnemyBump : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public AudioSource bump;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = Player.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            rb = hitInfo.gameObject.GetComponent<Rigidbody2D>();
            Health.invincibilityTimer = 0;
            rb.velocity = new Vector2(10, 12);
            bump.Play();
        }
    }

}
