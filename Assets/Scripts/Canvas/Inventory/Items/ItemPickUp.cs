
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPickUp : MonoBehaviour
{
    public GameObject Item;
    // public bool canPickUp;
    public int mushroom;
    private GameObject pickUpText;
    private TextMeshProUGUI text;

    public static bool pick;
    public static GameObject y;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText = CanvasManager.instance.GetCanvasObject("InteractText");
        text = pickUpText.GetComponent<TextMeshProUGUI>();
        mushroom = 0;
        pick = false;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(canPickUp == true){
    //         if(Input.GetKeyDown(KeyCode.F)){
    //             Destroy(Item);
    //             Item = null;
    //             mushroom += 1;
    //             canPickUp = false;
    //             pick = true;
    //         }
    //     }

    //     if(canPickUp == true){
    //         pickUpText.SetActive(true);
    //     }else{
    //         pickUpText.SetActive(false);
    //     }
    // }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "item")
        {
            Item = col.gameObject;
            // canPickUp = true;
            y = col.gameObject;
            text.text = "Press F to pick up";
            pickUpText.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "item")
        {
            if (InputManager.instance.GetInteractPressed())
            {
                Destroy(Item);
                Item = null;
                mushroom += 1;
                pick = true;
                pickUpText.SetActive(false);
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "item")
        {
            Item = null;
            y = null;
            pickUpText.SetActive(false);
        }
    }
}
