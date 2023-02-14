using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSkillEffect : StateMachineBehaviour
{
    public int id;
    public float time;
    private float checkTime;
    private bool called;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        called = false;
        checkTime = time;
        PlayerManager.instance.player.GetComponent<UseSkill>().StateSkill();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        called = false;
        PlayerManager.instance.player.GetComponent<UseSkill>().ExitSkill();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(called){
        }else if(checkTime <= 0 ){
            PlayerManager.instance.player.GetComponent<UseSkill>().UsingSkillImmediately(id);
            called = true;
        }else{
            checkTime -= Time.deltaTime;
        }
    }
}
