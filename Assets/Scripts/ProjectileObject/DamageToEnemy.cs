using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20;
    private void OnCollisionEnter(Collision co)
    {
        // Debug.Log("Collision");
        Destroy(transform.parent.gameObject);
        if (co.gameObject.tag.Contains("Enemy"))
        {
            co.gameObject.GetComponent<Spider>().TakeDamage(damageAmount);
        };
    }
}
