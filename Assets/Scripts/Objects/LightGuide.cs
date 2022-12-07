using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightGuide : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;
    private Transform target;
    private Transform player;
    private NavMeshAgent agent;
    void Awake()
    {
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            // Debug.Log("move");
            if (Vector3.Distance(this.transform.position, target.position) <= agent.stoppingDistance)
            {
                if (Vector3.Distance(player.position, target.position) <= agent.stoppingDistance)
                {
                    agent.isStopped = true;
                    this.gameObject.SetActive(false);
                }
                else
                {
                    agent.isStopped = true;
                    SetTarget(target);
                }
            }
            else
            {
                transform.position += transform.forward * (speed * Time.deltaTime);
            }
        }
        // Vector3.Lerp(this.transform.position, Vector3.zero, speed);
        // transform.position += Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * speed);
        // transform.position += transform.forward * (speed * Time.deltaTime);
    }
    public void SetTarget(Transform newTarget)
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (!agent) agent = GetComponent<NavMeshAgent>();
        // Debug.Log("set");
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.target = newTarget;
        transform.position = player.position;
        // transform.position += Vector3.up;
        // transform.LookAt(newTarget);
        this.gameObject.SetActive(true);
        agent.isStopped = false;
        agent.SetDestination(newTarget.position);
        // this.enabled = true;
    }
}
