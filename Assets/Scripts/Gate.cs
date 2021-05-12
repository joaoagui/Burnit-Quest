using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class Gate : MonoBehaviour
{
    bool closed = false;
    public Animator animator;
    public Rigidbody2D rbChay;
    public GameObject playerObject;
    public GameObject playerLose;
    public GameObject loseScreen;
    public GameObject button;
    bool get = false;

    public CinemachineVirtualCamera playerCam;

    private void Start()
    {
        get = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
        {
            if (get == false && collision.gameObject.CompareTag("Player"))
            {
                get = true;
                animator.SetBool("Closed", true);
                Chay.ChayMoving = false;
                FindObjectOfType<AudioManager>().Play("gateClose");
            }

            else if (get == false && collision.gameObject.CompareTag("Chay"))
            {
                get = true;
                playerCam.Follow = rbChay.transform;

                Chay.Stop();
                animator.SetBool("Closed", true);
                FindObjectOfType<AudioManager>().Play("gateClose");
                Instantiate(playerLose, playerObject.transform.position, Quaternion.identity);

                Destroy(playerObject);

                loseScreen.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(button);
            }
    }

}
