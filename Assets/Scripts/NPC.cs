using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject SpeechBubble;
    public Animator animator;
    public AudioClip[] greeting;
    bool get = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (get == false && collision.gameObject.CompareTag("Player"))
        {
            get = true;
            animator.SetBool("Active", true);
            SpeechBubble.SetActive(true);
            GetComponent<AudioSource>().clip = greeting[0];
            GetComponent<AudioSource>().PlayOneShot(greeting[0]);

        }

    }
}
