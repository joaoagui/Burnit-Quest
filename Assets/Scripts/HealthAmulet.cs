using UnityEngine;

public class HealthAmulet : MonoBehaviour
{

    public int amuletNumber;
    public bool Get = false;
    public GameObject HealthUI;
    private Animator animator;

    //static public int heartPieces = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = HealthUI.GetComponent<Animator>();

        if (amuletNumber == 1 && DataManager.Instance.playerData.amulet1 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 2 && DataManager.Instance.playerData.amulet2 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 3 && DataManager.Instance.playerData.amulet3 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 4 && DataManager.Instance.playerData.amulet4 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 5 && DataManager.Instance.playerData.amulet5 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 6 && DataManager.Instance.playerData.amulet6 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 7 && DataManager.Instance.playerData.amulet7 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 8 && DataManager.Instance.playerData.amulet8 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 9 && DataManager.Instance.playerData.amulet9 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 10 && DataManager.Instance.playerData.amulet10 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 11 && DataManager.Instance.playerData.amulet11 == 1)
        {
            Destroy(gameObject);
        }
        if (amuletNumber == 12 && DataManager.Instance.playerData.amulet12 == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (amuletNumber == 1)
            {
                DataManager.Instance.playerData.amulet1 = 1;
            }
            if (amuletNumber == 2)
            {
                DataManager.Instance.playerData.amulet2 = 1;
            }
            if (amuletNumber == 3)
            {
                DataManager.Instance.playerData.amulet3 = 1;
            }
            if (amuletNumber == 4)
            {
                DataManager.Instance.playerData.amulet4 = 1;
            }
            if (amuletNumber == 5)
            {
                DataManager.Instance.playerData.amulet5 = 1;
            }
            if (amuletNumber == 6)
            {
                DataManager.Instance.playerData.amulet6 = 1;
            }
            if (amuletNumber == 7)
            {
                DataManager.Instance.playerData.amulet7 = 1;
            }
            if (amuletNumber == 8)
            {
                DataManager.Instance.playerData.amulet8 = 1;
            }
            if (amuletNumber == 9)
            {
                DataManager.Instance.playerData.amulet9 = 1;
            }
            if (amuletNumber == 10)
            {
                DataManager.Instance.playerData.amulet10 = 1;
            }
            if (amuletNumber == 11)
            {
                DataManager.Instance.playerData.amulet11 = 1;
            }
            if (amuletNumber == 12)
            {
                DataManager.Instance.playerData.amulet12 = 1;
            }

        }

        if (collision.tag == "Player" &&  DataManager.Instance.playerData.heartPieces > 1 && Get == false)
        {
            Get = true;
            FindObjectOfType<AudioManager>().Play("amulet");
            HealthUI.SetActive(true);
            //animator.SetInteger("Pieces", 2);

            animator.Play("HeartPiece3");
                     
            Destroy(gameObject);
             DataManager.Instance.playerData.heartPieces = 0;
        }


        else if (collision.tag == "Player" &&  DataManager.Instance.playerData.heartPieces == 1 && Get == false)
        {
            Get = true;
            FindObjectOfType<AudioManager>().Play("amulet");
            HealthUI.SetActive(true);
            animator.Play("HeartPiece2");
            //animator.SetInteger("Pieces", 1);
             DataManager.Instance.playerData.heartPieces = 2;

            Destroy(gameObject);
        }


        else if (collision.tag == "Player" &&  DataManager.Instance.playerData.heartPieces < 1 && Get == false)
        {
            Get = true;
            FindObjectOfType<AudioManager>().Play("amulet");
             DataManager.Instance.playerData.heartPieces = 1;
            animator.Play("HeartPiece1");
            //animator.SetInteger("Pieces", 0);
            HealthUI.SetActive(true); 
            Destroy(gameObject);
        }


}
}
