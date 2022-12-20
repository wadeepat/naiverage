using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    const float CLOSE_ATTACK_RANGE = 2f;
    const float RAGE_MODE_TIME = 5f;

    [Header("Enemy Details")]
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private string attackType = "close";
    [SerializeField] private string monsterType = "normal"; //normal will patrol, boss/mini boss won't

    [Header("If Range Attack")]
    [SerializeField] private GameObject projectileObj;
    [SerializeField] private Transform firePoint;

    [Header("Enemy Stats")]
    [SerializeField] private float maxHealthPoint;
    // [Header("Enemy GUIs")]
    // [SerializeField] private GameObject Canvas;
    // [SerializeField] private GameObject healthBar;
    [Header("Enemy States")]
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float stayCooldown = 4f;
    [SerializeField] private float chaseSpeed = 2.5f;
    [SerializeField] private float chaseRange = 15f;
    // [SerializeField] private GameObject waypointObject;
    [Header("Nav settings")]
    [SerializeField] private float stoppingDistance = 3f;

    //objects
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Transform mainCamera;
    private GameObject waypointObject;
    private List<Transform> waypoints = new List<Transform>();
    //Timer
    private float attackTimer;
    private float damagedTimer = RAGE_MODE_TIME;
    private float cooldownTimer;
    private float idleTimer;
    private float stayTimer;
    //GUI
    private GameObject canvas;
    private GameObject healthBar;
    private Slider slider;
    //values
    private float hp;
    private float cooldownTime;
    private bool isDie = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
        animator = GetComponent<Animator>();
        attackTimer = attackCooldown;
        hp = maxHealthPoint;
        mainCamera = Camera.main.transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        canvas = transform.Find("Canvas").gameObject;
        healthBar = canvas.transform.Find("HealthBar").gameObject;
        slider = healthBar.GetComponent<Slider>();
        waypointObject = transform.parent.Find("Waypoints").gameObject;

        foreach (Transform wp in waypointObject.transform)
        {
            waypoints.Add(wp);
        }
        healthBar.SetActive(false);
        slider.value = 1;
    }
    private void Update()
    {
        if (attackTimer < attackCooldown) attackTimer += Time.deltaTime;
        if (damagedTimer < RAGE_MODE_TIME) damagedTimer += Time.deltaTime;
        if (isDie) transform.position += new Vector3(0, -0.2f * Time.deltaTime, 0);

        if (healthBar.activeSelf) canvas.transform.LookAt(mainCamera);
        if (hp >= 0)
            slider.value = (float)hp / (float)maxHealthPoint;
        else
            slider.value = 0;

    }
    public virtual void OnChaseStateEnter()
    {
        agent.speed = chaseSpeed;
    }
    public virtual void OnChaseStateUpdate()
    {
        if (agent.enabled)
        {
            agent.SetDestination(target.position);
            float distance = Vector2.Distance(target.position, gameObject.transform.position);
            if (distance > chaseRange && damagedTimer >= RAGE_MODE_TIME)
            {
                //back to patroll
                animator.SetBool("isChasing", false);
            }
            else if (distance < attackRange - 1f)
            {
                //attack target
                animator.SetBool("isAttacking", true); // do attack anim
                animator.SetBool("isChasing", false);
            }
        }
    }
    public void NormalAttack()
    {
        // if(attackTimer >= attackCooldown)
        // {
        //     attackTimer = 0;
        //     animator.SetBool("isAttacking", false);
        // }
        transform.LookAt(target);
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance < attackRange)
        {
            //TODO attack target
            AttackTargetInRange(attackRange, 20);
            // attackTimer = 0;

        }
        cooldownTimer = 0;
        cooldownTime = attackCooldown;
        animator.SetBool("isAttacking", false);
        animator.SetBool("isCooldown", true);

    }
    public void ShootProjectileObject()
    {
        GameObject poision = Instantiate(projectileObj, firePoint.position, transform.rotation);
        cooldownTimer = 0;
        cooldownTime = attackCooldown;
        animator.SetBool("isAttacking", false);
        animator.SetBool("isCooldown", true);
    }
    public void OnCooldownStateUpdate()
    {
        if (cooldownTimer >= cooldownTime)
        {
            cooldownTimer = 0;
            animator.SetBool("isCooldown", false);
        }
        else
        {
            cooldownTimer += Time.deltaTime;
        }
    }
    public void OnPatrollStateEnter()
    {
        SetToWalk();
        Vector3 vec = waypoints[Random.Range(0, waypoints.Count)].position;
        agent.SetDestination(vec);
    }
    public void OnPatrollStateUpdate()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        // float distance = Vector3.Distance(target.position, transform.position);
        // Debug.Log("")
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isPatrolling", false);
        }
        else if (agent.enabled && agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("isPatrolling", false);
        }
    }
    public virtual void OnIdleStateEnter()
    {
        SetToWalk();
        stayTimer = 0;
    }
    public virtual void OnIdleStateUpdate()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance <= chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
        else if (stayTimer >= stayCooldown)
        {
            animator.SetBool("isPatrolling", true);
        }
        else
        {
            stayTimer += Time.deltaTime;
        }
    }
    private void AttackTargetInRange(float range, int damage)
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= range)
        {
            //attack target
            target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damage);
        }
    }
    private void ShootProjectileObject(GameObject projectileObj, Transform firepoint)
    {
        Instantiate(projectileObj, firepoint.position, transform.rotation);
    }
    public void StayThisPosition()
    {
        if (agent.enabled)
        {
            agent.SetDestination(transform.position);
        }
    }
    public void Died()
    {
        agent.enabled = false;
        Destroy(gameObject, 7f);
        isDie = true;
    }
    public void TakeDamaged(int damageAmount)
    {
        damagedTimer = 0;
        healthBar.SetActive(true);
        StayThisPosition();
        hp -= damageAmount;
        if (hp <= 0)
        {
            hp = 0;
            healthBar.SetActive(false);
            animator.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
            Died();
        }
        else
        {
            healthBar.SetActive(true);
            animator.SetTrigger("damaged");
        }
    }
    public void RegenHP()
    {
        //TODO regen hp
    }
    public virtual void SetToRun()
    {
        agent.speed = chaseSpeed;
    }
    public virtual void SetToWalk()
    {
        agent.speed = moveSpeed;
    }
}
