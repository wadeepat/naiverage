using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChick : MonoBehaviour
{
    [SerializeField] private AudioSource chickSound;
    private Animator animator;
    private float chickTime;
    private float chicktimer;
    private float actionTime = 2f;
    private float actiontimer;
    void Start()
    {
        animator = GetComponent<Animator>();
        chickTime = Random.Range(2f, 4f);
        chicktimer = 0;
        actiontimer = 0;
        transform.localScale = Vector3.one * Random.Range(0.7f, 1.3f);
        if (chickSound) chickSound.pitch = Random.Range(0.5f, 1.5f);
    }
    void Update()
    {
        if (chicktimer < chickTime) chicktimer += Time.deltaTime;
        else
        {
            chickSound?.Play();
            chicktimer = 0;
        }
        if (actiontimer < actionTime) actiontimer += Time.deltaTime;
        else
        {
            DoAction(Random.Range(0, 3));
            actiontimer = 0;
        }
    }
    private void DoAction(int actionIdx)
    {
        if (actionIdx == 0)
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Turn Head", false);
        }
        else if (actionIdx == 1)
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Turn Head", true);
        }
        else
        {
            animator.SetBool("Eat", true);
            animator.SetBool("Turn Head", false);
        }
    }
}
