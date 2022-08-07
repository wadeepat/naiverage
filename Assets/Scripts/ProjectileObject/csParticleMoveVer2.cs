using UnityEngine;
using System.Collections;

public class csParticleMoveVer2 : MonoBehaviour
{
    public float speed = 0.1f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
