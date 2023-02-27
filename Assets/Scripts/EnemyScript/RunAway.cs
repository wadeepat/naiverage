using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private float runSpd = 3.5f;
    [SerializeField] private float sprintSpd = 10f;
    private const float ANGLE_TIME = 0.7f;
    private NavMeshAgent agent;
    private Animator animator;
    private Transform target;

    private float angleTimer = 0;
    private const float SPRINT_TIME = 0.5f;
    private const float SPRINT_COOLDOWN = 1.5f;
    private float sprintTimer = 0;
    private float cooldownTimer = 0;

    // private GameObject waypointObject;
    // private List<Transform> waypoints = new List<Transform>();

    private int[] angles = { 0, -45, 45, -45, 45 };
    private int angleIdx;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = runSpd;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // waypointObject = transform.parent.Find("Waypoints").gameObject;

        // foreach (Transform wp in waypointObject.transform)
        // {
        //     waypoints.Add(wp);
        // }
        sprintTimer = 0;
        angleIdx = 0;
    }
    private void Update()
    {
        if (target == null) return;

        if (angleTimer < ANGLE_TIME) angleTimer += Time.deltaTime;
        else
        {
            ChangeDir();
            angleTimer = 0;
        }

        float dis = Vector3.Distance(transform.position, target.position);
        if (dis > distance)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Eat", true);
            agent.isStopped = true;
        }
        else
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Run", true);
            Vector3 dir = (target.position - transform.position).normalized;

            dir = Quaternion.AngleAxis(angles[angleIdx], Vector3.up) * dir;
            MoveTo(transform.position - (dir * distance));


            if (cooldownTimer < SPRINT_COOLDOWN)
            {
                SetSpeed(runSpd);
                cooldownTimer += Time.deltaTime;
            }
            else
            {
                if (sprintTimer < SPRINT_TIME)
                {
                    SetSpeed(sprintSpd);
                    sprintTimer += Time.deltaTime;
                }
                else
                {
                    sprintTimer = 0;
                    cooldownTimer = 0;
                }
            }
        }

    }
    private void ChangeDir()
    {
        angleIdx = Random.Range(0, 5);
    }
    private void MoveTo(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }
    private void SetSpeed(float spd)
    {
        agent.speed = spd;
    }

}
