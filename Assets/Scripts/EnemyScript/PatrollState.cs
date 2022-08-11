using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollState : StateMachineBehaviour
{
    // public float test;
    [SerializeField] private string WayPointsName;
    float timer;
    float chaseRange = 10;
    Transform player;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0;
        // GameObject wp = GameObject.FindGameObjectWithTag("WayPoints00");
        // Debug.Log("WayPoints_" + animator.gameObject.name);
        // GameObject wp = GameObject.Find("WayPoints_" + animator.gameObject.name);
        GameObject wp = GameObject.Find(WayPointsName);
        // Debug.Log(wp);
        foreach (Transform t in wp.transform)
            wayPoints.Add(t);
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.GetComponent<NavMeshAgent>().enabled)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }


        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isPatrolling", false);
            animator.SetBool("isChasing", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.GetComponent<NavMeshAgent>().enabled)
            agent.SetDestination(agent.transform.position);
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
