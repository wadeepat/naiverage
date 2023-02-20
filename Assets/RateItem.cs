using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateItem : MonoBehaviour
{
    // Start is called before the first frame update
    public int rate;
    void Start()
    {
        int num = Random.Range(1, 101);
        if (num > rate)
        {
            DestroyImmediate(this.gameObject);
        }
        
    }

    // Update is called once per fram
}
