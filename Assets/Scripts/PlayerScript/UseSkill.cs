using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour
{
    public GameObject skill;
    private Animator _anim;
    private Image[] slotSkillsM;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Done"))
        {
            _anim.SetBool("Skill", false);
            _anim.SetInteger("SkillNum", 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotSkillsM = skill.GetComponent<SkillsUnlock>().slotSkillsM;
            GetSkillSlot1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetSkillSlot2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetSkillSlot3();
        }
    }

    private void GetSkillSlot1()
    {
        if(!CheckCooldown(0)){
            PlayerStatus.UseMana(20);
            int num = skill.GetComponent<SkillsUnlock>().GetSkillId(0);
            AnimetionSkill(num);
            skill.GetComponent<SkillsUnlock>().GetSkillId(0);
            SetCooldown(0);
        }

    }
    private void GetSkillSlot2()
    {
        if(!CheckCooldown(1)){
            PlayerStatus.UseMana(20);
            int num = skill.GetComponent<SkillsUnlock>().GetSkillId(1);
            AnimetionSkill(num);
            skill.GetComponent<SkillsUnlock>().GetSkillId(1);
            SetCooldown(1);
        }
    }
    private void GetSkillSlot3()
    {
        if(!CheckCooldown(2)){
            PlayerStatus.UseMana(20);
            int num = skill.GetComponent<SkillsUnlock>().GetSkillId(2);
            AnimetionSkill(num);
            skill.GetComponent<SkillsUnlock>().GetSkillId(2);
            SetCooldown(2);
        }
    }


    public void AnimetionSkill(int num)
    {
        _anim.SetBool("Skill", true);
        _anim.SetInteger("SkillNum", num);
    }

    public bool CheckCooldown (int num){
        return slotSkillsM[num].fillAmount < 1.0f;
    }

    public void SetCooldown (int num){
        slotSkillsM[num].fillAmount = 0f;
    }
}
