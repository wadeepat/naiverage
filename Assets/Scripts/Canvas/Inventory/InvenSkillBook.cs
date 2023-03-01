using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvenSkillBook : MonoBehaviour, IDataPersistence
{
    public List<SkillBook> yourSkillbook ;
    public List<SkillBook> draggedItem = new List<SkillBook>();
    // public int[] slotStack;

    public static int amount;

    [SerializeField] private Image[] slot;
    [SerializeField] private Sprite[] slotSprite;
    [SerializeField] private Text[] stackText;

    private GameObject x;
    private int n;
    private int slotsNumber = 8;

    void Start()
    {


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

    public void AddSkillBook(int idSkillBook){
        yourSkillbook.Add(Database.skillBookList[idSkillBook]);
    }

    public void LoadData(GameData data)
    {
        yourSkillbook = data.skillBooks;
        // if(yourSkillbook == null){
        //     for(int i=0; i<9; i++) yourSkillbook.Add(Database.skillBookList[i+1]);
        // }
    }

    public void SaveData(GameData data)
    {
        data.skillBooks = yourSkillbook;
    }
}
