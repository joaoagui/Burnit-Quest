using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool hasCoin;
    public int numberOfCoins;

    public bool Open = false;
    public GameObject coin;
    private IEnumerator coroutine;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Player.hasKey == true && Open == false)
        {
            GameObject newKey = GameObject.FindGameObjectWithTag("Key");
            Destroy(newKey);

            Open = true;
            animator.SetBool("Open", true);
            Player.hasKey = false;
            FindObjectOfType<AudioManager>().Play("chest");

            if (hasCoin == true)
            {
                coroutine = TreasureCoin();
            }            
            StartCoroutine(coroutine);
        }
    }

    public IEnumerator TreasureCoin()
    {
        while (numberOfCoins > 0)
        {
            numberOfCoins -= 1;
            GameObject newCoin = Instantiate(coin, new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f)), Quaternion.identity);
            newCoin.GetComponent<Coin>().pulling = true;

            yield return new WaitForSeconds(0.1f);
        }
    }

}
