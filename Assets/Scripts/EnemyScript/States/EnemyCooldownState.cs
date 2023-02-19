using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyCooldownState : StateMachineBehaviour
{
    Enemy enemyScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript = animator.GetComponent<Enemy>();
        enemyScript.OnCooldownStateEnter();
        enemyScript.StayThisPosition();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript.OnCooldownStateUpdate();
    }
}
