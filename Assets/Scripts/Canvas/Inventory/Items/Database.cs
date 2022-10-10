using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Item> itemList = new List<Item> ();
    public static List<Potion> potionList = new List<Potion> ();
    public static List<Item> itemQuestList = new List<Item> ();
    public static List<SkillBook> skillBookList = new List<SkillBook>();
    public static Pearl magicPearl = new Pearl();

    public static List<Skill> skillList = new List<Skill>();

    void Awake(){
        // (id,name,description)
        itemList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemList.Add(new Item(1, "Mushroom", "Item", Resources.Load<Sprite>("1"), 0));
        itemList.Add(new Item(2, "Flower2", "Item", Resources.Load<Sprite>("2"), 0));

        potionList.Add(new Potion(0, "None", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(1, "HP", "Potion", Resources.Load<Sprite>("p1"), 0, true, 1, 2, 0, 2, 3, 0));
        potionList.Add(new Potion(2, "Stamina", "Potion", Resources.Load<Sprite>("p2"), 0, true, 1, 0, 0, 5, 0, 0));
        potionList.Add(new Potion(3, "t1", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(4, "t2", "Potion", Resources.Load<Sprite>("p1"), 0, true, 1, 2, 0, 2, 3, 0));
        potionList.Add(new Potion(5, "t3", "Potion", Resources.Load<Sprite>("p2"), 0, true, 1, 0, 0, 5, 0, 0));
        potionList.Add(new Potion(6, "t4", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(7, "t5", "Potion", Resources.Load<Sprite>("p1"), 0, true, 1, 2, 0, 2, 3, 0));
        potionList.Add(new Potion(8, "t6", "Potion", Resources.Load<Sprite>("p2"), 0, true, 1, 0, 0, 5, 0, 0));

        itemQuestList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemQuestList.Add(new Item(1, "Quest1", "Quest", Resources.Load<Sprite>("q1"), 0));
        itemQuestList.Add(new Item(2, "Quest2", "Quest", Resources.Load<Sprite>("q2"), 0));

        skillBookList.Add(new SkillBook(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        skillBookList.Add(new SkillBook(1, "SKB1", "None", Resources.Load<Sprite>("skb1"), 0));
        skillBookList.Add(new SkillBook(2, "SKB2", "None", Resources.Load<Sprite>("skb2"), 0));
        skillBookList.Add(new SkillBook(3, "SKB3", "None", Resources.Load<Sprite>("skb3"), 0));
        skillBookList.Add(new SkillBook(4, "SKB4", "None", Resources.Load<Sprite>("skb4"), 0));

        magicPearl = new Pearl(0, "Magic Pearl", "None", Resources.Load<Sprite>("Pearl"), 0);

        skillList.Add(new Skill(0, "None", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0));
        skillList.Add(new Skill(1, "SK1", "None", Resources.Load<Sprite>("sk1"), 0, false, 1, 0, 1, 500));
        skillList.Add(new Skill(2, "SK2", "None", Resources.Load<Sprite>("sk2"), 0, false, 2, 0, 1, 1000));
        skillList.Add(new Skill(3, "SK3", "None", Resources.Load<Sprite>("sk3"), 0, false, 3, 0, 1, 1500));
        skillList.Add(new Skill(4, "SK4", "None", Resources.Load<Sprite>("sk4"), 0, false, 4, 0, 1, 2000));


    }
}
