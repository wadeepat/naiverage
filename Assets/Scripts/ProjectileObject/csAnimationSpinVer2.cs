using UnityEngine;
using System.Collections;

public class csAnimationSpinVer2 : MonoBehaviour
{

    Animation an;

    void Update()
    {
        an = gameObject.GetComponent<Animation>();
        an.Play();
    }
}
