using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> yourInventory = new List<Item>();

    public int slotsNumber = 28;
    public GameObject x;
    public int n;

    public Image[] slot;
    public Sprite[] slotSprite;

    public Text[] stackText;
    // Start is called before the first frame update
    void Start()
    {
        //test
        for(int i=0; i < slotsNumber; i++){
            yourInventory[i] = Database.itemList[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                    yourInventory[i].stack += 1;
                    i = slotsNumber;
                    ItemPickUp.pick = false;
                }
            }

            for(int i=0; i < slotsNumber; i++){
                if(yourInventory[i].id == 0 && ItemPickUp.pick == true){
                    yourInventory[i] = Database.itemList[n];
                    yourInventory[i].stack += 1;
                    ItemPickUp.pick = false;
                }
            }
            ItemPickUp.pick = false;
        }

        for(int i=0; i < slotsNumber; i++){
            stackText[i].text = ""+ yourInventory[i].stack;
        }
    }
}
