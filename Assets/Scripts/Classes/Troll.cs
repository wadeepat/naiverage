using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Troll : Enemy
{
    [Header("Troll details")]
    [SerializeField] private GameObject weaponColliderObject;
    [SerializeField] private float[] comboCd = new float[] { 1f, 2f, 2.5f, 2.5f };
    private int comboNo;
    private ColliderObject weaponColliderScript;
    private float changeTime = 3f;
    private float changeTimer;
    protected override void Start()
    {
        base.Start();
        changeTimer = 0;
        weaponColliderScript = weaponColliderObject.GetComponent<ColliderObject>();
    }
    protected override void Update()
    {
        base.Update();
        if (changeTimer < changeTime) changeTimer += Time.deltaTime;
        else
        {
            elementType = (ElementType)Random.Range(0, 4);
            ShowElement(elementType);
            changeTimer = 0;
        }
    }
    public override void OnIdleStateEnter()
    {
        animator.SetBool("com1", false);
        animator.SetBool("com2", false);
        animator.SetBool("com3", false);
        animator.SetBool("com4", false);
        StayThisPosition();
        SetToWalk();
        animator.SetBool("isChasing", false);
    }
    public override void OnIdleStateUpdate()
    {
        if (target) animator.SetBool("isChasing", true);
    }
    public override void OnChaseStateEnter()
    {
        comboNo = Random.Range(0, 4);
    }
    public override void OnChaseStateUpdate()
    {
        if (target == null)
        {
            animator.SetBool("isChasing", false);
            return;
        }
        if (agent.enabled)
        {
            if (agent.speed < chaseSpeed)
            {
                if (agent.speed + 0.2f * Time.deltaTime > chaseSpeed)
                    agent.speed = chaseSpeed;
                else agent.speed += 0.2f * Time.deltaTime;
            }
            animator.SetFloat("accelerate", (agent.speed - moveSpeed) / (chaseSpeed - moveSpeed));

            agent.SetDestination(target.position);
            float distance = Vector2.Distance(target.position, gameObject.transform.position);
            if (distance < agent.stoppingDistance)
            {
                TrollCombo(comboNo);
            }
        }
    }
    private void TrollCombo(int n)
    {
        switch (n)
        {
            case 0:
                StartTrollCombo("com1", comboCd[n]);
                break;
            case 1:
                StartTrollCombo("com2", comboCd[n]);
                break;
            case 2:
                StartTrollCombo("com3", comboCd[n]);
                break;
            case 3:
                StartTrollCombo("com4", comboCd[n]);
                break;
        }
    }
    public override bool EnemyAttack(string atkName)
    {
        if (target) transform.LookAt(target);
        return TrollAttack(atkName);
    }
    private bool TrollAttack(string atkName)
    {
        if (atkName == "LowAttack") return LowAttack();
        else if (atkName == "HeavyAttack") return HeavyAttack();
        switch (atkName)
        {
            case "LowAttack":
                return LowAttack();
            case "HeavyAttack":
                return HeavyAttack();
            default:
                Debug.LogWarning($"Troll doesnt' have atkName {atkName}");
                return false;
        }
    }
    private bool LowAttack(int damage = 10)
    {
        if (target) return false;

        if (weaponColliderScript.isCollided)
        {
            // Debug.LogWarning("Low Attack hit");
            if (target.gameObject.tag == "Player")
                target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damage);
            else target.gameObject.GetComponent<Victim>().TakeDamaged(damage, elementType);
            return true;
        }
        return false;
    }
    private bool HeavyAttack(int damage = 20)
    {
        if (target) return false;
        // transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 25, transform.rotation.z);
        if (weaponColliderScript.isCollided)
        {
            // Debug.LogWarning("Heavt Attack hit");
            if (target.gameObject.tag == "Player")
                target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damage);
            else target.gameObject.GetComponent<Victim>().TakeDamaged(damage, elementType);
            return true;
        }
        return false;
    }
    public void StartTrollCombo(string boolName, float cd)
    {
        animator.SetBool(boolName, true);
        cooldownTimer = cd;
        animator.SetBool("isCooldown", true);
    }
}
