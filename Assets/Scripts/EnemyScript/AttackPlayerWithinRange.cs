using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerWithinRange : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private int damageAmount = 10;
    // [SerializeField] private Transform target;
    // Start is called before the first frame update
    private Transform target;
    private GameObject victim;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        victim = GameObject.FindGameObjectWithTag("Victim");
    }

    // Update is called once per frame
    public void AttackTarget()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackRange)
        {
            //attack target
            target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damageAmount);
            victim?.GetComponent<Victim>().TakeDamaged(damageAmount, ElementType.Physical);
        }
    }
}
