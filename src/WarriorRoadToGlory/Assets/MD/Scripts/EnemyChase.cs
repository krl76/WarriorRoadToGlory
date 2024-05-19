using UnityEngine;
using UnityEngine.AI;
public class EnemyChase : StateMachineBehaviour
{
    public static NavMeshAgent agent;
    Transform player;
    public static float attackRange = 1f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4;
        player = GameObject.FindGameObjectWithTag("Point").transform;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);
        agent.SetDestination(player.position);
        if (distance < attackRange)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isChasing", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 4;
    }
}