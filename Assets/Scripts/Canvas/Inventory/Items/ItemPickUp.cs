
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
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
    static StarterAssetsInputs assetsInputs;
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

            int itemIdx = col.gameObject.GetComponent<ThisItem>().thisId;
            if (col.gameObject.GetComponent<ThisItem>().type == TypeItem.Quest)
                text.text = "Press F to pick up " + $"<color=#40FF6F>{Database.itemQuestList[itemIdx].name}</color>";
            else text.text = "Press F to pick up " + $"<color=#40FF6F>{Database.itemList[itemIdx].name}</color>";
            pickUpText.SetActive(true);
        }
        else if (col.tag == "MiniGame")
        {
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
        }
        else if (other.tag == "MiniGame" && Item != null)
        {
            if (InputManager.instance.GetInteractPressed())
            {
                assetsInputs = PlayerManager.instance.player.GetComponent<StarterAssetsInputs>();
                PlayerManager.instance.player.GetComponent<PlayerAttackController>().attackAble = false;
                assetsInputs.cursorInputForLook = false;
                assetsInputs.cursorLocked = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                if (y.GetComponent<ThisItem>().thisId == 3)
                {
                    var miniGame = Resources.Load("MiniGame/FlipGame");
                    game = miniGame as GameObject;
                    MGame = Instantiate(game, GameObject.Find("Canvas").transform);
                }
                else if (y.GetComponent<ThisItem>().thisId == 4)
                {
                    var miniGame = Resources.Load("MiniGame/SlidingGame");
                    game = miniGame as GameObject;
                    MGame = Instantiate(game, GameObject.Find("Canvas").transform);
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
        }
        else if (col.tag == "MiniGame")
        {
            Item = null;
            y = null;
            pickUpText.SetActive(false);
        }
    }

    public void DestroyThisOj()
    {
        assetsInputs = PlayerManager.instance.player.GetComponent<StarterAssetsInputs>();
        PlayerManager.instance.player.GetComponent<PlayerAttackController>().attackAble = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        assetsInputs.cursorInputForLook = true;
        assetsInputs.cursorLocked = true;
        Panel = GameObject.Find("Canvas/Panel");
        Panel?.transform.GetComponent<ItemQuests>().GetItemQuest();
        Destroy(MGame);
        Destroy(Item);
        Item = null;
        y = null;
        pickUpText.SetActive(false);
    }

}
