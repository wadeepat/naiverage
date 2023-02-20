using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    [SerializeField] protected ElementType  elementType;
    [SerializeField] private GameObject Effect;

    private void OnTriggerEnter(Collider target)
    {
        // Debug.Log(target.gameObject.name);
        if (target.gameObject.tag.Contains("Enemy"))
        {
            Destroy(transform.parent.gameObject);
            float a = (float)PlayerStatus.damageSkill(0);
            target.gameObject.GetComponent<Enemy>().TakeDamaged(a, elementType);
            Instantiate(Effect, gameObject.transform.position, transform.rotation);

        }
        else if (target.gameObject.name == "Terrain")
            Instantiate(Effect, gameObject.transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
    }
}
