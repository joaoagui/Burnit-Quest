using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private Animator P1Animator;
    private Animator P2Animator;

    public AnimatorOverrideController ChayAnimator;



    private void Start()
    {
        P1Animator = Player1.GetComponent<Animator>();
        P2Animator = Player2.GetComponent<Animator>();



        if (VersusSettings.P1Character == "Chay")
        {
            P1Animator.runtimeAnimatorController = ChayAnimator;
        }

        if (VersusSettings.P2Character == "Chay")
        {
            P2Animator.runtimeAnimatorController = ChayAnimator;
        }

        
    }

    void Update()
    {
    }
}
