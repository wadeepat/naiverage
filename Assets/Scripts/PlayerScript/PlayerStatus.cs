using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    [SerializeField] private static int HP;
    [SerializeField] private static int MP;
    // [SerializeField] private GameObject healthBar;
    // [SerializeField] private GameObject manaBar;
    [SerializeField] private const float REGEN_HP_COOLDOWN = 5f;

    private static float hp, mp;
    private static int reMp, attack, critDamage, critRate, defense, resist, reHp;

    private Slider sliderHealth;
    private Slider sliderMana;
    private bool poison, agony, buff;
    private static int temp;
    private float poisonTime, agonyTime, buffTime;
    private float time = 0.0f;
    private float interpolationPeriod = 1.0f;
    private bool died;

    //timer
    private float damageTimer;


    void Start()
    {
        died = false;
        sliderHealth = CanvasManager.instance.GetCanvasObject("Panel/Bar/HealthBar").GetComponent<Slider>();
        sliderMana = CanvasManager.instance.GetCanvasObject("Panel/Bar/StaminaBar").GetComponent<Slider>();
        //timer
        damageTimer = REGEN_HP_COOLDOWN;
    }

    // Update is called once per frame
    void Update()
    {

        if (hp >= 0) sliderHealth.value = (float)hp / (float)HP;
        else sliderHealth.value = 0;

        if (mp >= 0) sliderMana.value = (float)mp / (float)MP;
        else sliderMana.value = 0;

        //Timer update
        if (damageTimer < REGEN_HP_COOLDOWN) damageTimer += Time.deltaTime;
        else RegenHP();

        if (mp < MP) mp += reMp * Time.deltaTime;

        CheckTimeAndStatus();

    }

    private void RegenHP()
    {
        if (hp < HP && !died) hp += reHp * Time.deltaTime;
    }

    public void TakeDamaged(int damageAmount)
    {
        int a = (int)(damageAmount * (100.0f / (100 + defense)));
        hp -= a;
        if (hp <= 0)
        {
            hp = 0;
            PlayerManager.instance.player.tag = "Untagged";
            ActionHandler.instance.AskToLoad();
            died = true;
            // healthBar.SetActive(false);
            AnnouceTheDeath();
            transform.GetComponent<Animator>().SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            // healthBar.SetActive(true);
            // animator.SetTrigger("damaged");
        }
        damageTimer = 0;
    }



    public static void HealthHP(int h)
    {
        hp += h;
        if (hp > HP)
            hp = HP;
    }

    public static void GetMP(int m)
    {
        mp += m;
        if (mp > MP)
            mp = MP;
    }

    public void PhialOfFreedom()
    {
        poison = false;
        agony = false;
    }
    public void ElixirOfRage()
    {
        if (!buff)
        {
            temp = attack;
            attack = (int)(attack + (attack * (20.0f / 100)));
        }
        buff = true;
        buffTime = 20.0f;

    }
    public static void MaxHPnMP()
    {
        hp = HP;
        mp = MP;
    }
    public static void UseMana(int m)
    {
        if (mp > m)
            mp -= m;
    }

    public static void upgradeStatus(int c, int num)
    {
        switch (c)
        {
            case 0:
                HP = num;
                break;

            case 1:
                hp = num;
                break;

            case 2:
                MP = num;
                break;

            case 3:
                mp = num;
                break;

            case 4:
                reMp = num;
                break;

            case 5:
                attack = num;
                break;
            case 6:
                critDamage = num;
                break;

            case 7:
                critRate = num;
                break;

            case 8:
                defense = num;
                break;

            case 9:
                resist = num;
                break;

        }
    }

    public static int[] callStatus()
    {
        int[] a = { HP, (int)hp, MP, (int)mp, reMp, attack, critDamage, critRate, defense, resist };
        return a;
    }

    public static int damageSkill(int crit)
    {
        //ATK + ATK * CRIT DMG
        return attack + (attack * crit / 100);
    }

    public void CheckTimeAndStatus()
    {
        time += Time.deltaTime;
        poisonTime -= Time.deltaTime;
        agonyTime -= Time.deltaTime;
        buffTime -= Time.deltaTime;
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

    public void StatusEffect()
    {

        //Enemy
        if (poison)
        {
            hp -= 2.0f;
            if (poisonTime < 0)
            {
                poison = false;
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

        //self
        if (buff)
        {
            if (buffTime <= 0)
            {
                attack = temp;
                buff = false;
            }
        }
    }
    private void AnnouceTheDeath()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            enemy.GetComponent<Enemy>().AwarePlayerDied(false);
    }

    public void LoadData(GameData data)
    {
        HP = data.HP;
        MP = data.MP;
        hp = data.hp;
        mp = data.mp;
        reHp = data.reHp;
        reMp = data.reMp;
        attack = data.attack;
        critDamage = data.critDamage;
        critRate = data.critRate;
        defense = data.defense;
        resist = data.resist;
    }

    public void SaveData(GameData data)
    {
        data.HP = HP;
        data.MP = MP;
        data.hp = hp;
        data.mp = mp;
        data.reHp = reHp;
        data.reMp = reMp;
        data.attack = attack;
        data.critDamage = critDamage;
        data.critRate = critRate;
        data.defense = defense;
        data.resist = resist;
    }

}
