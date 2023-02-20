using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillsUnlock : MonoBehaviour, IDataPersistence
{
    public List<Skill> skill;
    // public int[] slotStack;
    public int[] slotStackSkills;
    public Image[] slotSkillsM;

    [SerializeField] private List<Skill> draggedSkill = new List<Skill>();
    [SerializeField] private Image[] slot;
    [SerializeField] private Image[] slotSkills;
    [SerializeField] private Image[] slotSkillsInv;
    [SerializeField] private Sprite[] slotSprite;

    private int a;
    private int b;
    private int aSlot;
    private int bSlot;
    private int slotTemporary;
    private int slotsNumber = 12;


    // Start is called before the first frame update
    void Start()
    {
        a = -1;
        b = -1;
        aSlot = -1;
        bSlot = -1;
        slotSkillsM[0].fillAmount = 1f;
        slotSkillsM[1].fillAmount = 1f;
        slotSkillsM[2].fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < slotsNumber; i++){
            slot[i].sprite = slotSprite[i];
            slotSprite[i] = skill[i].itemSprite;
        }
        for(int i=0; i < 3; i++){
            if(slotStackSkills[i] == -1){
                slotSkills[i].sprite = Database.skillList[0].itemSprite;
                continue;
            }else if(skill[slotStackSkills[i]].id == 0){
                slotSkills[i].sprite = slotSprite[slotStackSkills[i]];
            }else{
                slotSkills[i].sprite = slotSprite[slotStackSkills[i]];
            }
        }
        for(int i=0; i < 3; i++){
            slotSkillsInv[i].sprite = slotSkills[i].sprite;
            slotSkillsM[i].sprite = slotSkills[i].sprite;
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
            for(int i=0; i < 3; i++){
                if(slotStackSkills[i] == a){
                    slotStackSkills[i] = b;
                }else if(slotStackSkills[i] == b){
                    slotStackSkills[i] = a;
                }
            }
            draggedSkill[0] = skill[a];
            skill[a] = skill[b];
            skill[b] = draggedSkill[0];
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
        for(int i=0; i < 3; i++){
            if(slotSkills[i] == slotX){
                aSlot = i;
            }
        }
    }

    public void EnterSlot(Image slotX){
        for(int i=0; i < 3; i++){
            if(slotSkills[i] == slotX){
                bSlot = i;
            }
        }
    }

    public void DropSlot(Image slotX){
        if(a>=0){
            for(int i = 0; i<3; i++){
                if(slotStackSkills[i] == a){
                    slotStackSkills[i] = slotStackSkills[bSlot];
                }
            }
            slotStackSkills[bSlot] = a;
            a = -1;
        }
        if(aSlot >= 0 && bSlot >=0){
            int tem = slotStackSkills[aSlot];
            slotStackSkills[aSlot] = slotStackSkills[bSlot];
            slotStackSkills[bSlot] = tem;
        }else if(aSlot >= 0 && bSlot == -1){
            slotStackSkills[aSlot] = -1;
        }
        aSlot=-1;
        bSlot=-1;
    }

    public void ExitSlot(Image slotX){
        bSlot = -1;
    }

    public void DropOut(){
        if(aSlot >= 0 && bSlot == -1){
            slotStackSkills[aSlot] = -1;
        }
        aSlot=-1;
        bSlot=-1;
    }

    public int GetSkillId (int num){
        return skill[slotStackSkills[num]].id;
    }

    public void learnSkill(int id){
        for(int i=0; i<slotsNumber; i++){
            if(skill[i].id == 0) {
                skill[i] = Database.skillList[id];
                break;
            }
        }
    }

    public void CooldownSkill(){
        if (slotSkillsM[0] != null && slotSkillsM[0].fillAmount < 1.0f) slotSkillsM[0].fillAmount += 0.1f * Time.deltaTime;
        if (slotSkillsM[1] != null && slotSkillsM[1].fillAmount < 1.0f) slotSkillsM[1].fillAmount += 0.1f * Time.deltaTime;
        if (slotSkillsM[2] != null && slotSkillsM[2].fillAmount < 1.0f) slotSkillsM[2].fillAmount += 0.1f * Time.deltaTime;
    }
    public void LoadData(GameData data)
    {
        Debug.Log("Load for skill");
        skill = data.skill;
        for(int i=0; i<slotsNumber; i++){
            if(skill[i].id == 0) skill[i] = Database.skillList[0];
        }
        slotStackSkills = data.slotS;
    }

    public void SaveData(GameData data)
    {
        Debug.Log("Save for skill");
        data.skill = skill;
        data.slotS = slotStackSkills;
    }
}
