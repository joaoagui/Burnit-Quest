using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimatorFix : MonoBehaviour
{

    GameObject Player;
    Animator animator;
    PlayableDirector director;
    public GameObject skipButton;

    private IEnumerator coroutine;

    private bool reset = false;
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        animator = Player.GetComponent<Animator>();
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(director.time >= director.duration && reset == false)
        {
            reset = true;
            coroutine = ResetAnimator();
            StartCoroutine(coroutine);
            Destroy(skipButton.gameObject);
        }
    }

    public IEnumerator ResetAnimator()
    {
        {
            animator.enabled = false;
             yield return new WaitForSeconds(0.1f);
            animator.enabled = true;
        }
    }
}
