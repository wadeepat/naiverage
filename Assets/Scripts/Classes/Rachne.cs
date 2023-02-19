using UnityEngine;

public class Rachne : Enemy
{
    [SerializeField] private float[] comboCd = new float[] { 2f, 3f };
    private MonsterSpawn monsterSpawn;
    private int comboCounter = -1;
    protected override void Start()
    {
        base.Start();
        comboCounter = -1;
        monsterSpawn = transform.parent.GetComponent<MonsterSpawn>();
    }
    public override void OnIdleStateEnter()
    {
        animator.SetBool("summon", false);
        animator.SetBool("shootPoison", false);
        StayThisPosition();
        SetToWalk();
    }
    // public override void OnIdleStateUpdate()
    // {

    // }
    public override void OnChaseStateEnter()
    {
        // comboNo = Random.Range(0, 4);
        if (comboCounter != 3) comboCounter++;
        else comboCounter = 0;
    }
    public override void OnChaseStateUpdate()
    {
        if (agent.enabled)
        {
            if (agent.speed < chaseSpeed)
            {
                if (agent.speed + 0.15f * Time.deltaTime > chaseSpeed)
                    agent.speed = chaseSpeed;
                else agent.speed += 0.15f * Time.deltaTime;
            }
            animator.SetFloat("accelerate", (agent.speed - moveSpeed) / (chaseSpeed - moveSpeed));

            agent.SetDestination(target.position);
            if (comboCounter == 2)
            {
                RachneCombo(comboCounter);
            }
            else
            {
                float distance = Vector2.Distance(target.position, gameObject.transform.position);
                if (distance < agent.stoppingDistance)
                {
                    RachneCombo(comboCounter);
                }
            }

        }
    }
    private void RachneCombo(int n)
    {
        if (n != 2)
        {
            animator.SetBool("shootPoison", true);
            cooldownTime = comboCd[0];
            animator.SetBool("isCooldown", true);
        }
        else
        {
            animator.SetBool("summon", true);
            cooldownTime = comboCd[1];
            animator.SetBool("isCooldown", true);
        }
    }
    public override void ShootProjectileObject()
    {
        GameObject poision = Instantiate(projectileObj, firePoint.position, transform.rotation);
        // cooldownTimer = 0;
    }
    public void SummonHenchman()
    {
        // int random = Random.Range(0, 1);
        monsterSpawn.SpawnMonster(Random.Range(0, 2), 1);
        monsterSpawn.SpawnMonster(Random.Range(0, 2), 1);
    }
}
