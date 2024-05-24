using UnityEngine;
using UnityEngine.AI;
public class MinotaurAttack : StateMachineBehaviour
{
    int attackChoice;
    int lastChoice;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lastChoice = 0;
        //player = GameObject.FindGameObjectWithTag("Point").transform;
        attackChoice = Random.Range(1, 4);
        animator.SetInteger("AttackChoice", attackChoice);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackChoice = Random.Range(1, 4);
        while (attackChoice == lastChoice)
        {
            attackChoice = Random.Range(1, 4);
        }
        animator.SetInteger("AttackChoice", attackChoice);
        lastChoice = attackChoice;
        //animator.transform.LookAt(player);
        //float distance = Vector3.Distance(animator.transform.position, player.position);
        //if (distance > EnemyChase.attackRange)
        //{
        //    animator.SetBool("isAttacking", false);
        //    animator.SetBool("isChasing", true);
        //    EnemyChase.agent.SetDestination(player.position);
        //}
    }
}
