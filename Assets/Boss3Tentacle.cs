using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Tentacle : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject coin;
    private Material defaultMaterial;
    public Material dmgMaterial;
    private IEnumerator coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet") && BossHealth.health > 0)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            BossHealth.TakeDamage();
            GameObject crateInstance = Instantiate(coin, transform.position, Quaternion.identity);

        }



        else if (collision.gameObject.CompareTag("SuperBullet") && BossHealth.health > 0)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            BossHealth.TakeSuperDamage();
            GameObject crateInstance = Instantiate(coin, transform.position, Quaternion.identity);
        }

        IEnumerator Flash()
        {
            sprite.material = dmgMaterial;
            yield return new WaitForSeconds(0.1f);
            sprite.material = defaultMaterial;
        }
    }
}
