using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodOfWind : MonoBehaviour
{
    [SerializeField] private float time = 5f;
    private bool hit;
    void Start()
    {
        hit =true;
        Destroy(gameObject, time);
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            if(hit){
                int damage = PlayerStatus.damageSkill(20);
                target.gameObject.GetComponent<Enemy>().TakeDamaged(damage,ElementType.Wind);
                hit = false;
            }
            target.gameObject.GetComponent<Enemy>().Illusion();
        }
    }
}
