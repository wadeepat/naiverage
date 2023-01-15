using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [Header("Final boss details")]
    [SerializeField] private float[] comboCd = new float[] { 0.75f, 1.5f, 0.25f, 2.5f };
    [SerializeField] private GameObject[] fireObject;
    [SerializeField] private GameObject buffEffect;
    private int comboNo;
    private int turn;
    public override void OnChaseStateEnter()
    {
        comboNo = Random.Range(0, 3);
    }
    public override void OnChaseStateUpdate()
    {
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
    private void MonsterCombo(int comboNo)
    {
        switch (comboNo)
        {
            case 0:
                TriggerCombo("com1", comboCd[comboNo]);
                break;
            case 1:
                TriggerCombo("com2", comboCd[comboNo]);
                break;
            case 2:
                TriggerCombo("buff", comboCd[comboNo]);
                break;
            case 3:
                TriggerCombo("ultimate", comboCd[comboNo]);
                break;
        }
    }
    private void TriggerCombo(string triggerName, float cd)
    {
        animator.SetTrigger(triggerName);
        cooldownTimer = cd;
        animator.SetBool("isCooldown", true);
    }
    public void ShootElement(int no, bool endCombo)
    {
        transform.LookAt(target);
        GameObject cainFire = Instantiate(fireObject[no], firePoint.position, transform.rotation);
        if (endCombo) NextTurn();
    }
    public void BuffMonster()
    {
        //TODO buff some stat if cain buff cri?? abel def? regen heal??
        if (monsterId == MonsterId.Abel)
        {

        }
        else //Cain
        {

        }
        NextTurn();
    }
    private void NextTurn()
    {
        if (turn == 7) turn = 0;
        else turn++;
    }
}
