using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCooldownState : StateMachineBehaviour
{
    Enemy enemyScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript = animator.GetComponent<Enemy>();
        enemyScript.StayThisPosition();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScript.OnCooldownStateUpdate();
    }
}
