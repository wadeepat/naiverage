using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    // private AnimatorStateInfo aimAnim;
    // private float NTime;
    protected override void Start()
    {
        base.Start();
        // if (agent.enabled)
        // agent.isStopped = true;
    }
    public override void OnIdleStateEnter()
    {
        // base.OnIdleStateEnter();
    }
    public override void OnIdleStateUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackRange)
        {
            animator.SetBool("isChasing", true);
        }
    }
    public override void OnChaseStateEnter()
    {
        // GameObject arrow = Instantiate(projectileObj, firePoint.position, transform.rotation);
        // arrow.transform.SetParent(firePoint);
        // aimAnim = animator.GetCurrentAnimatorStateInfo(0);
        // NTime = aimAnim.normalizedTime;
    }
    public override void OnChaseStateUpdate()
    {
        transform.LookAt(target);
        float distance = Vector3.Distance(target.position, transform.position);

        // Debug.Log("aim: " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        // if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        // {
        if (distance <= attackRange)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isChasing", false);
        }
        else
        {
            // GameObject arrow = firePoint.Find("Arrow(Clone)").gameObject;
            // Destroy(arrow);
            animator.SetBool("isChasing", false);
        }
        // }
    }
    public override void ShootProjectileObject()
    {
        // GameObject arrow = firePoint.Find("Arrow(Clone)").gameObject;
        transform.LookAt(target);
        GameObject arrow = Instantiate(projectileObj, firePoint.position, transform.rotation);
        // arrow.GetComponent<ProjectileObject>().enabled = true;
        // arrow.GetComponent<DamageToPlayer>().enabled = true;
        // arrow.transform.parent = null;
        cooldownTimer = 0;
        cooldownTime = attackCooldown;
        cooldownTime = 3f;
        animator.SetBool("isAttacking", false);
        animator.SetBool("isCooldown", true);
    }
}
