using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Regata : MonoBehaviour
{
    private GameObject Finish;
    private EndStage EndStage;

    public GameObject hamShot;
    public GameObject specialShot;
    public AudioClip AttackClip;
    public AudioClip SpecialClip;

    public Transform firepoint;

    private float randomizer;

    private IEnumerator coroutine;

    public AudioSource audioSource;

    private float timer = 2f;

    public GameObject regataWin;
    public GameObject regataLose;

    private void Start()
    {
        Finish = GameObject.FindWithTag("Finish");
        EndStage = Finish.GetComponent<EndStage>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(Health.health <= 0)
        {
            regataLose.SetActive(true);
            gameObject.SetActive(false);
        }

        if (EndStage.Won == true)
        {
            regataWin.SetActive(true);
            gameObject.SetActive(false);
        }
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
