using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpit : MonoBehaviour
{
    public GameObject destroyParticles;
    public float rotationSpeed = 1;


    // Update is called once per frame
    void Update()
    {
        if(rotationSpeed > 0 && transform.rotation.z < 50)
        {
            transform.Rotate(0, 0, 1 * rotationSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Instantiate(destroyParticles, transform.position, Quaternion.identity);
        }
    }
}
