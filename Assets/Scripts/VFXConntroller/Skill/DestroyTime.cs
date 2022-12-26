using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time = 1f;
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
}
