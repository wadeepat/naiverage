using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaze : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float time = 2f;
    // [SerializeField] private GameObject blaze;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }


    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
            Debug.LogWarning("No speed");
    }

    public void blazeSkill(Transform point, Transform transform){
        // Instantiate(blaze, point.position, transform.rotation);
    }
}
