using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{

    public int altarNumber;
    public GameObject dmgUP;
    private Animator animator;
    private GameObject Player;

    [Header("SFX")]
    public AudioClip Lit;
    private AudioSource audioSource;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (altarNumber == 1 &&  DataManager.Instance.playerData.altar1 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 2 &&  DataManager.Instance.playerData.altar2 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 3 &&  DataManager.Instance.playerData.altar3 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 4 &&  DataManager.Instance.playerData.altar4 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 5 &&  DataManager.Instance.playerData.altar5 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 6 &&  DataManager.Instance.playerData.altar6 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 7 &&  DataManager.Instance.playerData.altar7 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 8 &&  DataManager.Instance.playerData.altar8 == 1)
        {
            animator.SetBool("Lit", true);
        }
        if (altarNumber == 9 &&  DataManager.Instance.playerData.altar9 == 1)
        {
            animator.SetBool("Lit", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar1 == 0 && altarNumber == 1)
        {
             DataManager.Instance.playerData.altar1 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar2 == 0 && altarNumber == 2)
        {
             DataManager.Instance.playerData.altar2 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar3 == 0 && altarNumber == 3)
        {
             DataManager.Instance.playerData.altar3 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar4 == 0 && altarNumber == 4)
        {
             DataManager.Instance.playerData.altar4 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar5 == 0 && altarNumber == 5)
        {
             DataManager.Instance.playerData.altar5 = 1;
            ActivateAltar();

        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar6 == 0 && altarNumber == 6)
        {
             DataManager.Instance.playerData.altar6 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar7 == 0 && altarNumber == 7)
        {
             DataManager.Instance.playerData.altar7 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar8 == 0 && altarNumber == 8)
        {
             DataManager.Instance.playerData.altar8 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar9 == 0 && altarNumber == 9)
        {
             DataManager.Instance.playerData.altar9 = 1;
            ActivateAltar();
        }
        if (collision.CompareTag("Bullet") &&  DataManager.Instance.playerData.altar10 == 0 && altarNumber == 10)
        {
             DataManager.Instance.playerData.altar10 = 1;
            ActivateAltar();
        }
    }

    public void ActivateAltar()
    {
        audioSource.PlayOneShot(Lit, 1f);
        animator.SetBool("Lit", true);
        DataManager.Instance.playerData.damageSkill += 1;
        GameObject effectDmgUP = Instantiate(dmgUP, Player.transform.position, Quaternion.identity);
    }
}
