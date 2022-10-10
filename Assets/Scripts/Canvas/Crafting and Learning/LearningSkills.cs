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
    public bool Learned;

    void Start()
    {
        page = 1;
        firstPage = 1;
        lastPage = 1;
        currentPage.text = "" + page;
        allPage.text = "" + lastPage;
        for(int i=0; i<4; i++){
        Load(skills[i].skillId, skills[i].skillName, skills[i].itemSprite, skills[i].skillSprite, skills[i].slotInSprite, skills[i].slotInSkill, skills[i].text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load(int skillId, Text skillName, Sprite itemSprite, Image skillSprite, Sprite[] slotInSprite, Image[] slotInSkill, Text[] text){
        skillName.text = "" + Database.skillList[skillId].nameSkill;

        itemSprite = Database.skillList[skillId].itemSprite;
        skillSprite.sprite = itemSprite;

        slotInSprite[0] = Database.skillBookList[Database.skillList[skillId].n1].itemSprite;
        slotInSprite[1] = Database.magicPearl.itemSprite;

        slotInSkill[0].sprite = slotInSprite[0];
        slotInSkill[1].sprite = slotInSprite[1];

        text[0].text = ""+Database.skillList[skillId].q1;
        text[1].text = ""+Database.skillList[skillId].q2;
    }
}
