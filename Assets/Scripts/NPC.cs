using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public GameObject SpeechBubble;
    public string npcName;
    public string dialogNPC;

    public Text textName;
    public Text textDialog;

    public AudioSource audioSource;
    public Animator animator;

    public AudioClip greeting;
    bool get = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (get == false && collision.gameObject.CompareTag("Player"))
        {
            get = true;

            textName.text = "" + npcName;
            textDialog.text = "" + dialogNPC;

            animator.SetBool("Active", true);
            SpeechBubble.SetActive(true);

            audioSource.PlayOneShot(greeting, 0.8f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpeechBubble.SetActive(false);
    }
}
