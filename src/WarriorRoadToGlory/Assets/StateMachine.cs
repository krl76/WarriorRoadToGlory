using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : StateMachineBehaviour
{
    int lastChoice;
    int attackChoice;
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        attackChoice = Random.Range(1, 4);
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lastChoice = attackChoice;
        attackChoice = Random.Range(1, 4);
        while (attackChoice != lastChoice)
        {
            attackChoice = Random.Range(1, 4);
            animator.SetInteger("AttackChoice", attackChoice);
        }
    }
}