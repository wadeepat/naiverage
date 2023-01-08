using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider target)
    {
        // Destroy(gameObject);
        if (target.gameObject.tag.Contains("Player"))
        {
            Destroy(gameObject);
            target.gameObject.GetComponent<PlayerStatus>().TakeDamaged(damageAmount);
        }
        else if (target.gameObject.name == "Terrain")
            Destroy(gameObject);
    }
}
