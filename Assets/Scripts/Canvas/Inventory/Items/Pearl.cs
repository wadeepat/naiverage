using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Pearl
{
    public int id;
    public string magicPearl;
    public string description;
    public Sprite itemSprite;
    public int stack;

    // Update is called once per frame
    public Pearl(){

    }

    public Pearl(int Id, string Name, string Description, Sprite ItemSprite, int Stack){
        id = Id;
        magicPearl = Name;
        description = Description;
        itemSprite = ItemSprite; //image
        stack = Stack;
    }
}
