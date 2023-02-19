using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactive : MonoBehaviour
{
    [SerializeField] private float activeTime = 1f;
    private float timer;
    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        if (timer < activeTime) timer += Time.deltaTime;
        else gameObject.SetActive(false);
    }
}
