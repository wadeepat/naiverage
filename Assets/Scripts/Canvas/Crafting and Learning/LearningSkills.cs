using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningSkills : MonoBehaviour
{
    public int page;
    public int firstPage;
    public int lastPage;
    public Text currentPage;
    public Text allPage;
    public Learn[] skills = new Learn[4];
    private GameObject Skill;
    InvenSkillBook invenSkillBook;
    SkillsUnlock invenSkill;

    void Start()
    {
        Skill = GameObject.Find("Canvas/Panel/Character panel/All funtion/Skill");
        invenSkillBook = Skill.GetComponent<InvenSkillBook>();
        invenSkill = Skill.GetComponent<SkillsUnlock>();
        page = 1;
        firstPage = 1;
        if(invenSkillBook.yourSkillbook.Count <= 4)lastPage = 1;
        else if(invenSkillBook.yourSkillbook.Count <= 8) lastPage = 2;
        else lastPage = 3;
        currentPage.text = "" + page;
        allPage.text = "" + lastPage;
        if(invenSkillBook.yourSkillbook != null) show(page);
    }
    // Update is called once per frame
    void Update()
    {
           
    }

    void show(int pageNow){
        int num,id;
        if(pageNow == 1) num = 0;
        else if(pageNow == 2)num = 4;
        else num = 8;
        for(int i=0; i<4; i++){
            if(i+num >= invenSkillBook.yourSkillbook.Count){     
                Load(0, skills[i].skillName, skills[i].itemSprite, skills[i].skillSprite, skills[i].slotInSprite, skills[i].slotInSkill, skills[i].text, skills[i].button);
            }else{
                id = invenSkillBook.yourSkillbook[i+num].id;
                Load(id, skills[i].skillName, skills[i].itemSprite, skills[i].skillSprite, skills[i].slotInSprite, skills[i].slotInSkill, skills[i].text, skills[i].button);
            }
        }
    }

    void Load(int skillId, Text skillName, Sprite itemSprite, Image skillSprite, Sprite[] slotInSprite, Image[] slotInSkill, Text[] text, Button button){
        skillName.text = "" + Database.skillList[skillId].nameSkill;

        itemSprite = Database.skillList[skillId].itemSprite;
        skillSprite.sprite = itemSprite;

        slotInSprite[0] = Database.skillBookList[Database.skillList[skillId].n1].itemSprite;
        if(skillId == 0) slotInSprite[1] = Database.itemList[0].itemSprite;
        else slotInSprite[1] = Database.magicPearl.itemSprite;

        slotInSkill[0].sprite = slotInSprite[0];
        slotInSkill[1].sprite = slotInSprite[1];

        if(Database.skillList[skillId].q1 == 0) text[0].text = "";
        else text[0].text = ""+Database.skillList[skillId].q1;
        if(Database.skillList[skillId].q2 == 0) text[1].text = "";
        else text[1].text = ""+Database.skillList[skillId].q2;

        if(skillId ==0) button.gameObject.SetActive(false);
        else if(MagicPearls.CheckPearl() < Database.skillList[skillId].q2) button.gameObject.SetActive(false);
        else button.gameObject.SetActive(true);
    }

    public void click(int id){
        
        if(page == 1){
            invenSkill.learnSkill(invenSkillBook.yourSkillbook[id].id);
            invenSkillBook.yourSkillbook.RemoveAt(id);
            show(page);
        }else if(page == 2){
            invenSkill.learnSkill(invenSkillBook.yourSkillbook[id+4].id);
            invenSkillBook.yourSkillbook.RemoveAt(id+4);
            show(page);
        }else{
            invenSkill.learnSkill(invenSkillBook.yourSkillbook[id+8].id);
            invenSkillBook.yourSkillbook.RemoveAt(id+8);
            show(page);
        }
        if(invenSkillBook.yourSkillbook.Count <= 4)lastPage = 1;
        else if(invenSkillBook.yourSkillbook.Count <= 8) lastPage = 2;
        else lastPage = 3;
        if(page > lastPage){
            page -= 1;
            show(page);
            currentPage.text = "" + page;
        } 
        allPage.text = "" + lastPage;
    }

    public void PreviousItem(){
        if(page > firstPage){
            page--;
            show(page);
            currentPage.text = "" + page;
        }
    }

    public void NextItem(){
        if(page < lastPage){
            page++; 
            show(page);
            currentPage.text = "" + page;
        }
    }

    public void SetDefault(){
        page = 1;
        firstPage = 1;
        if(invenSkillBook?.yourSkillbook.Count <= 4 )lastPage = 1;
        else if(invenSkillBook?.yourSkillbook.Count <= 8) lastPage = 2;
        else lastPage = 3;
        currentPage.text = "" + page;
        allPage.text = "" + lastPage;
        if(invenSkillBook?.yourSkillbook != null) show(page);
    }
}
