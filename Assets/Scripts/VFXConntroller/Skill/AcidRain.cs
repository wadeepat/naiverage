using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time = 5f;
    // [SerializeField] private GameObject hit;
    float nextActionTime = 0.0f;
    float period = 0.5f;
    float cooldownTime = 0.0f;
    bool cooldown = false;
    float periodC = 0.5f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
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
                target.gameObject.GetComponent<Enemy>().Poison();
                // Instantiate(hit, gameObject.transform.position, gameObject.transform.rotation);
            }else if(Time.time > cooldownTime){
                cooldownTime += periodC;
            }else{
                nextActionTime = 0.0f;
                cooldownTime = 0.0f;
            }
        }
    }
}
