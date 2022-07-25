using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Item> itemList = new List<Item> ();

    void Awake(){
        // (id,name,description)
        itemList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemList.Add(new Item(1, "Mushroom", "Item", Resources.Load<Sprite>("1"), 0));
        itemList.Add(new Item(2, "Flower2", "Item", Resources.Load<Sprite>("2"), 0));

    }
}
