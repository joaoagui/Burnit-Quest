using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    public GameObject leafParticles;
    public Transform leafPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("SuperBullet"))
        {
            Destroy(gameObject);
            Instantiate(leafParticles, leafPoint.position, Quaternion.identity);
        }
    }
}
