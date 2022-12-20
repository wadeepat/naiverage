using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillsUnlock : MonoBehaviour
{
    public List<Skill> skill = new List<Skill>();
    public int[] slotStack;
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
    private int maxStacks = 1; 
    private int slotsNumber = 12;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < slotsNumber; i++){
            skill[i] = Database.skillList[0];
        }
        skill[0] = Database.skillList[1];
        slotStack[0] += 1;
        skill[1] = Database.skillList[2];
        slotStack[1] += 1;
        skill[2] = Database.skillList[3];
        slotStack[2] += 1;
        for(int j=0; j<3; j++) slotStackSkills[j] = -1;
        a = -1;
        b = -1;
        aSlot = -1;
        bSlot = -1;
        slotSkillsM[0].fillAmount = 0f;
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
            }else if(skill[slotStackSkills[i]].id == 0 || slotStack[slotStackSkills[i]] == 1){
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
            if(skill[a].id == skill[b].id){
                if(slotStack[b] == maxStacks){
                    draggedSkill[0] = skill[a];
                    slotTemporary = slotStack[a];
                    skill[a] = skill[b];
                    slotStack[a] = slotStack[b];
                    skill[b] = draggedSkill[0];
                    slotStack[b] = slotTemporary;
                }else{
                    slotStack[b] += slotStack[a];
                    if(slotStack[b] > maxStacks){
                        slotStack[a] = slotStack[b] - maxStacks;
                        slotStack[b] = maxStacks;
                    }else if(slotStack[b] == maxStacks){
                        slotStack[a] = 0;
                        skill[a] = Database.skillList[0];
                    }else{
                        slotStack[a] = 0;
                        skill[a] = Database.skillList[0];
                    }
                }
                
            }else{
                draggedSkill[0] = skill[a];
                slotTemporary = slotStack[a];
                skill[a] = skill[b];
                slotStack[a] = slotStack[b];
                skill[b] = draggedSkill[0];
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

    public void CooldownSkill(){
        if (slotSkillsM[0].fillAmount < 1.0f) slotSkillsM[0].fillAmount += 0.1f * Time.deltaTime;
        if (slotSkillsM[1].fillAmount < 1.0f) slotSkillsM[1].fillAmount += 0.1f * Time.deltaTime;
        if (slotSkillsM[2].fillAmount < 1.0f) slotSkillsM[2].fillAmount += 0.1f * Time.deltaTime;
    }

}
