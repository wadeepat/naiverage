using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
        // gameObject.AddComponent(ObjectCollider);
    }


    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
            Debug.Log("No speed");
    }

}
