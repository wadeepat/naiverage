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
    protected const float CLOSE_ATTACK_RANGE = 2f;
    protected const float RAGE_MODE_TIME = 5f;
    protected const float CD_DAMAGE_ANIM = 3f;

    [Header("Enemy Details")]
    // [SerializeField] protected int id;
    // [SerializeField] protected string enemyName;
    [SerializeField] protected MonsterId monsterId;
    [SerializeField] protected float moveSpeed = 1.5f;
    [SerializeField] protected float attackRange = 2f;
    [SerializeField] protected string attackType = "close";
    [SerializeField] protected string monsterType = "normal"; //normal will patrol, boss/mini boss won't
    [SerializeField] protected int monsterElement = 0; // 0 = normal, 1 = fire, 2 = water, 3 = wind 
    [SerializeField] protected int defense;
    [SerializeField] protected int resist;
    [SerializeField] protected ElementType elementType;
    [SerializeField] protected Image imageElement;

    [Header("If Range Attack")]
    [SerializeField] protected GameObject projectileObj;
    [SerializeField] protected Transform firePoint;

    [Header("Enemy Stats")]
    [SerializeField] protected float maxHealthPoint;

    [Header("Enemy States")]
    [SerializeField] protected float attackCooldown = 2f;
    [SerializeField] protected float stayCooldown = 4f;
    [SerializeField] protected float chaseSpeed = 2.5f;
    [SerializeField] protected float chaseRange = 15f;
    [Header("Nav settings")]
    [SerializeField] protected float stoppingDistance = 3f;
    [Header("Sounds")]
    [SerializeField] protected AudioSource normalSound;
    [SerializeField] protected AudioSource attackSound;
    //objects
    protected Transform target;
    protected NavMeshAgent agent;
    protected Animator animator;
    protected Transform mainCamera;
    protected GameObject waypointObject;
    protected List<Transform> waypoints = new List<Transform>();
    //Timer
    protected float attackTimer;
    protected float damagedTimer = RAGE_MODE_TIME;
    protected float cooldownTimer;
    protected float idleTimer;
    protected float stayTimer;
    protected float damageAnimTimer;

    //GUI
    protected GameObject canvas;
    protected GameObject healthBar;
    protected Slider slider;
    // public Sprite spriteElement;
    // public Image imageElement;
    //values
    protected float hp;
    protected float cooldownTime;
    protected float poisonTime, illusionTime, agonyTime, burnTime;
    protected bool isDie = false;
    protected bool poison, illusion, agony, burn;

    //every 1 seconds
    private Sprite spriteElement;
    private float time = 0.0f;
    private float interpolationPeriod = 1.0f;

    protected virtual void Start()
    {
        ShowElement(elementType);
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
        if (normalSound) normalSound.pitch = Random.Range(0.4f, 1.0f);
    }
    protected virtual void Update()
    {
        if (attackTimer < attackCooldown) attackTimer += Time.deltaTime;
        if (damagedTimer < RAGE_MODE_TIME) damagedTimer += Time.deltaTime;
        if (damageAnimTimer < CD_DAMAGE_ANIM) damageAnimTimer += Time.deltaTime;
        else RegenHP(1 * Time.deltaTime);
        if (isDie && monsterType == "normal") transform.position += new Vector3(0, -0.15f * Time.deltaTime, 0);

        // if (healthBar.activeSelf) canvas.transform.LookAt(mainCamera);
        canvas?.transform.LookAt(mainCamera);
        if (hp >= 0)
            slider.value = (float)hp / (float)maxHealthPoint;
        else
            slider.value = 0;

        CheckTimeAndStatus();


    }
    public virtual void OnChaseStateEnter()
    {
        agent.speed = chaseSpeed;
    }
    public virtual void OnChaseStateUpdate()
    {
        if (agent.enabled)
        {
            float distance = 1000;
            if (target != null)
            {
                agent.SetDestination(target.position);
                distance = Vector3.Distance(target.position, gameObject.transform.position);
            }
            if (distance > chaseRange && damagedTimer >= RAGE_MODE_TIME)
            {
                //back to patroll
                animator.SetBool("isChasing", false);
            }
            else if (distance <= attackRange)
            {
                // Debug.Log("Can attack: " + distance + " " + attackRange);
                //attack target
                animator.SetBool("isAttacking", true); // do attack anim
                animator.SetBool("isChasing", false);
            }
        }
    }
    public void NormalAttack()
    {
        if (target != null)
        {
            attackSound?.Play();
            transform.LookAt(target);
            float distance = Vector2.Distance(target.position, transform.position);

            if (distance < attackRange)
            {
                //TODO attack target
                AttackTargetInRange(attackRange, 20);
                // attackTimer = 0;
            }

        }
        cooldownTimer = 0;
        cooldownTime = attackCooldown;
        animator.SetBool("isAttacking", false);
        animator.SetBool("isCooldown", true);

    }
    public virtual bool EnemyAttack(string atkName)
    {
        return false;
    }
    public virtual void ShootProjectileObject()
    {
        GameObject pObject = Instantiate(projectileObj, firePoint.position, transform.rotation);
        cooldownTimer = 0;
        cooldownTime = attackCooldown;
        animator.SetBool("isAttacking", false);
        animator.SetBool("isCooldown", true);
    }
    public virtual void OnCooldownStateEnter()
    {
        //for other enemy
    }
    public virtual void OnCooldownStateUpdate()
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
        float distance = 1000;
        if (target != null)
        {
            distance = Vector3.Distance(target.position, gameObject.transform.position);
        }
        if (distance < chaseRange || damagedTimer < RAGE_MODE_TIME)
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
        StayThisPosition();
        SetToWalk();
        stayTimer = 0;
    }
    public virtual void OnIdleStateUpdate()
    {
        float distance = 1000;
        if (target != null)
        {
            distance = Vector3.Distance(target.position, gameObject.transform.position);
        }

        if (distance <= chaseRange || damagedTimer < RAGE_MODE_TIME)
        {
            if (target != null)
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
    protected void AttackTargetInRange(float range, int damage)
    {
        if (target == null) return;
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance <= range)
        {
            //attack target
            target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damage);
        }
    }
    protected void ShootProjectileObject(GameObject projectileObj, Transform firepoint)
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
    public void AwarePlayerDied()
    {
        target = null;
    }
    public void Died()
    {
        agent.enabled = false;
        if (monsterType == "normal") Destroy(gameObject, 7f);
        isDie = true;
    }
    public void TakeDamaged(float damageAmount, ElementType element)
    {
        StayThisPosition();
        hp -= CalDamage(damageAmount, element);
        Debug.Log(damageAmount);
        if (hp <= 0)
        {
            hp = 0;
            healthBar.SetActive(false);
            animator.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
            QuestLog.DoQuest(Quest.Objective.Type.kill, (int)monsterId, false);
            Died();
        }
        else
        {
            healthBar.SetActive(true);
            if (monsterType == "normal")
            {
                if (damageAnimTimer >= CD_DAMAGE_ANIM &&
                !animator.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
                {
                    cooldownTime = 0.5f;
                    animator.SetTrigger("damaged");
                    animator.SetBool("isCooldown", true);
                    damageAnimTimer = 0;
                }
            }
            else
            {//Boss
                if (damageAmount >= 0.3 * maxHealthPoint &&
                !animator.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
                {
                    cooldownTime = 0.5f;
                    animator.SetTrigger("damaged");
                    animator.SetBool("isCooldown", true);
                }
            }
            Provoke();
        }
        damagedTimer = 0;
    }
    public void Provoke()
    {
        if (monsterType == "boss") return;
        // Debug.Log("Provoke Others");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Collider[] colliders = Physics.OverlapSphere(transform.position, 7f, LayerMask.NameToLayer("Enemy"));
        foreach (GameObject col in enemies)
        {
            if (Vector3.Distance(transform.position, col.transform.position) <= 7f)
            {
                // Debug.Log("Provoke: " + col.name);
                col.GetComponent<Enemy>()?.Provoked();
            }
        }

    }
    public void Provoked()
    {
        if (damagedTimer >= RAGE_MODE_TIME)
        {
            canvas.transform.Find("ProvokeSign")?.gameObject.SetActive(true);
            damagedTimer = 0;
        }
    }
    public void RegenHP(float health)
    {
        //TODO regen hp
        hp += health;
        if (hp > maxHealthPoint) hp = maxHealthPoint;
    }
    public void CheckTimeAndStatus()
    {
        time += Time.deltaTime;
        poisonTime -= Time.deltaTime;
        illusionTime -= Time.deltaTime;
        agonyTime -= Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            StatusEffect();
        }
    }
    public void Poison()
    {
        poison = true;
        if (poisonTime < 0)
        {
            poisonTime = 15.0f;
            animator.speed = 0.5f;
        }
    }
    public void Illusion()
    {
        illusion = true;
        if (illusionTime < 0)
        {
            illusionTime = 3.0f;
            animator.speed = 0.2f;
            animator.SetTrigger("damaged");
        }

    }
    public void Agony()
    {
        agony = true;
        if (agonyTime < 0)
        {
            agonyTime = 5.0f;
        }

    }

    public void Burn()
    {
        burn = true;
        if (agonyTime < 0)
        {
            agonyTime = 5.0f;
        }
    }

    public void StatusEffect()
    {
        if (poison) agent.speed = chaseSpeed / 2;
        else if (illusion) agent.speed = 0.0f;
        else agent.speed = chaseSpeed;
        if (poison)
        {
            hp -= 2.0f;
            if (poisonTime < 0)
            {
                poison = false;
                animator.speed = 1.0f;
            }
        }
        else if (illusion)
        {

            if (illusionTime <= 0)
            {
                illusion = false;
                animator.speed = 1.0f;
            }
        }
        else if (agony)
        {
            hp -= 5.0f;
            if (agonyTime <= 0)
            {
                agony = false;
            }
        }

    }
    public virtual void SetToRun()
    {
        agent.speed = chaseSpeed;
    }
    public virtual void SetToWalk()
    {
        agent.speed = moveSpeed;

    }
    public float CalDamage(float damageAmount, ElementType element)
    {
        // 0 = normal, 1 = fire, 2 = water, 3 = wind 
        bool win = false;
        switch (element)
        {
            case ElementType.Physical:
                return damageAmount * (100.0f / (100 + defense));
            case ElementType.Fire:
                if (elementType == ElementType.Water) win = false;
                else if (elementType == ElementType.Wind) win = true;
                else return damageAmount * (100.0f / (100 + resist));
                break;
            case ElementType.Water:
                if (elementType == ElementType.Wind) win = false;
                else if (elementType == ElementType.Fire) win = true;
                else return damageAmount * (100.0f / (100 + resist));
                break;
            case ElementType.Wind:
                if (elementType == ElementType.Fire) win = false;
                else if (elementType == ElementType.Water) win = true;
                else return damageAmount * (100.0f / (100 + resist));
                break;
        }
        int num = Random.Range(1, 101);
        if (!win)
        {
            if (num <= 50)
            {
                return 0f;
            }
            else
            {
                return damageAmount * (100.0f / (100 + (resist * 2f)));
            }
        }
        else
        {
            if (num <= 70)
            {
                return damageAmount * 100.0f / (100 + (resist)) * 2f;
            }
        }
        return damageAmount * (100.0f / (100 + resist));
    }

    void ShowElement(ElementType e)
    {
        if (e == ElementType.Fire)
        {
            spriteElement = Resources.Load<Sprite>("f");
        }
        else if (e == ElementType.Water)
        {
            spriteElement = Resources.Load<Sprite>("wt");
        }
        else if (e == ElementType.Wind)
        {
            spriteElement = Resources.Load<Sprite>("w");
        }
        else
        {
            spriteElement = Resources.Load<Sprite>("phy");
        }
        imageElement = this.transform.Find("Canvas/HealthBar/Element/type").GetComponent<Image>();
        imageElement.sprite = spriteElement;
    }

}


