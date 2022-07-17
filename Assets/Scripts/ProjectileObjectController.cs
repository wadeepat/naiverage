using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //     if (speed != 0)
        //         transform.position += transform.forward * (speed * Time.deltaTime);
        //     else
        //         Debug.Log("No speed");
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     Destroy(transform.GetComponent<Rigidbody>());
    // }
    private void OnCollisionEnter(Collision co)
    {
        Destroy(gameObject);
    }
}
