using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    // public int craftableItemId;
    public int page;
    public int firstPage;
    public int lastPage;
    public Text currentPage;
    public Text allPage;

    public craft[] craft = new craft[4];
    

    public bool craftAble;

    void Start()
    {
        page = 1;
        firstPage = 1;
        lastPage = 3;
        currentPage.text = "" + page;
        allPage.text = "" + lastPage;
        for(int i=0; i<4; i++){
        Load(craft[i].craftableItemId, craft[i].craftedItemName, craft[i].craftedItemSprite, craft[i].craftedItem, craft[i].slotInCraftingSprite, craft[i].slotInCrafting, craft[i].craftingText);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Load(int craftableItemId, Text craftedItemName, Sprite craftedItemSprite, Image craftedItem, Sprite[] SlotInCraftingSprite, Image[] SlotInCrafting, Text[] craftingText){
        craftedItemName.text = "" + Database.potionList[craftableItemId].name;

        craftedItemSprite = Database.potionList[craftableItemId].itemSprite;
        craftedItem.sprite = craftedItemSprite;

        SlotInCraftingSprite[0] = Database.itemList[Database.potionList[craftableItemId].n1].itemSprite;
        SlotInCraftingSprite[1] = Database.itemList[Database.potionList[craftableItemId].n2].itemSprite;
        SlotInCraftingSprite[2] = Database.itemList[Database.potionList[craftableItemId].n3].itemSprite;

        SlotInCrafting[0].sprite = SlotInCraftingSprite[0];
        SlotInCrafting[1].sprite = SlotInCraftingSprite[1];
        SlotInCrafting[2].sprite = SlotInCraftingSprite[2];

        craftingText[0].text = ""+Database.potionList[craftableItemId].q1;
        craftingText[1].text = ""+Database.potionList[craftableItemId].q2;
        craftingText[2].text = ""+Database.potionList[craftableItemId].q3;
    }

    public void PreviousItem(){
        if(page > firstPage){
            for(int i=0; i<4; i++){
                craft[i].craftableItemId -= 4;
                Load(craft[i].craftableItemId, craft[i].craftedItemName, craft[i].craftedItemSprite, craft[i].craftedItem, craft[i].slotInCraftingSprite, craft[i].slotInCrafting, craft[i].craftingText);
            }
            page--;
            currentPage.text = "" + page;
        }
    }

    public void NextItem(){
        if(page < lastPage){
            for(int i=0; i<4; i++){
                craft[i].craftableItemId += 4;
                Load(craft[i].craftableItemId, craft[i].craftedItemName, craft[i].craftedItemSprite, craft[i].craftedItem, craft[i].slotInCraftingSprite, craft[i].slotInCrafting, craft[i].craftingText);
            }
            page++; 
            currentPage.text = "" + page;
        }
    }

    public void CraftItem(int button){
        int a = 0;
        int b = 0;
        int c = 0;
        int craftableItemId = craft[button].craftableItemId;
        //check craftable
        for(int i=0; i < 28; i++){
            if(GetComponent<Inventory>().yourInventory[i].id == Database.potionList[craftableItemId].n1){
                a += GetComponent<Inventory>().slotStack[i];
            }
            if(GetComponent<Inventory>().yourInventory[i].id == Database.potionList[craftableItemId].n2){
                b += GetComponent<Inventory>().slotStack[i];
            }
            if(GetComponent<Inventory>().yourInventory[i].id == Database.potionList[craftableItemId].n3){
                c += GetComponent<Inventory>().slotStack[i];
            }
        }

        if(a >= Database.potionList[craftableItemId].q1 && b>= Database.potionList[craftableItemId].q2 && c >= Database.potionList[craftableItemId].q3){
            craftAble = true;
        }else{
            craftAble = false;
        }



        if(craftAble == true){
            a = Database.potionList[craftableItemId].q1;
            b = Database.potionList[craftableItemId].q2;
            c = Database.potionList[craftableItemId].q3;

            //Potion
            List<Potion> yourPotions = GetComponent<Potions>().yourPotions;
            int[] slotStack = GetComponent<Potions>().slotStack;
            
            //Inventory
            List<Item> yourInventory = GetComponent<Inventory>().yourInventory;
            int[] inventorySlotStack = GetComponent<Inventory>().slotStack;

            for(int i =0; i < 16; i++){
                if(yourPotions[i].id == craftableItemId){
                    if(slotStack[i] >= 16){
                        continue;
                    }else{
                        slotStack[i] += 1;
                        i = 16;
                    }
                }else if(yourPotions[i] == Database.potionList[0]){
                    yourPotions[i] = Database.potionList[craftableItemId];
                    slotStack[i] += 1;
                    i = 16;
                }
            }
            for(int j=0; j<28; j++){
                if(yourInventory[j].id == Database.potionList[craftableItemId].n1 && a>0){
                    if(inventorySlotStack[j]>=a){
                        inventorySlotStack[j] -= a;
                        if(inventorySlotStack[j]==0)yourInventory[j] = Database.itemList[0];
                        break;
                    }
                }
            }
            for(int k=0; k<28; k++){
                if(yourInventory[k].id == Database.potionList[craftableItemId].n2 && b>0){
                    if(inventorySlotStack[k]>=b){
                        inventorySlotStack[k] -= b;
                        if(inventorySlotStack[k]==0)yourInventory[k] = Database.itemList[0];
                        break;
                    }
                }
            }
            for(int l=0; l<28; l++){
                if(yourInventory[l].id == Database.potionList[craftableItemId].n3 && c>0){
                    if(inventorySlotStack[l]>=c){
                        inventorySlotStack[l] -= c;
                        if(inventorySlotStack[l]==0)yourInventory[l] = Database.itemList[0];
                        break;
                    }
                }
            }
            craftAble = false;
        }

    }
    
}

