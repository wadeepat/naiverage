
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPickUp : MonoBehaviour
{
    public GameObject Item;
    // public bool canPickUp;
    public int mushroom;
    private GameObject game;
    private GameObject pickUpText;
    private TextMeshProUGUI text;
    public static bool pick;
    public static GameObject y;
    private GameObject Panel;
    private GameObject MGame;
    // Start is called before the first frame update
    void Start()
    {

        pickUpText = CanvasManager.instance.GetCanvasObject("InteractText");
        text = pickUpText.GetComponent<TextMeshProUGUI>();
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
            pick = true;
            Item = col.gameObject;
            y = col.gameObject;
            text.text = "Press F to pick up";
            pickUpText.SetActive(true);
        }else if(col.tag == "MiniGame"){
            pick = true;
            Item = col.gameObject;
            y = col.gameObject;
            text.text = "Press F to solve puzzles";
            pickUpText.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "item" && Item != null)
        {
            if (InputManager.instance.GetInteractPressed())
            {
                AudioManager.instance.Play("pick");
                Panel = GameObject.Find("Canvas/Panel");
                if (Item.GetComponent<ThisItem>().type == TypeItem.Normal) Panel.transform.GetComponent<Inventory>().GetNormalItem();
                else if (Item.GetComponent<ThisItem>().type == TypeItem.Potion) Panel.transform.GetComponent<Potions>().GetPotion();
                else if (Item.GetComponent<ThisItem>().type == TypeItem.Skill) Panel.transform.Find("Character panel/All funtion/Skill").GetComponent<InvenSkillBook>().GetSkillBook();
                else if (Item.GetComponent<ThisItem>().type == TypeItem.Quest) Panel.transform.GetComponent<ItemQuests>().GetItemQuest();
                Destroy(Item);
                Item = null;
                y = null;
                pickUpText.SetActive(false);
            }
        }else if(other.tag == "MiniGame" && Item != null){
            if (InputManager.instance.GetInteractPressed())
            {
                if(y.GetComponent<ThisItem>().thisId == 3){
                    var miniGame = Resources.Load("MiniGame/FlipGame");
                    game = miniGame as GameObject;
                    MGame = Instantiate(game,GameObject.Find("Canvas").transform);
                }
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
        }else if(col.tag == "MiniGame"){
            Item = null;
            y = null;
            pickUpText.SetActive(false);
        }
    }

    public void DestroyThisOj(){
        Panel = GameObject.Find("Canvas/Panel");
        Panel?.transform.GetComponent<ItemQuests>().GetItemQuest();
        Destroy(MGame);
        Destroy(Item);
        Item = null;
        y = null;
        pickUpText.SetActive(false);
    }
    
}
