using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time = 5f;
    // [SerializeField] private GameObject hit;
    float nextActionTime = 0.0f;
    float period = 0.5f;
    float cooldownTime = 0.0f;
    float periodC = 0.5f;
    private bool hit;
    void Start()
    {   
        hit = true;
        Destroy(gameObject, time);
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {

            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                if(hit){
                    int damage = PlayerStatus.damageSkill(30);
                    target.gameObject.GetComponent<Enemy>().TakeDamaged(damage,ElementType.Physical);
                    hit = false;
                }
                target.gameObject.GetComponent<Enemy>().Agony();
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
