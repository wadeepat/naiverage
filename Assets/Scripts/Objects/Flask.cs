using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    public int id;
    private GameObject Psmoke, Ismoke, Asmoke;
    
    void Start()
    {
        Psmoke = Resources.Load<GameObject>("VFX/Psmoke");
        Ismoke = Resources.Load<GameObject>("VFX/Ismoke");
        Asmoke = Resources.Load<GameObject>("VFX/Asmoke");
    }

    private void OnTriggerEnter(Collider target)
    {
        
        if (target.gameObject.name != "Player"){
            if(id == 1){
                Instantiate(Psmoke, gameObject.transform.position, transform.rotation);
                Destroy(gameObject);
            }else if(id == 2){
                Instantiate(Ismoke, gameObject.transform.position, transform.rotation);
                Destroy(gameObject);
            }else if(id == 3){
                Instantiate(Asmoke, gameObject.transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        
    }
}
