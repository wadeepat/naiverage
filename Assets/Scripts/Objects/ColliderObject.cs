using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    public bool isCollided { get; private set; } = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") isCollided = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") isCollided = false;
    }
}
