using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisItem : MonoBehaviour
{
    public List<Item> thisItem = new List<Item>();

    public int thisId;
    public int id;
    public string itemName;
    public string itemDescription;

    public enum TypeItem {Normal, Potion, Quest}

    // Use this for initialization
    void Start()
    {
        thisItem[0] = Database.itemList[thisId];
        id = thisItem[0].id;
        itemName = thisItem[0].name;
        itemDescription = thisItem[0].description;
    }

    // Update is called once per frame
    // void Update()
    // {
    // }
}
