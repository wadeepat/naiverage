using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvenSkillBook : MonoBehaviour
{
    public List<SkillBook> yourSkillbook;
    public List<SkillBook> draggedItem = new List<SkillBook>();
    // public int[] slotStack;

    public static int amount;

    [SerializeField] private Image[] slot;
    [SerializeField] private Sprite[] slotSprite;
    [SerializeField] private Text[] stackText;

    private GameObject x;
    private int n;
    private int a;
    private int b;
    private int slotTemporary;
    private int maxStacks = 1;
    private int slotsNumber = 8;

    void Start()
    {

        // for(int i=0; i < slotsNumber; i++){
        //     yourSkillbook[i] = Database.skillBookList[0];
        // }
        // test
        yourSkillbook.Add(Database.skillBookList[1]);
        yourSkillbook.Add(Database.skillBookList[2]);
        yourSkillbook.Add(Database.skillBookList[3]);
        yourSkillbook.Add(Database.skillBookList[4]);
        yourSkillbook.Add(Database.skillBookList[5]);
        yourSkillbook.Add(Database.skillBookList[6]);
        yourSkillbook.Add(Database.skillBookList[7]);
        yourSkillbook.Add(Database.skillBookList[8]);
        yourSkillbook.Add(Database.skillBookList[9]);
        a = -1;
        b = -1;

    }
    public void GetSkillBook(){
        if(ItemPickUp.y != null){
            x = ItemPickUp.y;
            if(x.GetComponent<ThisItem>().type == TypeItem.Skill) n = x.GetComponent<ThisItem>().thisId;
        }
        if(ItemPickUp.pick == true && x.GetComponent<ThisItem>().type == TypeItem.Skill){

            for(int i=0; i < slotsNumber; i++){
                if(yourSkillbook[i].id == 0 && ItemPickUp.pick == true){
                    yourSkillbook[i] = Database.skillBookList[n];
                }
            }
            //checkquest
            // QuestLog.DoQuest(Quest.Objective.Type.collect, n);
            ItemPickUp.pick = false;
        }
    }

    void Update()
    {
        // for(int i=0; i < slotsNumber; i++){
        //     if(yourSkillbook[i].id == 0 || slotStack[i] == 1){
        //         stackText[i].text = "";
        //     }else{
        //         stackText[i].text = ""+ slotStack[i];
        //     }
        // }

        // for(int i=0; i < slotsNumber; i++){
        //     slot[i].sprite = slotSprite[i];
        //     slotSprite[i] = yourSkillbook[i].itemSprite;
        // }
        // int num = 0;
        // foreach (var yourSK in yourSkillbook){
        //     stackText[num].text = "";
        //     slot[num].sprite = slotSprite[num];
        //     slotSprite[num] = yourSK.itemSprite;
        //     num++;
        // }

    }

    // public void StartDrag(Image slotX){
    //     for(int i=0; i < slotsNumber; i++){
    //         if(slot[i] == slotX){
    //             a = i;
    //         }
    //     }
    // }

    // public void Drop(Image slotX){
    //     if(a!=b && a != -1 && b !=-1){
    //         draggedItem[0] = yourSkillbook[a];
    //         slotTemporary = slotStack[a];
    //         yourSkillbook[a] = yourSkillbook[b];
    //         slotStack[a] = slotStack[b];
    //         yourSkillbook[b] = draggedItem[0];
    //         slotStack[b] = slotTemporary;
    //     }
    //     a=-1;
    //     b=-1;
    // }

    // public void Enter(Image slotX){
    //     for(int i=0; i < slotsNumber; i++){
    //         if(slot[i] == slotX){
    //             b = i;
    //         }
    //     }
    // }
    
    // public void Exit(Image slotX){
    //     b = -1;
    // }
    // public void LoadData(GameData data)
    // {
    //     yourSkillbook = data.skillBooks;
    // }

    // public void SaveData(GameData data)
    // {
    //     data.skillBooks = yourSkillbook;
    // }
}
