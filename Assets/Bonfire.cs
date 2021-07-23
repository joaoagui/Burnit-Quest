using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Bonfire : MonoBehaviour
{
    public Light2D illumination;
    public GameObject fire;
    public float fadeSpeed = 1;
    public GameObject sparks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.transform.localScale.x > 0.1)
        {
            fire.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * fadeSpeed;
            illumination.intensity -= Time.deltaTime * fadeSpeed;
        }

        if (fire.transform.localScale.x < 0.1)
        {
            fire.SetActive(false);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            fire.SetActive(true);
            fire.transform.localScale = new Vector3(1, 1, 1);
            illumination.intensity = 1;
            Instantiate(sparks, transform.position, Quaternion.identity);
        }
    }

}
