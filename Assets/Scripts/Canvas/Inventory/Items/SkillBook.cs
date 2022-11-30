using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class SkillBook
{
    
    public int id;
    public string bookName;
    public string description;
    public Sprite itemSprite;
    public int stack;

    // Update is called once per frame
    public SkillBook(){

    }

    public SkillBook(int Id, string Name, string Description, Sprite ItemSprite, int Stack){
        id = Id;
        bookName = Name;
        description = Description;
        itemSprite = ItemSprite; //image
        stack = Stack;
    }
}
