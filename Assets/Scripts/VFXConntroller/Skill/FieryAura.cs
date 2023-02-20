using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieryAura : MonoBehaviour
{
 // Start is called before the first frame update
    [SerializeField] private float time = 5f;
    float nextActionTime = 0.0f;
    float period = 0.5f;
    float cooldownTime = 0.0f;
    float periodC = 0.5f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    // void OnTriggerEnter(Collider col)
    // {
    //     if (col.tag == "item")
    //     {
    //         Item = col.gameObject;
    //         // canPickUp = true;
    //         y = col.gameObject;
    //         text.text = "Press F to pick up";
    //         pickUpText.SetActive(true);
    //     }
    // }
    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            // if (Time.time > nextActionTime ) {
            //     nextActionTime += period;
            //     int damage = PlayerStatus.damageSkill(70);
            //     target.gameObject.GetComponent<Spider>().TakeDamage(70*Time.deltaTime);
            // }else if(Time.time > cooldownTime){
            //     cooldownTime += periodC;
            // }else{
            //     nextActionTime = 0.0f;
            //     cooldownTime = 0.0f;
            // }
            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                // int damage = PlayerStatus.damageSkill(70);
                target.gameObject.GetComponent<Enemy>().TakeDamaged(0.1f, ElementType.Fire);
            }else if(Time.time > cooldownTime){
                cooldownTime += periodC;
            }else{
                nextActionTime = 0.0f;
                cooldownTime = 0.0f;
            }
        }
    }
}
