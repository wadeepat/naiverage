using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> yourInventory = new List<Item>();
    public List<Item> draggedItem = new List<Item>();

    public int slotsNumber = 28;
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
            yourInventory[i] = Database.itemList[0];
        }
        //test
        yourInventory[0] = Database.itemList[1];
        slotStack[0] += 98;
        a = -1;
        b = -1;
    }

    void Update()
    {
        for(int i=0; i < slotsNumber; i++){
            if(yourInventory[i].id == 0 || slotStack[i] == 1){
                stackText[i].text = "";
            }else{
                stackText[i].text = ""+ slotStack[i];
            }
        }

        for(int i=0; i < slotsNumber; i++){
            slot[i].sprite = slotSprite[i];
        }

        for(int i=0; i < slotsNumber; i++){
            slotSprite[i] = yourInventory[i].itemSprite;
        }

        if(ItemPickUp.y != null){
            x = ItemPickUp.y;
            n = x.GetComponent<ThisItem>().thisId;
        }else{
            x = null;
        }

        if(ItemPickUp.pick == true){
            for(int i=0; i < slotsNumber; i++){
                if(yourInventory[i].id == n){
                    if(slotStack[i] == maxStacks){
                        continue;
                    }else{
                        slotStack[i] += 1;
                        i = slotsNumber;
                        ItemPickUp.pick = false;
                    }
                    
                }
            }

            for(int i=0; i < slotsNumber; i++){
                if(yourInventory[i].id == 0 && ItemPickUp.pick == true){
                    yourInventory[i] = Database.itemList[n];
                    slotStack[i] += 1;
                    ItemPickUp.pick = false;
                }
            }
            ItemPickUp.pick = false;
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
            if(yourInventory[a].id == yourInventory[b].id){
                if(slotStack[b] == maxStacks){
                    draggedItem[0] = yourInventory[a];
                    slotTemporary = slotStack[a];
                    yourInventory[a] = yourInventory[b];
                    slotStack[a] = slotStack[b];
                    yourInventory[b] = draggedItem[0];
                    slotStack[b] = slotTemporary;
                }else{
                    slotStack[b] += slotStack[a];
                    if(slotStack[b] > maxStacks){
                        slotStack[a] = slotStack[b] - maxStacks;
                        slotStack[b] = maxStacks;
                    }else if(slotStack[b] == maxStacks){
                        slotStack[a] = 0;
                        yourInventory[a] = Database.itemList[0];
                    }else{
                        slotStack[a] = 0;
                        yourInventory[a] = Database.itemList[0];
                    }
                }
                
            }else{
                draggedItem[0] = yourInventory[a];
                slotTemporary = slotStack[a];
                yourInventory[a] = yourInventory[b];
                slotStack[a] = slotStack[b];
                yourInventory[b] = draggedItem[0];
                slotStack[b] = slotTemporary;
            }
            
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
