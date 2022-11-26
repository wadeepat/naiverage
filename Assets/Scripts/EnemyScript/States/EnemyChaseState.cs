using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : StateMachineBehaviour
{
    Enemy enemyScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript = animator.GetComponent<Enemy>();
        enemyScript.OnChaseStateEnter();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript.OnChaseStateUpdate();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript.StayThisPosition();
    }
}
