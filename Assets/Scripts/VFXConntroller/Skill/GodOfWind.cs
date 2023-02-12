using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodOfWind : MonoBehaviour
{
[SerializeField] private float time = 5f;
    float nextActionTime = 0.0f;
    float period = 0.5f;
    float cooldownTime = 0.0f;
    bool cooldown = false;
    float periodC = 0.5f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            target.gameObject.GetComponent<Enemy>().Illusion();
        }
    }
}
