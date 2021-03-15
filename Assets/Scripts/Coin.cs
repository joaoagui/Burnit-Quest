using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject bubblePop;
    bool get = false;
    public bool pulling = false;
    private Rigidbody2D rb;
    GameObject Target;
    

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(pulling == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, .3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (get== false && collision.gameObject.CompareTag("Player"))
        {
            get = true; 
            Destroy(gameObject);
            Instantiate(bubblePop, transform.position, Quaternion.identity);
            CoinsScript.stageCoins += 1;
            FindObjectOfType<AudioManager>().Play("pop");
        }

        if(collision.gameObject.CompareTag("Magnet"))
        {
            pulling = true;
        }

    }


}
