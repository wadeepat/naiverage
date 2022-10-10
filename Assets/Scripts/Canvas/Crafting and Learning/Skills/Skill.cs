using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Skill 
{
    // Start is called before the first frame update
    public int id;
    public string nameSkill;
    public string description;
    public Sprite itemSprite;
    public int stack;

    public bool learned;

    public int n1;
    public int n2;

    public int q1;
    public int q2;

    // Update is called once per frame
    public Skill(){

    }

    public Skill(int Id, string Name, string Description, Sprite ItemSprite, int Stack, bool Learned, int N1, int N2, int Q1, int Q2){
        id = Id;
        nameSkill = Name;
        description = Description;
        itemSprite = ItemSprite; //image
        stack = Stack;
        learned = Learned;
        n1 = N1;
        n2 = N2;
        q1 = Q1;
        q2 = Q2;

    }
}
