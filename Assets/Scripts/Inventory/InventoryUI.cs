using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    // Inventory inventory;
    public GameObject Inven;
    public bool invenIsClose;

    void Start()
    {
        invenIsClose = false;
        // Inventory.instance;
        // Inventory.onItemChangedCallback += Update;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i")){
            if(invenIsClose == true){
                Inven.SetActive(true);
                invenIsClose = false;
            }else{
                Inven.SetActive(false);
                invenIsClose = true;
            }
        }
    }

    // void UpdateUI()
    // {
    //     Debug.Log("UPDATING UI");
    // }
}
