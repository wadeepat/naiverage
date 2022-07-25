
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public GameObject Item;
    public bool canPickUp;
    public int mushroom;
    public GameObject pickUpText;

    public static bool pick;
    public static GameObject y;
    // Start is called before the first frame update
    void Start()
    {
        mushroom = 0;
        pick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp == true){
            if(Input.GetKeyDown(KeyCode.F)){
                Destroy(Item);
                Item = null;
                mushroom += 1;
                canPickUp = false;
                pick = true;
            }
        }

        if(canPickUp == true){
            pickUpText.SetActive(true);
        }else{
            pickUpText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "item"){
            Item = col.gameObject;
            canPickUp = true;
            y = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "item"){
            Item = null;
            canPickUp = false;
            y = null;
        }
    }
}
