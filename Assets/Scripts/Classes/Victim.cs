using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Victim : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int hpMax;

    [SerializeField] protected int defense;
    [SerializeField] protected int resist;
    [SerializeField] private ElementType elementType = ElementType.Physical;
    [SerializeField] private float spd = 3.5f;
    [SerializeField] private const float randomAngleTime = 1f;
    [SerializeField] private const float STAY_TIME = 1.5f;
    [SerializeField] private const float WALK_TIME = 3f;
    [Header("Floating UI")]
    [SerializeField] protected GameObject floatingDamage;

    //components
    private NavMeshAgent agent;
    private Animator animator;
    private Transform mainCamera;
    private Transform player;

    //UI
    private GameObject canvas;
    private GameObject healthBar;
    private Slider slider;

    //variables
    private int[] angles = { 0, -45, 45, -45, 45 };
    private float hp;
    private int angleIdx;
    private bool isDie;

    //timers
    private float angleTimer;
    private float stayTimer;
    private float walkTimer;
    void Start()
    {
        //components
        agent = GetComponent<NavMeshAgent>();
        agent.speed = spd;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        mainCamera = Camera.main.transform;

        //UI
        canvas = transform.Find("Canvas").gameObject;
        healthBar = canvas.transform.Find("HealthBar").gameObject;
        slider = healthBar.GetComponent<Slider>();

        healthBar.SetActive(true);

        //timers
        angleTimer = 0;
        stayTimer = 0;
        walkTimer = 0;

        angleIdx = 0;
        hp = hpMax;
        isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie) return;
        canvas?.transform.LookAt(mainCamera);
        if (hp >= 0)
            slider.value = (float)hp / (float)hpMax;
        else
            slider.value = 0;
        CheckEnemy();
        //is walking randomly
        if (animator.GetBool("isWalking"))
        {
            Vector3 dir = (player.position - transform.position).normalized;

            dir = Quaternion.AngleAxis(angles[angleIdx], Vector3.up) * dir;
            MoveTo(transform.position - (dir * 8));
            //walk random in WALK_TIME
            if (walkTimer < WALK_TIME)
            {
                walkTimer += Time.deltaTime;
                //while walking random the dir
                if (angleTimer < randomAngleTime) angleTimer += Time.deltaTime;
                else
                {
                    Debug.Log("change");
                    ChangeDir();
                    angleTimer = 0;
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
                walkTimer = 0;
            }
        }
        else
        {//stay
            agent.isStopped = true;
            if (stayTimer < STAY_TIME) stayTimer += Time.deltaTime;
            else
            {
                animator.SetBool("isWalking", true);
                stayTimer = 0;
            }
        }
    }
    public void TakeDamaged(float damageAmount, ElementType element)
    {
        float dam = CalDamage(damageAmount, element);
        hp -= dam;
        if (floatingDamage) ShowFloatingDamage(dam);
        // Debug.Log(damageAmount);
        if (hp <= 0)
        {
            hp = 0;
            healthBar.SetActive(false);
            Died();
        }
    }
    private void ShowFloatingDamage(float damage)
    {
        var text = Instantiate(floatingDamage, transform.position, Quaternion.identity, transform);
        if (damage == 0) text.GetComponent<TextMeshPro>().text = "miss";
        else text.GetComponent<TextMeshPro>().text = damage.ToString("0.00");
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
    private void CheckEnemy()
    {
        int n = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (n == 0)
        {
            if (QuestLog.GetActiveQuestById(49) != null)
                QuestLog.CompleteQuest(Database.questList[49]);
            isDie = true;
            animator.SetBool("isWalking", false);
            healthBar.SetActive(false);
        }
        // else
        // {
        //     // Debug.Log("Enemy left: " + n);
        // }
    }
    private void Died()
    {
        GetComponent<BoxCollider>().enabled = false;
        healthBar.SetActive(false);
        animator.SetTrigger("die");
        isDie = true;
        AnnouceTheDeath();
        ActionHandler.instance.AskToRetry(49);
    }
    private void AnnouceTheDeath()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            enemy.GetComponent<Enemy>().AwarePlayerDied(true);
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
