using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Learn
{
    public int skillId;
    public Text skillName;
    public Sprite itemSprite;
    public Image skillSprite;
    public Text[] text;
    public Sprite[] slotInSprite;
    public Image[] slotInSkill;
    public Button button;

    public Learn(){

    }

    public Learn(int SkillId, Text SkillName, Sprite ItemSprite,Image SkillSprite, Image[] SlotInSkill, Sprite[] SlotInSprite, Text[] Text, Button Button){
        SkillId = skillId;
        SkillName = skillName;
        ItemSprite = itemSprite;
        SkillSprite = skillSprite;
        SlotInSkill = slotInSkill;
        SlotInSprite = slotInSprite;
        Text = text;
        Button = button;
    }
}
