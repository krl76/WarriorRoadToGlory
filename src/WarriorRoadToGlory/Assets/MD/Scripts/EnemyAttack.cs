using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : StateMachineBehaviour
{
    Transform player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > EnemyChase.attackRange)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isChasing", true);
            EnemyChase.agent.SetDestination(player.position);
        }
    }
}  
