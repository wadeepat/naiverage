using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollState : StateMachineBehaviour
{
    Enemy enemyScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript = animator.GetComponent<Enemy>();
        enemyScript.OnPatrollStateEnter();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript.OnPatrollStateUpdate();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript.StayThisPosition();
    }
}
