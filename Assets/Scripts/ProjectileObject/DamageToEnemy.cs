using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20;
    private void OnTriggerEnter(Collider target)
    {
        Destroy(transform.parent.gameObject);
        if (target.gameObject.tag.Contains("Enemy"))
        {
            target.gameObject.GetComponent<Spider>().TakeDamage(damageAmount);
        };
    }
}
