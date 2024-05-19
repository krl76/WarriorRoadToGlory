using UnityEngine;
using UnityEngine.AI;
public class EnemyAttack : StateMachineBehaviour
{
    Transform player;
    int lastChoice;
    int attackChoice;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Point").transform;
        lastChoice = attackChoice;
        attackChoice = Random.Range(1, 4);
        while (attackChoice != lastChoice)
        {
            attackChoice = Random.Range(1, 4);
            animator.SetInteger("AttackChoice", attackChoice);
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position,
       player.position);
        if (distance > EnemyChase.attackRange)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isChasing", true);
            EnemyChase.agent.SetDestination(player.position);
        }
    }
}
