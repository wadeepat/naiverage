using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MonsterId
{
    Webster = 0,
    Venom = 1,
    Rachne = 2,
    Bandit = 3,
    Elf = 4,
    Skeleton = 5,
    Troll = 6,
    Cain = 7,
    Abel = 8
}
public class Monster
{
    public int id;
    public string name;
    public float hp;
    // public float mp;
    // private static int reMp;
    public int atk;
    // private static int critDamage;
    // private static int critRate;
    public int def;
    public int res;
    public int reHp;
    public Monster(int id, float hp, int atk, int def, int res, int reHp)
    {
        this.id = id;
        this.name = ((MonsterId)id).ToString();
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.reHp = reHp;
    }
}
