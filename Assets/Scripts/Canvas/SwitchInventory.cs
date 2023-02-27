using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInventory : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject First;
    public GameObject Second;

    void Start()
    {
        First.SetActive(true);
        Second.SetActive(false);
    }

    // Update is called once per frame

    public void FirstButton(){
        First.SetActive(true);
        Second.SetActive(false);
        this?.gameObject.transform.GetComponent<Potions>().UpdateSlot();
        this?.gameObject.transform.GetComponent<Inventory>().UpdateSlot();
    }

    public void SecondButton(){
        First.SetActive(false);
        Second.SetActive(true);
        this?.gameObject.transform.GetComponent<Potions>().UpdateSlot();
        this?.gameObject.transform.GetComponent<Inventory>().UpdateSlot();

    }
}
