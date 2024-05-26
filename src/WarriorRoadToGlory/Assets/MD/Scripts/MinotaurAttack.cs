using UnityEngine;
using UnityEngine.AI;
public class MinotaurAttack : StateMachineBehaviour
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
                attackChoice = Random.Range(2, 4);
                break;
            case 2:
                attackChoice = 1;
                break;
            case 3:
                attackChoice = Random.Range(1, 3);
                break;
        }
        animator.SetInteger("AttackChoice", attackChoice);
    }
}