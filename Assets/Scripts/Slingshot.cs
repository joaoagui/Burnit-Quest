using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Shot;

    private AudioSource audioSource;
    public AudioClip shoot;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        Instantiate(Shot, firePoint.position, Quaternion.identity);
        audioSource.PlayOneShot(shoot, 1f);
    }
}
