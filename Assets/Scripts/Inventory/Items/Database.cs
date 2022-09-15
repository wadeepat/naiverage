using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Item> itemList = new List<Item> ();
    public static List<Potion> potionList = new List<Potion> ();
    public static List<Item> itemQuestList = new List<Item> ();

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

    }
}
