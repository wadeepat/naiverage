using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Spider : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    // [SerializeField] GameObject EnemyCanvas;
    private int hp;
    [SerializeField] private GameObject healthBar;
    private Animator animator;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetActive(false);
        slider = healthBar.GetComponent<Slider>();
        hp = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp >= 0)
            slider.value = (float)hp / (float)HP;
        else
            slider.value = 0;
    }
    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            healthBar.SetActive(false);
            animator.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            healthBar.SetActive(true);
            animator.SetTrigger("damaged");
        }
    }
}
