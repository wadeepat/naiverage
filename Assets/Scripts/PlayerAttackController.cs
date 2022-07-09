using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public int noOfClicks = 0;
    public float cooldownTime = 2f;
    private Animator _anim;
    private float _nextFireTime = 0f;
    private float _lastClickedTime = 0;
    private float _maxComboDelay = 1;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            _anim.SetBool("Hit1", false);
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            _anim.SetBool("Hit2", false);
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit3"))
        {
            _anim.SetBool("Hit3", false);
            noOfClicks = 0;
        }


        if (Time.time - _lastClickedTime > _maxComboDelay)
        {
            noOfClicks = 0;
        }

        //cooldown time
        if (Time.time > _nextFireTime)
        {
            // Check for mouse input
            if (_anim.GetBool("Grounded") && Input.GetMouseButtonDown(0))
            {
                OnClick();

            }
        }
    }

    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        _lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            _anim.SetBool("Hit1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            _anim.SetBool("Hit1", false);
            _anim.SetBool("Hit2", true);
        }
        if (noOfClicks >= 3 && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            _anim.SetBool("Hit2", false);
            _anim.SetBool("Hit3", true);
        }
    }
}
