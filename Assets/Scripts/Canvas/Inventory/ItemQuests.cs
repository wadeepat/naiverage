using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemQuests : MonoBehaviour
{
    public List<Item> yourItemQuests = new List<Item>();
    public List<Item> draggedItem = new List<Item>();

    public int slotsNumber = 8;
    public GameObject x;
    public int n;

    public Image[] slot;
    public Sprite[] slotSprite;

    public Text[] stackText;

    public int a;
    public int b;

    public int[] slotStack;
    public int maxStacks;

    public int slotTemporary;

    void Start()
    {

        for(int i=0; i < slotsNumber; i++){
            yourItemQuests[i] = Database.itemQuestList[0];
        }
        // test
        yourItemQuests[0] = Database.itemQuestList[1];
        slotStack[0] += 1;
        yourItemQuests[1] = Database.itemQuestList[2];
        slotStack[1] += 1;
        a = -1;
        b = -1;

    }

    void Update()
    {
        for(int i=0; i < slotsNumber; i++){
            if(yourItemQuests[i].id == 0 || slotStack[i] == 1){
                stackText[i].text = "";
            }else{
                stackText[i].text = ""+ slotStack[i];
            }
        }

        for(int i=0; i < slotsNumber; i++){
            slot[i].sprite = slotSprite[i];
        }

        for(int i=0; i < slotsNumber; i++){
            slotSprite[i] = yourItemQuests[i].itemSprite;
        }

    }

    public void StartDrag(Image slotX){
        for(int i=0; i < slotsNumber; i++){
            if(slot[i] == slotX){
                a = i;
            }
        }
    }

    public void Drop(Image slotX){
        if(a!=b && a != -1 && b !=-1){
            draggedItem[0] = yourItemQuests[a];
            slotTemporary = slotStack[a];
            yourItemQuests[a] = yourItemQuests[b];
            slotStack[a] = slotStack[b];
            yourItemQuests[b] = draggedItem[0];
            slotStack[b] = slotTemporary;
        }
        a=-1;
        b=-1;
    }

    public void Enter(Image slotX){
        for(int i=0; i < slotsNumber; i++){
            if(slot[i] == slotX){
                b = i;
            }
        }
    }
    
    public void Exit(Image slotX){
        b = -1;
    }
}
