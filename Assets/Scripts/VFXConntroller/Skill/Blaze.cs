using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaze : MonoBehaviour
{
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
            Debug.Log("destoryE");
            Instantiate(bomb, gameObject.transform.position, transform.rotation);
            int damage = PlayerStatus.damageSkill(120);
            target.gameObject.GetComponent<Spider>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (target.gameObject.name == "Terrain"){
            Debug.Log("destoryT");
            Instantiate(bomb, gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
