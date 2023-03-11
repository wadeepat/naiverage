using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float desTroyTime = 1.5f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomizeIntesnsity = new Vector3(0.5f, 0, 0);
    private Transform target;
    void Start()
    {
        target = Camera.main.transform;

        Destroy(gameObject, desTroyTime);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(
            Random.Range(-randomizeIntesnsity.x, randomizeIntesnsity.x),
            Random.Range(-randomizeIntesnsity.y, randomizeIntesnsity.y),
            Random.Range(-randomizeIntesnsity.z, randomizeIntesnsity.z));
    }
    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
