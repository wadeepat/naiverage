using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeze : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float time = 2f;
    float nextActionTime = 0.0f;
    float period = 0.95f;
    float cooldownTime = 0.0f;
    float periodC = 0.05f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
            Debug.LogWarning("No speed");
    }
    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                int damage = PlayerStatus.damageSkill(10);
                target.gameObject.GetComponent<Enemy>().TakeDamaged(damage*Time.deltaTime,ElementType.Wind);

            }else if(Time.time > cooldownTime){
                cooldownTime += periodC;
            }else{
                nextActionTime = 0.0f;
                cooldownTime = 0.0f;
            }
        }
    }
}
