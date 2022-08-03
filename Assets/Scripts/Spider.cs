using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damageAmount)
    {
        // Debug.Log("damaged");
        // animator.SetTrigger("damaged");
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damaged");
        }
    }
}
