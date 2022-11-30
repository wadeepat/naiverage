using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Potions : MonoBehaviour
{
    public List<Potion> yourPotions = new List<Potion>();
    public List<Potion> draggedItem = new List<Potion>();
    public int[] slotP;
    public int[] slotStack;
    public Image[] slot;
    public Sprite[] slotSprite;

    [SerializeField] private Image[] slotPotion;
    [SerializeField] private Image[] slotPotionInv;
    [SerializeField] private Image[] slotPotionM;
    [SerializeField] private Text[] stackText;
    [SerializeField] private Text[] stackSlotPotionText;
    [SerializeField] private Text[] stackSlotPotionTextInv;
    [SerializeField] private Text[] stackSlotPotionTextM;

    private int a;
    private int b;
    private int aSlot;
    private int bSlot;
    private int slotTemporary;
    private int maxStacks = 16;
    private int slotsNumber = 16;

    void Start()
    {

        for(int i=0; i < slotsNumber; i++){
            yourPotions[i] = Database.potionList[0];
        }

        // test
        yourPotions[0] = Database.potionList[1];
        slotStack[0] += 16;
        yourPotions[1] = Database.potionList[2];
        slotStack[1] += 1;
        for(int j=0; j<4; j++) slotP[j] = -1;
        a = -1;
        b = -1;
        aSlot = -1;
        bSlot = -1;
        
    }

    void Update()
    {
        for(int i=0; i < slotsNumber; i++){
            if(yourPotions[i].id == 0 || slotStack[i] == 1){
                stackText[i].text = "";
            }else{
                stackText[i].text = ""+ slotStack[i];
            }
            slot[i].sprite = slotSprite[i];
            slotSprite[i] = yourPotions[i].itemSprite;

        }
        for(int i=0; i < 4; i++){
            if(slotP[i] == -1){
                stackSlotPotionText[i].text = "";
                slotPotion[i].sprite = Database.potionList[0].itemSprite;
                continue;
            }else if(yourPotions[slotP[i]].id == 0 || slotStack[slotP[i]] == 1){
                stackSlotPotionText[i].text = "";
                slotPotion[i].sprite = slotSprite[slotP[i]];
            }else{
                stackSlotPotionText[i].text = ""+ slotStack[slotP[i]];
                slotPotion[i].sprite = slotSprite[slotP[i]];
            }
        }
        for(int i=0; i < 4; i++){
           stackSlotPotionTextInv[i].text = stackSlotPotionText[i].text;
           stackSlotPotionTextM[i].text = stackSlotPotionText[i].text;
           slotPotionInv[i].sprite = slotPotion[i].sprite;
           slotPotionM[i].sprite = slotPotion[i].sprite;
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
            for(int i=0; i < 4; i++){
                if(slotP[i] == a){
                    slotP[i] = b;
                }else if(slotP[i] == b){
                    slotP[i] = a;
                }
            }
            if(yourPotions[a].id == yourPotions[b].id){
                if(slotStack[b] == maxStacks){
                    draggedItem[0] = yourPotions[a];
                    slotTemporary = slotStack[a];
                    yourPotions[a] = yourPotions[b];
                    slotStack[a] = slotStack[b];
                    yourPotions[b] = draggedItem[0];
                    slotStack[b] = slotTemporary;
                }else{
                    slotStack[b] += slotStack[a];
                    if(slotStack[b] > maxStacks){
                        slotStack[a] = slotStack[b] - maxStacks;
                        slotStack[b] = maxStacks;
                    }else if(slotStack[b] == maxStacks){
                        slotStack[a] = 0;
                        yourPotions[a] = Database.potionList[0];
                    }else{
                        slotStack[a] = 0;
                        yourPotions[a] = Database.potionList[0];
                    }
                }
                
            }else{
                draggedItem[0] = yourPotions[a];
                slotTemporary = slotStack[a];
                yourPotions[a] = yourPotions[b];
                slotStack[a] = slotStack[b];
                yourPotions[b] = draggedItem[0];
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

    public void StartDragSlot(Image slotX){
        for(int i=0; i < 4; i++){
            if(slotPotion[i] == slotX){
                aSlot = i;
            }
        }
    }

    public void EnterSlot(Image slotX){
        for(int i=0; i < 4; i++){
            if(slotPotion[i] == slotX){
                bSlot = i;
            }
        }
    }

    public void DropSlot(Image slotX){
        if(a>=0){
            for(int i = 0; i<4; i++){
                if(slotP[i] == a){
                    slotP[i] = slotP[bSlot];
                }
            }
            slotP[bSlot] = a;
            a = -1;
        }
        if(aSlot >= 0 && bSlot >=0){
            int tem = slotP[aSlot];
            slotP[aSlot] = slotP[bSlot];
            slotP[bSlot] = tem;
        }else if(aSlot >= 0 && bSlot == -1){
            slotP[aSlot] = -1;
        }
        aSlot=-1;
        bSlot=-1;
    }

    public void ExitSlot(Image slotX){
        bSlot = -1;
    }
    public void DropOut(){
        if(aSlot >= 0 && bSlot == -1){
            slotP[aSlot] = -1;
        }
        aSlot=-1;
        bSlot=-1;
    }
}
