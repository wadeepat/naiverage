using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour
{
    public Transform LHPoint, RHPoint, Point;
    public GameObject fire, water, wind, special;
    public GameObject[] allSkill;

    private bool calling = false;
    private GameObject spell1, spell2;
    private Animator _anim;
    private Image[] slotSkillsM;
    private int[] slotStackSkills;
    private int[] a;
    private GameObject skill;
    private PlayerAttackController _attackInfo;
    void Start()
    {
        calling = false;
        _attackInfo = GetComponent<PlayerAttackController>();
        _anim = GetComponent<Animator>();
        // skill = GameObject.Find("Canvas").transform.Find("Panel").Find("Character panel").Find("All funtion").Find("Skill").gameObject;
        skill = GameObject.Find("Canvas/Panel/Character panel/All funtion/Skill");
        slotSkillsM = skill.GetComponent<SkillsUnlock>().slotSkillsM;
        slotStackSkills = skill.GetComponent<SkillsUnlock>().slotStackSkills;

    }

    // Update is called once per frame
    void Update()
    {
        if(spell1 != null && spell2 != null){
            spell1.transform.position = LHPoint.position;
            spell2.transform.position = RHPoint.position;
        }
        
        // if (InputManager.instance.GetSkill1Pressed())
        // {
        //     UseSkill1();
        // }
        // if (InputManager.instance.GetSkill2Pressed())
        // {
        //     UseSkill2();
        // }
        // if (InputManager.instance.GetSkill3Pressed())
        // {
        //     UseSkill3();
        // }        


        skill.GetComponent<SkillsUnlock>().CooldownSkill();
        if(!_anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackCombo") && !calling){
           if (Input.GetKeyDown(KeyCode.Alpha1) && slotStackSkills[0] != -1)
            {
                a = PlayerStatus.callStatus();
                if(a[3] >= 30) GetSkillSlot(0);
            }else if (Input.GetKeyDown(KeyCode.Alpha2)&& slotStackSkills[1] != -1)
            {
                a = PlayerStatus.callStatus();
                if(a[3] >= 30) GetSkillSlot(1);
            }else if (Input.GetKeyDown(KeyCode.Alpha3)&& slotStackSkills[2] != -1)
            {
                a = PlayerStatus.callStatus();
                if(a[3] >= 30) GetSkillSlot(2);
            } 
        }
        
    }

    private void GetSkillSlot(int id)
    {
        _attackInfo.GetComponent<PlayerAttackController>().FaceToClosestEnemy();
        if (!CheckCooldown(id))
        {
            PlayerStatus.UseMana(30);
            int num = skill.GetComponent<SkillsUnlock>().GetSkillId(id);
            AnimetionSkill(num);
            UsingSkill(skill.GetComponent<SkillsUnlock>().GetSkillId(id));
            SetCooldown(id);
        }

    }

    public void AnimetionSkill(int num)
    {
        _anim.SetBool("Skill", true);
        _anim.SetInteger("SkillNum", num);
    }

    public bool CheckCooldown(int num)
    {
        return slotSkillsM[num].fillAmount < 1.0f;
    }

    public void SetCooldown(int num)
    {
        slotSkillsM[num].fillAmount = 0f;
    }
    public void UsingSkill (int num){
        if(num == 1 || num == 4 || num == 6){
            spell1 = Instantiate(fire, LHPoint.position, transform.rotation);
            spell2 = Instantiate(fire, RHPoint.position, transform.rotation);
        }else if(num == 2 || num == 9){
            spell1 = Instantiate(water, LHPoint.position, transform.rotation);
            spell2 = Instantiate(water, RHPoint.position, transform.rotation);
        }else if(num == 3 || num == 5){
            spell1 = Instantiate(wind, LHPoint.position, transform.rotation);
            spell2 = Instantiate(wind, RHPoint.position, transform.rotation);
        }else if(num == 7 || num == 8){
            spell1 = Instantiate(special, LHPoint.position, transform.rotation);
            spell2 = Instantiate(special, RHPoint.position, transform.rotation);
        }
    }

    public void UsingSkillImmediately (int num){
        Instantiate(allSkill[num-1], Point.position, transform.rotation);
    }
    public void StateSkill (){
        calling = true;
    }
    public void ExitSkill (){
        calling = false;
        _anim.SetBool("Skill", false);
        _anim.SetInteger("SkillNum", 0);
        Destroy(spell1);
        Destroy(spell2);
    }
}
