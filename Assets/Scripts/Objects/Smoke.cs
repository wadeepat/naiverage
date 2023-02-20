using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    // private float time = 10f;
    // SpriteRenderer rend;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag.Contains("Enemy"))
        {
            if(id == 1){
                target.gameObject.GetComponent<Enemy>().Poison();
            }else if(id == 2){
                target.gameObject.GetComponent<Enemy>().Illusion();
            }else if(id == 3){
                target.gameObject.GetComponent<Enemy>().Agony();
            }
        }
    }

}
