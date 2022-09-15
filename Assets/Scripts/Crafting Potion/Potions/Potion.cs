using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Potion
{
    // Start is called before the first frame update
    public int id;
    public string name;
    public string description;
    public Sprite itemSprite;
    public int stack;

    public bool canBeCrafted;

    public int n1;
    public int n2;
    public int n3;

    public int q1;
    public int q2;
    public int q3;


    public Potion(){

    }

    public Potion(int Id, string Name, string Description, Sprite ItemSprite, int Stack, bool CanBeCrafted, int N1, int N2, int N3, int Q1, int Q2, int Q3){
        id = Id;
        name = Name;
        description = Description;
        itemSprite = ItemSprite; //image
        stack = Stack;

        canBeCrafted = CanBeCrafted;
        n1 = N1;
        n2 = N2;
        n3 = N3;
        q1 = Q1;
        q2 = Q2;
        q3 = Q3;


    }
}
