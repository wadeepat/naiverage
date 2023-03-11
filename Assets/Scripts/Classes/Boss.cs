using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [Header("Final boss details")]
    [SerializeField] private float[] comboCd = new float[] { 0.75f, 1.5f, 0.25f, 2.5f };
    [SerializeField] private GameObject[] fireObject;
    [SerializeField] private GameObject ultiObject;
    [SerializeField] private GameObject buffEffect;
    const float DEF_BUFF_TIME = 10f;
    const float CRIDAMAGE_BUFF_TIME = 5f;
    private int comboNo;
    private int turn = -1;
    //*for Abel
    private bool defBuff = false;
    private float defBuffTimer = 0f;
    //*for Cain
    private bool criDamageBuff = false;
    private float criDamageBuffTimer = 0f;
    protected override void Update()
    {
        // Debug.Log("update from boss");
        base.Update();
        if (defBuff)
        {
            if (defBuffTimer >= DEF_BUFF_TIME)
            {
                defBuff = false;
            }
            else defBuffTimer += Time.deltaTime;
        }
        if (criDamageBuff)
        {
            if (criDamageBuffTimer >= CRIDAMAGE_BUFF_TIME)
            {
                criDamageBuff = false;
            }
            else criDamageBuffTimer += Time.deltaTime;
        }
    }
    public override void OnIdleStateEnter()
    {
        base.OnIdleStateEnter();
        animator.SetBool("isChasing", false);
    }
    public override void OnIdleStateUpdate()
    {
        if (target) animator.SetBool("isChasing", true);
    }
    public override void OnChaseStateEnter()
    {
        // ResetCombo();
        comboNo = Random.Range(0, 3);
        // Debug.Log("turn: " + turn);
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
                if (turn == 3 || turn == 6)
                    MonsterCombo(turn == 3 ? 2 : 3);
                else
                    MonsterCombo(comboNo == 2 ? 1 : 0);
            }
        }
    }
    protected override float CalDamage(float damageAmount, ElementType element)
    {
        // return base.CalDamage(damageAmount, element);
        bool win = false;
        switch (element)
        {
            case ElementType.Physical:
                return damageAmount * (100.0f / (100 + defense + DefIncrease()));
            case ElementType.Fire:
                if (elementType == ElementType.Water) win = false;
                else if (elementType == ElementType.Wind) win = true;
                else return damageAmount * (100.0f / (100 + resist + DefIncrease()));
                break;
            case ElementType.Water:
                if (elementType == ElementType.Wind) win = false;
                else if (elementType == ElementType.Fire) win = true;
                else return damageAmount * (100.0f / (100 + resist + DefIncrease()));
                break;
            case ElementType.Wind:
                if (elementType == ElementType.Fire) win = false;
                else if (elementType == ElementType.Water) win = true;
                else return damageAmount * (100.0f / (100 + resist + DefIncrease()));
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
    public override void OnCooldownStateEnter()
    {
        // base.OnCooldownStateEnter();
        ResetCombo();
        NextTurn();
    }
    private void MonsterCombo(int comboNo)
    {
        // Debug.Log("Start com: " + comboNo);
        switch (comboNo)
        {
            case 0:
                StartCombo("com1", comboCd[comboNo]);
                break;
            case 1:
                StartCombo("com2", comboCd[comboNo]);
                break;
            case 2:
                StartCombo("buff", comboCd[comboNo]);
                break;
            case 3:
                StartCombo("ultimate", comboCd[comboNo]);
                break;
        }
    }
    private void ResetCombo()
    {
        animator.SetBool("com1", false);
        animator.SetBool("com2", false);
        animator.SetBool("buff", false);
        animator.SetBool("ultimate", false);
    }
    private void StartCombo(string triggerName, float cd)
    {
        animator.SetBool(triggerName, true);
        cooldownTimer = cd;
        animator.SetBool("isCooldown", true);
    }
    public void ShootElement(int no)
    {
        if (target) transform.LookAt(target);
        GameObject cainFire = Instantiate(fireObject[no], firePoint.position, transform.rotation);

        cainFire.transform.Find("Collider").GetComponent<DamageToPlayer>().SetDamage(CriDmg() + atk + no * 5);
    }
    public void Ultimate()
    {
        if (monsterId == MonsterId.Cain)
        {
            if (target) transform.LookAt(target);
            GameObject ultimate = Instantiate(ultiObject, firePoint.position, transform.rotation);
            ultimate.GetComponent<DamageToPlayer>().SetDamage((int)(atk * 1.3f) + CriDmg());
        }
        else
        {
            GameObject buffUltimate = Instantiate(ultiObject, transform.position, ultiObject.transform.rotation);
            //*health 30 percent of maxHP
            int health = (int)(maxHealthPoint * 0.3);
            if (health + hp <= maxHealthPoint) hp += health;
            else hp = maxHealthPoint;
        }
    }
    public void BuffMonster()
    {
        GameObject buffFx = Instantiate(buffEffect, transform.position, buffEffect.transform.rotation);
        //TODO buff some stat if cain buff cri?? abel def? regen heal??
        if (monsterId == MonsterId.Abel)
        {
            //*increase def stat
            defBuffTimer = 0;
            defBuff = true;
        }
        else //Cain
        {
            //*increase cri and atk
            criDamageBuffTimer = 0;
            criDamageBuff = true;
        }
        // NextTurn();
    }
    private int CriDmg()
    {
        if (criDamageBuff)
        {
            if (Random.Range(0, 10) < 3) return (int)(atk * 0.3f);
        }
        return 0;
    }
    private int DefIncrease()
    {
        if (defBuff) return (int)(defense * 0.2);
        return 0;
    }
    private void NextTurn()
    {
        if (turn == 7) turn = 0;
        else turn++;
    }
}
