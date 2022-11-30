using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvenSkillBook : MonoBehaviour
{
    public List<SkillBook> yourSkillbook = new List<SkillBook>();
    public List<SkillBook> draggedItem = new List<SkillBook>();
    public int[] slotStack;

    [SerializeField] private Image[] slot;
    [SerializeField] private Sprite[] slotSprite;
    [SerializeField] private Text[] stackText;

    private int a;
    private int b;
    private int slotTemporary;
    private int maxStacks = 1;
    private int slotsNumber = 8;

    void Start()
    {

        for(int i=0; i < slotsNumber; i++){
            yourSkillbook[i] = Database.skillBookList[0];
        }
        // test
        yourSkillbook[0] = Database.skillBookList[1];
        slotStack[0] += 1;
        yourSkillbook[1] = Database.skillBookList[2];
        slotStack[1] += 1;
        yourSkillbook[2] = Database.skillBookList[3];
        slotStack[2] += 1;
        yourSkillbook[3] = Database.skillBookList[4];
        slotStack[3] += 1;
        a = -1;
        b = -1;

    }

    void Update()
    {
        for(int i=0; i < slotsNumber; i++){
            if(yourSkillbook[i].id == 0 || slotStack[i] == 1){
                stackText[i].text = "";
            }else{
                stackText[i].text = ""+ slotStack[i];
            }
        }

        for(int i=0; i < slotsNumber; i++){
            slot[i].sprite = slotSprite[i];
        }

        for(int i=0; i < slotsNumber; i++){
            slotSprite[i] = yourSkillbook[i].itemSprite;
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
            draggedItem[0] = yourSkillbook[a];
            slotTemporary = slotStack[a];
            yourSkillbook[a] = yourSkillbook[b];
            slotStack[a] = slotStack[b];
            yourSkillbook[b] = draggedItem[0];
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
