using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWings : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private float speed = 10f;
    [SerializeField] private float time = 2f;
    [SerializeField] private GameObject bomb;
    
    // [SerializeField] private GameObject blaze;
    // Start is called before the first frame update
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

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            Instantiate(bomb, gameObject.transform.position, transform.rotation);
            int damage = PlayerStatus.damageSkill(200);
            target.gameObject.GetComponent<Enemy>().TakeDamaged(damage,ElementType.Physical);
        }
        
    }
}