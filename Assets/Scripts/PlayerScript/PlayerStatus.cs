using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int HP = 100;
    [SerializeField] private GameObject healthBar;
    private Slider slider;
    private int hp;
    void Start()
    {
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
    public void TakeDamaged(int damageAmount)
    {
        hp -= damageAmount;
        Debug.Log("Hited left" + hp);
        if (hp <= 0)
        {
            hp = 0;
            // healthBar.SetActive(false);
            // animator.SetTrigger("die");
            // GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            // healthBar.SetActive(true);
            // animator.SetTrigger("damaged");
        }
    }
}
