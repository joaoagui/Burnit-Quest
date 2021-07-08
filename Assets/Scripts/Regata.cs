using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Regata : MonoBehaviour
{
    public GameObject hamShot;
    public GameObject specialShot;
    public AudioClip AttackClip;
    public AudioClip SpecialClip;

    public Transform firepoint;

    private float randomizer;

    private IEnumerator coroutine;

    public AudioSource audioSource;

    private float timer = 2f;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void FireShot()
    {
        if(timer < 0)
        {
            timer = 2f;
            Instantiate(hamShot, firepoint.position, Quaternion.identity);
            audioSource.PlayOneShot(AttackClip, 1f);
        }

    }

    public void ShootSpecial()
    {
        if (timer < 0)
        {
             timer = 2f;
             GameObject specialInstance  = Instantiate(specialShot, firepoint.position, Quaternion.identity);
             Rigidbody2D specialRB = specialInstance.GetComponent<Rigidbody2D>();
             specialRB.AddForce(new Vector2(12, 2), ForceMode2D.Impulse);
             audioSource.PlayOneShot(SpecialClip, 1f);
        }
    }
}
