using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : StateMachineBehaviour
{
    Transform player;
    int attackChoice;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int cash = Animator.StringToHash("AttackChoice");
        attackChoice = animator.GetInteger(cash);
        switch (attackChoice)
        {
            case 1:
                attackChoice = Random.Range(2, 6);
                break;
            case 2:
                attackChoice = Random.Range(3, 6);
                break;
            case 3:
                attackChoice = Random.Range(4, 6);
                break;
            case 4:
                attackChoice = Random.Range(1, 4);
                break;
            case 5:
                attackChoice = Random.Range(1, 5);
                break;
            case 6:
                attackChoice = Random.Range(1, 6);
                break;
        }
        animator.SetInteger("AttackChoice", attackChoice);
    }
}
