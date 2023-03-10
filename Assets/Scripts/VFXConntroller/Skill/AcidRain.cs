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
    float periodC = 0.5f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {

            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                int damage = PlayerStatus.damageSkill(1);
                target.gameObject.GetComponent<Enemy>().Poison();
                target.gameObject.GetComponent<Enemy>().TakeDamaged(damage*Time.deltaTime,ElementType.Water);
            }else if(Time.time > cooldownTime){
                cooldownTime += periodC;
            }else{
                nextActionTime = 0.0f;
                cooldownTime = 0.0f;
            }
        }
    }
}
