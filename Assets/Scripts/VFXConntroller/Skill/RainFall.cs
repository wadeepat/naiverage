using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFall : MonoBehaviour
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


    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                target.gameObject.GetComponent<Enemy>().TakeDamaged(0.1f, ElementType.Water);
            }else if(Time.time > cooldownTime){
                cooldownTime += periodC;
            }else{
                nextActionTime = 0.0f;
                cooldownTime = 0.0f;
            }
        }
    }
}
