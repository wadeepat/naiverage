using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float stopRadius = 2f;
    Transform target;
    NavMeshAgent agent;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && distance >= stopRadius)
        {
            _anim.SetBool("isWalking", true);

            agent.SetDestination(target.position);

            if (distance <= lookRadius && distance >= stopRadius)
            {
                //Attack
                //Face
                FaceTarget();
            }


        }
        else
        {
            _anim.SetBool("isWalking", false);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
