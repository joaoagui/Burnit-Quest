using UnityEngine;

public class Bird : MonoBehaviour
{
    public Animator birdAnimator;
    public Rigidbody2D rb;
    public float speed;
    private bool Flying = false;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision.tag == "Player" && Flying == false)
        {
            Flying = true;
            birdAnimator.SetBool("Flying", true);
            FindObjectOfType<AudioManager>().Play("birdFly");
            rb.velocity = new Vector2(speed, speed);
            Destroy(gameObject, 3f);

        }
    }
}
