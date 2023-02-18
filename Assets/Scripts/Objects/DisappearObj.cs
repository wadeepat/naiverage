using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time = 2f;
    private float timer = 0f;
    // Update is called once per frame
    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        // Time.deltaTime;
        if (timer < time) timer += Time.deltaTime;
        else
        {
            Destroy(this.gameObject);
        }
    }
}
