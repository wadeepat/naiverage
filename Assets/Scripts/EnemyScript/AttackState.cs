using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackState : StateMachineBehaviour
{
    [SerializeField] private string attackType = "close";
    [SerializeField] private float attackRange = 10f;
    float cannotAttackRange = 3.5f;
    NavMeshAgent agent;
    Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (attackType == "range")
        {
            if (distance < attackRange)
            {
                animator.SetBool("isCooldowning", true);
            }
            animator.SetBool("isAttacking", false);
        }
        else
        {
            if (distance < cannotAttackRange)
            {
                animator.SetBool("isCooldowning", true);
            }
            animator.SetBool("isAttacking", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.GetComponent<NavMeshAgent>().enabled)
        {
            agent.SetDestination(animator.transform.position);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
