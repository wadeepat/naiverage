using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class craft
{
    public int craftableItemId;
    public Text craftedItemName;
    public Sprite craftedItemSprite;
    public Image craftedItem;
    public Text[] craftingText;
    public Sprite[] slotInCraftingSprite;
    public Image[] slotInCrafting;

    public craft(){

    }

    public craft(int CraftableItemId, Text CraftedItemName, Sprite CraftedItemSprite,Image CraftedItem, Image[] SlotInCrafting, Sprite[] SlotInCraftingSprite, Text[] CraftingText){
        CraftableItemId = craftableItemId;
        CraftedItemName = craftedItemName;
        CraftedItemSprite = craftedItemSprite;
        CraftedItem = craftedItem;
        SlotInCrafting = slotInCrafting;
        SlotInCraftingSprite = slotInCraftingSprite;
        CraftingText = craftingText;
    }
}
