using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectController : MonoBehaviour
{
    private float speed = 25f;
    private int damageAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }


    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
            Debug.Log("No speed");
    }
    private void OnTriggerEnter(Collider other)
    {
        // Destroy(transform.GetComponent<Rigidbody>());
        Destroy(gameObject);
        if (other.tag == "Enemy")
        {
            other.GetComponent<Spider>().TakeDamage(damageAmount);
        }

    }
    // private void OnCollisionEnter(Collision co)
    // {
    //     Destroy(gameObject);
    // }
}
