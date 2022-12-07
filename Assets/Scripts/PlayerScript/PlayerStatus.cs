using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private static int HP = 100;
    [SerializeField] private static int MP = 100;
    // [SerializeField] private GameObject healthBar;
    // [SerializeField] private GameObject manaBar;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Slider sliderMana;
    private static float hp;          
    private static float mp;          
    private static int reMp;        
    private static int attack;      
    private static int critDamage;  
    private static int critRate;    
    private static int defense;     
    private static int resist;      
    
    private static int reHp; // Can not upgrade
    private float count;


    
    void Start()
    {
        hp = HP;
        mp = MP;
        reHp = 1;
        reMp = 4;
        attack = 20;
        critDamage = 10;
        critRate = 20;
        defense = 10;
        resist = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp >= 0) sliderHealth.value = (float)hp / (float)HP;
        else sliderHealth.value = 0;

        if (mp >= 0) sliderMana.value = (float)mp / (float)MP;
        else sliderMana.value = 0;

        if (hp < HP) hp += reHp * Time.deltaTime;
        if (mp < MP) mp += reMp * Time.deltaTime;
    }


    public void TakeDamaged(int damageAmount)
    {
        int a = (int)(damageAmount*(100.0f/(100+defense)));
        hp -= a;
        Debug.Log("Hited left" + hp);
        if (hp <= 0)
        {
            hp = 0;
            // healthBar.SetActive(false);
            // animator.SetTrigger("die");
            // GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            // healthBar.SetActive(true);
            // animator.SetTrigger("damaged");
        }
    }

    
    
    public static void healthHP(int h){
        hp += h;
        if(hp > HP) 
            hp = HP;
    }

    public static void upgradeStatus(int c, int num){
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

    public static int[] callStatus(){
        int[] a = {HP,(int)hp,MP,(int)mp,reMp,attack,critDamage,critRate,defense,resist};
        return a;
    }





}
